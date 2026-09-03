# Operators

Operators combine, compare, assign, or transform values. Operand types determine what an operator means.

## Syntax

```csharp
int quotient = 7 / 2;
bool eligible = age >= 18 && hasTicket;
string label = eligible ? "Enter" : "Wait";
```

## How the examples work

Tests cover integer division, remainder, floating-point division, precedence, short-circuit Boolean evaluation, and bitwise masks.

Read [OperatorsTests.cs](../Tests/OperatorsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use arithmetic for calculations, comparisons for decisions, and bitwise operators for flags and low-level representations.

## Best practices

Use parentheses to make intent clear. && and || may skip the right operand; & and | evaluate both Boolean operands. Integer division discards the fractional part.

## Related reading

- [Conditionals](../Conditionals/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
