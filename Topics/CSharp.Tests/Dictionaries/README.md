# Dictionaries

Dictionary<TKey,TValue> maps unique keys to values using equality and hashing.

## Syntax

```csharp
var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
counts["Ada"] = 1;
bool found = counts.TryGetValue("ADA", out int count);
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
