# TypeConversions

Conversions translate values between types; parsing interprets text as a value.

## Syntax

```csharp
int count = 42;
long wide = count; // Implicit conversion: every int value fits in a long.

// (int) explicitly requests conversion. checked throws OverflowException
// if the value is outside int's range instead of allowing wraparound.
int narrow = checked((int)wide); // 42
int truncated = (int)3.9;       // 3: a cast discards the fraction toward zero.

// Parsing interprets text; casting does not turn a string into a number.
// out declares a variable that receives the parsed result.
bool valid = int.TryParse("42", out int parsed); // true; parsed is 42
bool invalid = int.TryParse("forty-two", out int failed); // false; failed is 0

// Boxing stores a value in an object. Unboxing must use its original type.
object boxed = count;
int unboxed = (int)boxed; // 42; (long)boxed would throw InvalidCastException.
```

## How the examples work

The examples show implicit widening, explicit truncation, overflow detection, invariant parsing, and boxing/unboxing. A cast does not parse text; unboxing must use the exact boxed value type.

Read [TypeConversionsTests.cs](../Tests/TypeConversionsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use parsing at input boundaries and explicit conversions when an API requires another numeric representation.

## Best practices

Use TryParse for expected invalid input, select a culture deliberately, and use checked when overflow must fail. Do not assume a narrowing cast preserves fractional data.

## Related reading

- [ValueAndReferenceTypes](../ValueAndReferenceTypes/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
