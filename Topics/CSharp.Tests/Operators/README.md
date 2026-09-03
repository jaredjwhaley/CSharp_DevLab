# Operators

Operators combine, compare, assign, or transform values. Operand types determine what an operator means.

## Syntax

```csharp
// Integer operands produce integer division; the fractional part is discarded.
int quotient = 7 / 2;      // 3
int remainder = 7 % 2;     // 1; % is the remainder operator.
double precise = 7 / 2.0;  // 3.5; 2.0 makes this floating-point division.

int age = 20;
bool hasTicket = true;
// >= compares values; && requires both conditions to be true.
// && skips its right operand when its left operand is false.
bool eligible = age >= 18 && hasTicket; // true

// condition ? whenTrue : whenFalse selects one value.
string label = eligible ? "Enter" : "Wait"; // "Enter"

int total = 2 + 3 * 4;      // 14: multiplication happens before addition.
int grouped = (2 + 3) * 4;  // 20: parentheses change the evaluation grouping.
total += 1;                // Same assignment effect here as total = total + 1.
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
