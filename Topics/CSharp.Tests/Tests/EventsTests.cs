using DevLab.CSharp.Events;
using FluentAssertions;

namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates message delivery, event contracts, and temperature-monitor subscriptions.</summary>
public class EventsTests
{
    /// <summary>
    /// Verifies that a subscribed handler receives and stores a published message.
    /// </summary>
    [Fact]
    public void Subscriber_Should_Receive_Event_Message()
    {
        var publisher = new MessagePublisher();
        var subscriber = new MessageSubscriber();

        publisher.MessagePublished += subscriber.HandleMessage;

        publisher.Publish("Hello");

        subscriber.LastMessage.Should().Be("Hello");
    }

    /// <summary>
    /// Verifies that the subscriber stores the latest message after
    /// multiple messages are published.
    /// </summary>
    /// <remarks>
    /// The handler remains subscribed across successive Publish calls.
    /// This assertion checks the final stored value; it does not independently
    /// verify that the first message was received.
    /// </remarks>
    [Fact]
    public void Subscriber_Should_Receive_Multiple_Event_Messages()
    {
        var publisher = new MessagePublisher();
        var subscriber = new MessageSubscriber();

        publisher.MessagePublished += subscriber.HandleMessage;

        publisher.Publish("First");
        publisher.Publish("Second");

        subscriber.LastMessage.Should().Be("Second");
    }

    /// <summary>Publishing without subscribers is a valid no-op for notification delivery.</summary>
    [Fact]
    public void NoSubscribers_IsSafe()
    {
        new MessagePublisher().Publish("Hello");
        var sensor = new TemperatureMonitor(20);
        sensor.Temperature = 21;
        Assert.Equal(21m, sensor.Temperature);
    }

    /// <summary>Handlers run synchronously in subscription order before Publish returns.</summary>
    [Fact]
    public void MultipleSubscribers_RunSynchronously()
    {
        var publisher = new MessagePublisher();
        var calls = new List<string>();
        publisher.MessagePublished += (_, _) => calls.Add("first");
        publisher.MessagePublished += (_, _) => calls.Add("second");
        publisher.Publish("Hello");
        calls.Add("returned");
        Assert.Equal(new[] { "first", "second", "returned" }, calls);
    }

    /// <summary>Duplicate subscriptions invoke twice; one removal removes one matching entry.</summary>
    [Fact]
    public void DuplicateSubscriptions_AndRemoval()
    {
        var publisher = new MessagePublisher();
        int calls = 0;
        EventHandler<MessageEventArgs> handler = (_, _) => calls++;
        publisher.MessagePublished += handler;
        publisher.MessagePublished += handler;
        publisher.Publish("twice");
        Assert.Equal(2, calls);
        publisher.MessagePublished -= handler;
        publisher.Publish("once");
        Assert.Equal(3, calls);
        publisher.MessagePublished -= handler;
        publisher.Publish("none");
        Assert.Equal(3, calls);
    }

    /// <summary>Event data and sender identify the transition; state is committed before notification.</summary>
    [Fact]
    public void TemperatureChange_ReportsOldNewAndSender()
    {
        var sensor = new TemperatureMonitor(20);
        var changes = new List<TemperatureChangedEventArgs>();
        sensor.TemperatureChanged += (sender, e) =>
        {
            Assert.Same(sensor, sender);
            Assert.Equal(e.NewTemperature, sensor.Temperature);
            changes.Add(e);
        };
        sensor.Temperature = 20;
        Assert.Empty(changes);
        sensor.Temperature = 25;
        sensor.Temperature = 22;
        Assert.Equal(new[] { 20m, 25m }, changes.Select(e => e.OldTemperature));
        Assert.Equal(new[] { 25m, 22m }, changes.Select(e => e.NewTemperature));
    }

