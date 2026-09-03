# Methods

Methods name reusable operations, accept parameters, and return results or perform actions.

## Syntax

```csharp
int Add(int a, int b) => a + b;
void Increment(ref int value) => value++;
bool valid = int.TryParse("42", out int result);
```

## How the examples work

Tests demonstrate return values, overload selection, optional/named arguments, params arrays, ref mutation, out assignment, in readonly access, and recursion with a base case.

Read [MethodsTests.cs](../Tests/MethodsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use methods to express one operation clearly, isolate repeated logic, and create testable boundaries.

## Best practices

Prefer returned values over hidden state changes. Overloads must differ in parameters, not just return type. Use ref/out/in deliberately; in prevents parameter reassignment but does not make a referenced object immutable. Bound recursion to prevent stack exhaustion.

## Related reading

- [Delegates](../Delegates/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
