# Lists

List<T> is a resizable indexed collection that preserves element order and permits duplicates.

## Syntax

```csharp
var values = new List<int> { 1, 2 };
values.Add(3);
values.Remove(1);
```

## How the examples work

Tests show insertion, removal, Count versus Capacity, and the difference between copying the container and copying referenced objects.

Read [ListsTests.cs](../Tests/ListsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use a list for ordered data that grows or shrinks and needs indexing.

## Best practices

Index access is O(1); middle insertion/removal and linear searches are O(n). Capacity is allocated space, not item count. ToList copies the collection but shares referenced elements.

## Related reading

- [Arrays](../Arrays/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
