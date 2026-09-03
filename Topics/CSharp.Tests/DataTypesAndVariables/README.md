# DataTypesAndVariables

Types describe which values a variable can hold and which operations are legal. Variables name storage; constants name values that cannot change.

## Syntax

```csharp
// The type before the name determines the values and operations allowed.
int count = 3;           // Whole number.
bool isReady = true;    // Boolean: true or false.
string name = "Ada";    // Text; double quotes delimit a string literal.

// var asks the compiler to infer the type from the initializer.
// inferredCount is still an int; it cannot later hold a string.
var inferredCount = 3;
inferredCount += 2; // Now 5; += adds to the existing value.

// const requires a compile-time value and prevents later reassignment.
// The m suffix makes 0.05 a decimal literal rather than a double literal.
const decimal taxRate = 0.05m;
decimal tax = 100m * taxRate; // 5m

// default(T) produces the default value of a type.
int zero = default(int);       // 0
string? missing = default;    // null; string? permits a missing reference.
```

## How the examples work

The tests contrast inferred and explicit types, numeric literals, default values, and local reassignment. A local variable must be definitely assigned before use; fields and array elements receive defaults.

Read [DataTypesAndVariablesTests.cs](../Tests/DataTypesAndVariablesTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Choose types when modeling counts, money, text, flags, dates, and identifiers. Use decimal for base-10 financial quantities and double for many scientific calculations.

## Best practices

Use meaningful names, keep variables near their use, and choose the smallest useful scope. var is inference, not dynamic typing. Numeric types have finite ranges; default values are not necessarily valid domain values.

## Related reading

- [TypeConversions](../TypeConversions/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
