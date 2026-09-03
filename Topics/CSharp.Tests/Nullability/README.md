# Nullability

Null represents a missing reference or an absent nullable value. Nullable annotations help the compiler detect unsafe dereferences.

## Syntax

```csharp
// ? after a reference type marks a value that may be null.
string? name = null;

// ?. accesses Length only when name is nonnull; otherwise it produces null.
// ?? uses the value on its right only when the left-hand value is null.
int length = name?.Length ?? 0; // 0, without dereferencing a missing string.

// ??= assigns a fallback only when the variable currently contains null.
name ??= "Ada"; // name is now "Ada".

// int? is Nullable<int>: an integer value OR an absent value.
int? count = null;
bool supplied = count.HasValue; // false
int fallback = count.GetValueOrDefault(); // 0; count itself remains null.
// count.Value would throw here. The ! operator only suppresses compiler
// warnings; it does not make a missing value safe to access at runtime.
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
