# PropertiesAndEncapsulation

Encapsulation keeps an object responsible for maintaining its own valid state. Properties control access to that state.

## Syntax

```csharp
public decimal Balance { get; private set; }
public string Name { get; init; } = "Unnamed";
```

## How the examples work

A small account exposes a readable balance and a deposit operation that rejects nonpositive amounts. An init property demonstrates construction-time assignment.

Read [PropertiesAndEncapsulationTests.cs](../Tests/PropertiesAndEncapsulationTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use properties for data access and methods for operations with validation or meaningful side effects.

## Best practices

Prefer a private setter when callers should use domain operations. Keep getters inexpensive and predictable. init limits assignment timing; it does not recursively freeze referenced objects.

## Related reading

- [Classes](../Classes/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
