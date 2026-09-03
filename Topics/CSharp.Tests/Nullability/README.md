# Nullability

Null represents a missing reference or an absent nullable value. Nullable annotations help the compiler detect unsafe dereferences.

## Syntax

```csharp
string? name = null;
int length = name?.Length ?? 0;
int? count = null;
```

## How the examples work

Tests distinguish nullable value types from non-nullable values, use conditional access and coalescing, and guard a required argument.

Read [NullabilityTests.cs](../Tests/NullabilityTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use nullable types when absence is meaningful, such as an optional middle name or a measurement not yet taken.

## Best practices

Enable nullable analysis. The ! operator only suppresses warnings; it does not validate anything at runtime. Validate external inputs and distinguish absent values from empty strings and zero.

## Related reading

- [Exceptions](../Exceptions/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
