# Strings

A string is an immutable sequence of UTF-16 code units. Text operations return new strings instead of modifying the original.

## Syntax

```csharp
string name = "Ada";
// $ enables interpolation: expressions inside braces become part of the text.
string greeting = $"Hello, {name}"; // "Hello, Ada"

// A regular string uses escape sequences: \n is a newline; \\ is a backslash.
string path = "C:\\temp";
string verbatimPath = @"C:\temp"; // @ preserves backslashes literally.

// Strings are immutable: Replace returns a value; it does not edit greeting.
string changed = greeting.Replace("Ada", "Grace"); // "Hello, Grace"
// greeting still contains "Hello, Ada".

// Choose the comparison rule explicitly for programmatic identifiers.
bool same = string.Equals("FILE", "file", StringComparison.OrdinalIgnoreCase);
// same is true; letter case is ignored without using language-specific sorting.

// F2 requests two decimal places; invariant culture supplies a stable decimal dot.
string price = 12.5m.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
// price is "12.50".
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
