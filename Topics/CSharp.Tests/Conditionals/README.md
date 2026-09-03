# Conditionals

Conditionals choose a path based on a Boolean expression or a matched pattern.

## Syntax

```csharp
if (score >= 60) return "Pass";
return value switch { null => "Missing", int n when n > 0 => "Positive", _ => "Other" };
```

## How the examples work

Tests cover if/else, a switch statement, a conditional expression, relational/logical patterns, and type patterns with guards.

Read [ConditionalsTests.cs](../Tests/ConditionalsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use if for arbitrary conditions, switch for a set of alternatives, and ?: for a small value selection.

## Best practices

Order patterns from specific to general and include a deliberate fallback. Keep branches short; do not hide side effects inside complicated conditional expressions.

## Related reading

- [Operators](../Operators/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
