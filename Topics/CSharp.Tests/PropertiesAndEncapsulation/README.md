# PropertiesAndEncapsulation

Encapsulation keeps an object responsible for maintaining its own valid state. Properties control access to that state.

## Syntax

```csharp
// These declarations go inside an Account class.
// get reads the value. private set restricts assignment to Account's own code.
public decimal Balance { get; private set; }

// init allows assignment during initialization but not normal later assignment.
public string Name { get; init; } = "Unnamed";

// An expression-bodied getter calculates a value instead of storing another flag.
public bool IsEmpty => Balance == 0;

// A method centralizes validation before changing the protected state.
public void Deposit(decimal amount)
{
    if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
    Balance += amount;
}

// Caller code uses an object initializer for Name, then a method for changes:
// var account = new Account { Name = "Savings" };
// account.Deposit(25m); // Balance becomes 25; IsEmpty becomes false.
// account.Balance = -1; // Does not compile: the setter is private.
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
