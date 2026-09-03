# StacksAndQueues

Stacks remove the newest item first (LIFO); queues remove the oldest item first (FIFO).

## Syntax

```csharp
var stack = new Stack<int>(); stack.Push(1);
var queue = new Queue<int>(); queue.Enqueue(1);
```

## How the examples work

Tests show ordering, nondestructive Peek, removal, and safe empty collection handling.

Read [StacksAndQueuesTests.cs](../Tests/StacksAndQueuesTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use a stack for undo/history or depth-first work; use a queue for arrival-order processing or breadth-first work.

## Best practices

Prefer TryPop/TryDequeue when emptiness is normal. These collections are not synchronized; concurrent producers/consumers need appropriate concurrent types or synchronization.

## Related reading

- [Enumeration](../Enumeration/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
