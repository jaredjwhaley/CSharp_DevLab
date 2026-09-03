# Conditionals

Conditionals choose a path based on a Boolean expression or a matched pattern.

## Syntax

```csharp
int score = 75;
// if runs its block only when the condition is true; else handles the other case.
if (score >= 60)
    Console.WriteLine("Pass"); // This branch runs.
else
    Console.WriteLine("Fail");

// ?: chooses a value when a full statement block is unnecessary.
string grade = score >= 60 ? "Pass" : "Fail"; // "Pass"

object? value = 3;
// A switch expression selects the first matching arm and returns its value.
// 'int n' matches an integer and names it n; 'when' adds a further condition.
// _ is a discard pattern: it matches anything not handled earlier.
string description = value switch
{
    null => "Missing",
    int n when n > 0 => "Positive integer",
    _ => "Other"
}; // "Positive integer"

// 'is' can test relational patterns; 'and' requires both patterns to match.
bool passingScore = score is >= 60 and <= 100; // true
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
