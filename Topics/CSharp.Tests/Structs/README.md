# Structs

Structs are value types: assignment copies the value. Small immutable values are a common use.

## Syntax

```csharp
// Declare this type at namespace scope. struct means value semantics;
// record adds generated value equality; readonly restricts instance mutation.
// The positional declaration supplies an (int X, int Y) constructor and properties.
readonly record struct Point(int X, int Y);

// Inside a method:
// var point = new Point(1, 2);
// var copy = point;                 // Copies the value, not an object reference.
// var moved = point with { X = 3 }; // Copies the value with X changed to 3.
// bool equal = point == copy;       // true: generated equality compares X and Y.
// point is still (1, 2); moved is (3, 2).
// Point origin = default;           // (0, 0): default zero-initializes its fields.
```

## How the examples work

Tests show record-struct value equality, copying with modifications, and the zero-initialized default value. record struct supplies generated equality and related members; a plain struct requires more manual work.

Read [StructsTests.cs](../Tests/StructsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use structs for small values such as coordinates, measurements, or identifiers when identity is unimportant.

## Best practices

Prefer readonly structs and account for default(T), which can bypass validating constructors. Copies are shallow: reference fields still refer to shared objects. Do not describe all structs as living on the stack.

## Related reading

- [ValueAndReferenceTypes](../ValueAndReferenceTypes/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