    /// <summary>A failed handler stops later handlers without rolling back sensor state.</summary>
    [Fact]
    public void HandlerException_PropagatesAfterStateChange()
    {
        var sensor = new TemperatureMonitor(20);
        bool laterCalled = false;
        var failure = new InvalidOperationException("subscriber failed");
        sensor.TemperatureChanged += (_, _) => throw failure;
        sensor.TemperatureChanged += (_, _) => laterCalled = true;
        Assert.Same(failure, Assert.Throws<InvalidOperationException>(() => sensor.Temperature = 21));
        Assert.Equal(21m, sensor.Temperature);
        Assert.False(laterCalled);
    }

    /// <summary>Derived classes can augment raising or deliberately suppress base delivery.</summary>
    [Fact]
    public void VirtualRaiser_IsAnExtensionPoint()
    {
        var sensor = new CustomMonitor();
        int received = 0;
        sensor.TemperatureChanged += (_, _) => received++;
        sensor.Temperature = 21;
        Assert.Equal(1, sensor.RaiseRequests);
        Assert.Equal(1, received);
        sensor.Suppress = true;
        sensor.Temperature = 22;
        Assert.Equal(2, sensor.RaiseRequests);
        Assert.Equal(1, received);
        Assert.Equal(22m, sensor.Temperature);
    }

    /// <summary>Cooling retains its previous state inside the band and switches at inclusive boundaries.</summary>
    [Fact]
    public void Thermostat_UsesHysteresisForEveryActuator()
    {
        var sensor = new TemperatureMonitor(20);
        var units = new[] { new AirConditioner(), new AirConditioner() };
        using var thermostat = new Thermostat(sensor, 20, 24, units);
        sensor.Temperature = 23;
        Assert.All(units, ac => Assert.False(ac.IsOn));
        sensor.Temperature = 24;
        Assert.All(units, ac => Assert.True(ac.IsOn));
        sensor.Temperature = 22;
        Assert.All(units, ac => Assert.True(ac.IsOn));
        sensor.Temperature = 20;
        Assert.All(units, ac => Assert.False(ac.IsOn));
    }

    /// <summary>Construction evaluates a hot sensor; disposal ends subsequent updates and is idempotent.</summary>
    [Fact]
    public void Thermostat_InitialStateAndSubscriptionLifetime()
    {
        var sensor = new TemperatureMonitor(30);
        var ac = new AirConditioner();
        var thermostat = new Thermostat(sensor, 20, 24, new[] { ac });
        Assert.True(ac.IsOn);
        thermostat.Dispose();
        thermostat.Dispose();
        sensor.Temperature = 18;
        Assert.True(ac.IsOn);
    }

    /// <summary>An empty actuator list is valid; invalid thresholds and impossible readings fail.</summary>
    [Fact]
    public void TemperatureConfiguration_ValidatesBoundaries()
    {
        var sensor = new TemperatureMonitor(-273.15m);
        using var thermostat = new Thermostat(sensor, 20, 24, Array.Empty<AirConditioner>());
        sensor.Temperature = 30;
        Assert.Throws<ArgumentOutOfRangeException>(() => sensor.Temperature = -274);
        Assert.Equal(30m, sensor.Temperature);
        Assert.Throws<ArgumentOutOfRangeException>(() => new TemperatureMonitor(-274));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat(sensor, 24, 24, []));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat(sensor, -274, 24, []));
        Assert.Throws<ArgumentNullException>(() => new Thermostat(null!, 20, 24, []));
        Assert.Throws<ArgumentNullException>(() => new Thermostat(sensor, 20, 24, null!));
        Assert.Throws<ArgumentException>(() => new Thermostat(sensor, 20, 24, new AirConditioner[] { null! }));
    }

    private sealed class CustomMonitor() : TemperatureMonitor(20)
    {
        public int RaiseRequests { get; private set; }
        public bool Suppress { get; set; }
        protected override void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            RaiseRequests++;
            if (!Suppress) base.OnTemperatureChanged(e);
        }
    }
}
