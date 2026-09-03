# Lists

List<T> is a resizable indexed collection that preserves element order and permits duplicates.

## Syntax

```csharp
// <int> is the generic element type: this list accepts integers.
// The collection initializer adds two values to the new list.
var values = new List<int> { 10, 30 };
values.Add(40);       // Appends at the end: [10, 30, 40].
values.Insert(1, 20); // Inserts BEFORE index 1: [10, 20, 30, 40].

// An indexer gets or replaces an existing element; indexes start at zero.
int first = values[0]; // 10
values[0] = 5;         // [5, 20, 30, 40]

// Remove searches for a VALUE and removes its first occurrence.
// RemoveAt instead removes the element at an INDEX.
bool removed = values.Remove(20); // true; [5, 30, 40]
values.RemoveAt(0);               // [30, 40]
int count = values.Count;         // 2; Capacity is allocated space, not item count.

// ToList makes a separate container. Reference-type elements would still be shared.
var copy = values.ToList();
copy.Add(50); // values still contains only [30, 40].
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
