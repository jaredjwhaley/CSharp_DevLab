# RegularExpressions

Regular expressions describe text patterns for recognition, extraction, and replacement.

## Syntax

```csharp
var pattern = new Regex(@"\A(?<code>[A-Z]{2})-(?<number>[0-9]+)\z",
    RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(100));
```

## How the examples work

Tests cover named groups, full-input anchors, replacement group syntax, literal escaping, and a configured finite timeout. The timeout configuration is tested without a timing-sensitive catastrophic-backtracking test.

Read [RegularExpressionsTests.cs](../Tests/RegularExpressionsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use regex for compact text patterns. Prefer a parser for nested grammars and TryParse for ordinary numbers or dates.

## Best practices

Use a finite timeout for backtracking patterns, especially with untrusted input. Escape user-supplied literal text with Regex.Escape. C# string escaping and regex escaping are separate layers. NonBacktracking offers predictable matching for supported patterns; it does not support every regex feature.

## Related reading

- [Strings](../Strings/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference)
