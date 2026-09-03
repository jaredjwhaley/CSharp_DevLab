# Methods

Methods name reusable operations, accept parameters, and return results or perform actions.

## Syntax

```csharp
// A method declaration names the return type, method, and parameter types.
// => gives a single expression as its body; its value becomes the result.
int Add(int left, int right) => left + right;
int sum = Add(2, 3); // Parentheses invoke the method; arguments supply 2 and 3.

// An optional parameter has a default. Named arguments identify parameters
// explicitly and can make calls clearer when arguments have similar types.
string Greet(string name, string greeting = "Hello") => $"{greeting}, {name}";
string message = Greet(name: "Ada"); // "Hello, Ada"

// params permits separate arguments, which this declaration receives as an array.
int Sum(params int[] values) => values.Sum();
int total = Sum(1, 2, 3); // 6; Sum() returns 0 for this implementation.

// ref passes the caller's variable by reference; it must already be assigned.
void Increment(ref int value) => value++;
int count = 2;
Increment(ref count); // count is now 3.

// out lets the called method assign a result to a caller variable.
bool valid = int.TryParse("42", out int parsed); // true; parsed is 42.

// in gives readonly access to the argument variable inside the method.
int Double(in int value) => value * 2;
int doubled = Double(in count); // 6; count remains 3.
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
