# LambdasAndClosures

A lambda is an inline function. A closure retains access to captured variables after their original scope has ended.

## Syntax

```csharp
Func<int, int> square = x => x * x;
int offset = 2;
Func<int, int> addOffset = x => x + offset;
```

## How the examples work

Tests cover Func, Action, Predicate, a mutable captured variable, loop captures, and a static lambda that cannot capture locals.

Read [LambdasAndClosuresTests.cs](../Tests/LambdasAndClosuresTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use lambdas for short callbacks, LINQ predicates, and small behavior parameters.

## Best practices

Closures capture variables rather than frozen values. Copy a for-loop variable when each callback needs its own value. Captures can extend object lifetimes; retain event-handler delegates if you need to unsubscribe. Use static lambdas when no capture is needed.

## Related reading

- [Delegates](../Delegates/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
