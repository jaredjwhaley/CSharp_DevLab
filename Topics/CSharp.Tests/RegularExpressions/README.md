# RegularExpressions

Regular expressions describe text patterns for recognition, extraction, and replacement.

## Syntax

```csharp
// @ prevents C# from treating backslashes as string escapes; the regex engine
// still interprets them as regex syntax. These are two separate parsing layers.
var pattern = new System.Text.RegularExpressions.Regex(
    @"\A(?<code>[A-Z]{2})-(?<number>[0-9]+)\z",
    System.Text.RegularExpressions.RegexOptions.CultureInvariant,
    TimeSpan.FromMilliseconds(100)); // Finite matching timeout, not a deliberate delay.

// \A / \z require the beginning / absolute end of the whole input.
// (?<code>...) names a capture group. [A-Z]{2} matches exactly two ASCII capitals.
// '-' matches a literal hyphen. [0-9]+ matches one or more ASCII digits.
var match = pattern.Match("AB-123");
bool valid = match.Success;                 // true
string code = match.Groups["code"].Value;   // "AB"
string number = match.Groups["number"].Value; // "123"; still text, not an int.

// Replacement strings use ${groupName} to insert captured text.
string reordered = pattern.Replace("AB-123", "${number}/${code}"); // "123/AB"
// Regex.Escape("a+b.txt") makes '+' and '.' literal when building a pattern.
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
