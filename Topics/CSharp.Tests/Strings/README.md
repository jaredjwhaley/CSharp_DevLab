# Strings

A string is an immutable sequence of UTF-16 code units. Text operations return new strings instead of modifying the original.

## Syntax

```csharp
var greeting = $"Hello, {name}";
bool same = string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
```

## How the examples work

Tests show immutability, explicit comparisons, interpolation, escaping, and StringBuilder. A char is one UTF-16 code unit, not necessarily a complete user-perceived character.

Read [StringsTests.cs](../Tests/StringsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use strings for display and identifiers, and StringBuilder for repeated incremental construction in a loop.

## Best practices

Choose ordinal comparisons for programmatic identifiers and culture-aware rules for human language. Specify culture for persisted numeric text. Avoid treating Length as a count of visible characters.

## Related reading

- [RegularExpressions](../RegularExpressions/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
