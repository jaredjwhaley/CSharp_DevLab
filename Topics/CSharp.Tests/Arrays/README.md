# Arrays

Arrays hold a fixed number of elements of one type, addressed by zero-based indexes.

## Syntax

```csharp
// int[] declares an array of integers. The collection expression on the
// right ([10, 20, 30], introduced in C# 12) initializes its three elements.
int[] values = [10, 20, 30];

// Indexes start at zero: index 0 is the first element, index 2 is the third.
int first = values[0]; // 10

// ^ counts backward from the end. ^1 means the last element, not index 1.
// Index-from-end (^) and range (..) syntax were introduced in C# 8.
int last = values[^1]; // 30; equivalent here to values[values.Length - 1]

// A range includes its start but excludes its end. Omitting the end means
// continue to the array's end. Slicing an array creates a new array.
int[] copy = values[1..]; // [20, 30]: everything AFTER the first element
int[] exceptLast = values[..^1]; // [10, 20]: everything BEFORE the last element
int[] middle = values[1..2]; // [20]: includes index 1, excludes index 2

// Changing a copied integer element does not change the original array.
copy[0] = 99; // values is still [10, 20, 30]
// ^0 describes the position after the last element; values[^0] is invalid.
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
- [Microsoft: Index-from-end and range operators](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators)
- [Microsoft: Collection expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/collection-expressions)
