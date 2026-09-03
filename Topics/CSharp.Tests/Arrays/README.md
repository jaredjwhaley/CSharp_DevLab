# Arrays

Arrays hold a fixed number of elements of one type, addressed by zero-based indexes.

## Syntax

```csharp
int[] values = [10, 20, 30];
int last = values[^1];
int[] copy = values[1..];
```

## How the examples work

Tests cover indexes, ranges, bounds, rectangular arrays, and jagged arrays. Slicing an array creates a new array; its elements are copied shallowly.

Read [ArraysTests.cs](../Tests/ArraysTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use arrays when the size is known or an API needs contiguous indexed storage.

## Best practices

Check boundaries and distinguish Length from the last valid index. Arrays are reference types even when their elements are values. Prefer List when the size must change.

## Related reading

- [Lists](../Lists/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
