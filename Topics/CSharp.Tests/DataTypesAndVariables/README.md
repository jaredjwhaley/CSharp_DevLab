# DataTypesAndVariables

Types describe which values a variable can hold and which operations are legal. Variables name storage; constants name values that cannot change.

## Syntax

```csharp
int count = 3;
var name = "Ada"; // Still statically typed as string.
const decimal taxRate = 0.05m;
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
