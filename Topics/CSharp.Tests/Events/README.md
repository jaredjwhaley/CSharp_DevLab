# Events

An event lets an object announce that something happened while leaving the response to other objects. A temperature sensor can report a changed reading without knowing whether a thermostat, chart, or logger is listening.

## Why an event instead of sequential calls?

Use ordinary method calls when one operation owns a known sequence of steps or needs a result from the next step. Use an event when the publisher owns the fact that something happened but should not own the list of reactions. Subscribers can be added or removed without modifying the publisher.

Events do **not** automatically introduce concurrency. Normal .NET event invocation calls handlers synchronously on the raising thread, in subscription order. A slow handler delays the publisher. A throwing handler propagates its exception and prevents later handlers in that invocation from running. Avoid making business correctness depend on handler order; use explicit orchestration for that requirement.

## Event, delegate type, and handler

| Term | This example | Responsibility |
| --- | --- | --- |
| Publisher | `TemperatureMonitor` | Owns the reading and decides when it changed |
| Event | `TemperatureChanged` | Exposes subscription and unsubscription |
| Delegate type | `EventHandler<TemperatureChangedEventArgs>` | Defines the required method signature |
| Handler | `Thermostat.HandleTemperatureChanged` | Reacts to a notification |
| Event arguments | `TemperatureChangedEventArgs` | Carries old and new readings |

The delegate is required because the compiler needs to know which methods can be subscribed. The `event` keyword restricts what outside code can do with that delegate: consumers can use `+=` and `-=`, but cannot invoke the event or replace its invocation list. Read [Delegates](../Delegates/README.md) first if method groups and signatures are unfamiliar; [Lambdas and closures](../LambdasAndClosures/README.md) explains inline handlers.

```csharp
// Create a publisher whose initial temperature is 20 degrees Celsius.
var sensor = new TemperatureMonitor(20m);

// EventHandler<T> defines a void handler with sender and event-data parameters.
// The lambda prints the immutable old/new readings carried by the notification.
EventHandler<TemperatureChangedEventArgs> log = (sender, e) =>
    Console.WriteLine($"{e.OldTemperature} -> {e.NewTemperature}");

sensor.TemperatureChanged += log; // Subscribe: add this handler to the event.
sensor.Temperature = 25m;         // Changes state and invokes log synchronously.
sensor.TemperatureChanged -= log; // Unsubscribe using the same saved delegate.
sensor.Temperature = 26m;         // log is no longer called.
// Outside code cannot invoke or replace the event: the publisher controls raising.
```

The publisher uses `TemperatureChanged?.Invoke(this, e)`. The null-conditional call makes an absent subscriber list safe. This does not make the publisher or subscriber state thread-safe.

## Read and run the examples

1. [MessagePublisher.cs](MessagePublisher.cs), [MessageEventArgs.cs](MessageEventArgs.cs), and [MessageSubscriber.cs](MessageSubscriber.cs) demonstrate the smallest publisher/subscriber arrangement. The message tests are included in [EventsTests.cs](../Tests/EventsTests.cs).
2. [TemperatureMonitor.cs](TemperatureMonitor.cs) suppresses equal assignments, stores the new state, and then raises an immutable old/new payload through `protected virtual OnTemperatureChanged`.
3. [Thermostat.cs](Thermostat.cs) subscribes to that event and controls [AirConditioner.cs](AirConditioner.cs). It applies the initial reading immediately. Cooling starts at or above the upper threshold and stops at or below the lower threshold; within the band, it retains its state. This is **hysteresis**, which reduces rapid on/off switching near a single threshold.
4. [EventsTests.cs](../Tests/EventsTests.cs) also covers sender/payload assertions, multiple and duplicate subscribers, unsubscription, exceptions, derived-class raising, threshold behavior, and disposal.

```csharp
var sensor = new TemperatureMonitor(20m);
var ac = new AirConditioner(); // Starts with cooling off.

// The thermostat subscribes internally. using var calls Dispose at scope exit,
// removing its handler so the sensor no longer retains this subscriber.
using var thermostat = new Thermostat(sensor, 20m, 24m, new[] { ac });

sensor.Temperature = 24m; // Reaches upper threshold: cooling turns on.
sensor.Temperature = 22m; // Inside the band: cooling stays on (hysteresis).
sensor.Temperature = 20m; // Reaches lower threshold: cooling turns off.
// These are ordinary synchronous property assignments, with event notifications
// connecting the sensor to its subscriber. No background thread is implied.
```

This extracts the event-driven portion of the [course temperature monitor](../../../Courses/Udemy/CompleteCSharpMasterclass/S011_EventsAndDelegates/C231_TemperatureMonitor/TemperatureMonitor.cs). The course also contains room physics and unit conversions. The topic intentionally uses decimal Celsius readings and direct assignments to make behavior deterministic. It corrects the course monitor's notification-before-assignment order and introduces hysteresis as an explicitly documented topic behavior. Course files remain unchanged.

## Best practices and limits

- Keep payloads immutable and identify units. Updating state before raising a change event lets handlers read consistent state.
- A virtual `On...` method is an extension point. An override can add behavior, call the base method to notify, or suppress notification by omitting it. It does not enforce how arguments are constructed.
- A publisher retains references to subscribed instance handlers. Detach when the subscriber's lifetime ends; the thermostat uses `IDisposable` for this purpose. It borrows the sensor and actuators and does not dispose them.
- Save a lambda delegate if you need to remove it later. A newly written lambda is not a reliable match for an earlier subscription. Duplicate subscriptions are allowed; one `-=` removes one matching entry.
- These examples assume one thread. Reentrant handlers can produce nested notifications. If thread dispatch, asynchronous completion, error isolation, or durable delivery is required, design that contract explicitly.
- Use `EventHandler<TEventArgs>` for ordinary notifications. A callback delegate is often simpler when a caller supplies exactly one operation that must return a result.

## Related reading

- [Delegates](../Delegates/README.md), [Composition](../Composition/README.md), [Resource disposal](../ResourceDisposal/README.md)
- [WPF data binding](../../Wpf.Tests/DataBinding/README.md) uses property-change notifications for UI updates.
- [Microsoft: Events](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/)
- [Microsoft: Subscribe and unsubscribe](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events)
- [Topic index](../README.md)
