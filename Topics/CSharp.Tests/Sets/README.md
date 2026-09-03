# Sets

A set stores unique values and supports membership and set operations.

## Syntax

```csharp
// HashSet stores unique values. The comparer defines which strings count as equal.
var tags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
bool first = tags.Add("CSharp");  // true: a new value was inserted.
bool again = tags.Add("csharp");  // false: equivalent value already present.
bool contains = tags.Contains("CSHARP"); // true.

var values = new HashSet<int> { 1, 2, 3 };
// With-suffixed operations modify the receiving set instead of returning a copy.
values.IntersectWith(new[] { 2, 3, 4 }); // Keeps values in both: {2, 3}.
values.UnionWith(new[] { 4 });           // Adds values from either: {2, 3, 4}.
values.ExceptWith(new[] { 3 });          // Removes these values: {2, 4}.

// SetEquals compares membership without requiring the same enumeration order.
bool sameMembers = values.SetEquals(new[] { 4, 2 }); // true.
// Braces above describe membership; do not depend on HashSet traversal order.
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
