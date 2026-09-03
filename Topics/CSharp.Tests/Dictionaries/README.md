# Dictionaries

Dictionary<TKey,TValue> maps unique keys to values using equality and hashing.

## Syntax

```csharp
// <string, int> means string keys and integer values.
// This comparer treats "Ada" and "ADA" as the same key.
var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
counts["Ada"] = 1; // The indexer adds this key if absent, or replaces its value.
counts["ADA"] = 2; // Updates the same entry; Count is still 1.

// TryGetValue returns whether the key exists; out receives the associated value.
bool found = counts.TryGetValue("ada", out int count); // true; count is 2.
bool missing = counts.TryGetValue("Bob", out int absent); // false; absent is 0.

// Add requires a new key. Calling counts.Add("Ada", 3) would throw.
// TryAdd instead reports a duplicate through its Boolean return value.
bool added = counts.TryAdd("Ada", 3); // false; the existing value stays 2.

// An indexer read like counts["Bob"] throws for a missing key.
// Prefer TryGetValue when absence is an ordinary outcome.
```

## How the examples work

Tests cover insertion versus replacement, missing keys, duplicate-key errors, and a case-insensitive key comparer.

Read [DictionariesTests.cs](../Tests/DictionariesTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use dictionaries for lookup tables, indexes, counts, and caches keyed by an identifier.

## Best practices

Choose a comparer when keys are strings. TryGetValue avoids using exceptions for expected missing keys. Keys must remain stable with respect to equality and hashing. Do not rely on enumeration order as a contract.

## Related reading

- [Sets](../Sets/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
