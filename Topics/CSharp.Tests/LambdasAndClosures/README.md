# LambdasAndClosures

A lambda is an inline function. A closure retains access to captured variables after their original scope has ended.

## Syntax

```csharp
// => separates a lambda's input parameters from its body.
// Func<int, int> takes an int and returns an int; the last type is the result type.
Func<int, int> square = static x => x * x;
int result = square(4); // 16. static prevents this lambda from capturing locals.

int offset = 2;
// This lambda captures the VARIABLE offset, not a frozen copy of its current value.
Func<int, int> addOffset = x => x + offset;
offset = 10;
int shifted = addOffset(3); // 13, because offset is read when the lambda runs.

// Use a block body for multiple statements. Action returns void, so no return value.
Action<string> display = message =>
{
    string trimmed = message.Trim();
    Console.WriteLine(trimmed);
};
display(" Ada "); // Prints "Ada".
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
