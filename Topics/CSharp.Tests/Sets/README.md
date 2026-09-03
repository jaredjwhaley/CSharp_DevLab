# Sets

A set stores unique values and supports membership and set operations.

## Syntax

```csharp
var tags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
tags.Add("CSharp");
tags.UnionWith(otherTags);
```

## How the examples work

Tests exercise uniqueness, union, intersection, difference, and SortedSet ordering.

Read [SetsTests.cs](../Tests/SetsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use HashSet for membership checks and deduplication; use SortedSet when unique values also need comparer-defined order.

## Best practices

Use stable equality/hash codes and explicit string comparers. HashSet membership is typically O(1); SortedSet operations are O(log n). The With operations mutate their receiver; LINQ set operators return sequences.

## Related reading

- [Linq](../Linq/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
