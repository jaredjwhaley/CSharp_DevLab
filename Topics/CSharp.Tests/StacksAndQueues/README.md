# StacksAndQueues

Stacks remove the newest item first (LIFO); queues remove the oldest item first (FIFO).

## Syntax

```csharp
// A stack is LIFO: last in, first out. Push adds; Pop removes the newest item.
var stack = new Stack<int>();
stack.Push(10);
stack.Push(20);
int newest = stack.Peek(); // 20; Peek does NOT remove it.
int popped = stack.Pop();  // 20; only 10 remains.

// A queue is FIFO: first in, first out. Enqueue adds; Dequeue removes the oldest.
var queue = new Queue<int>();
queue.Enqueue(10);
queue.Enqueue(20);
int oldest = queue.Dequeue(); // 10; only 20 remains.

// TryDequeue returns false instead of throwing when the queue is empty.
bool found = queue.TryDequeue(out int next); // true; next is 20.
bool empty = queue.TryDequeue(out int none); // false; none is 0.
// Stack has an equivalent TryPop operation for expected empty-stack cases.
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
