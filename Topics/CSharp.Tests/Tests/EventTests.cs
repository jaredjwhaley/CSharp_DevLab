using Xunit;
using FluentAssertions;
using DevLab.CSharp.Events;

namespace DevLab.CSharp.Tests
{
    public class EventTests
    {
        [Fact]
        public void Subscriber_Should_Receive_Event_Message()
        {
            var publisher = new MessagePublisher();
            var subscriber = new MessageSubscriber();

            publisher.MessagePublished += subscriber.HandleMessage;

            publisher.Publish("Hello");

            subscriber.LastMessage.Should().Be("Hello");
        }

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
    }
}
