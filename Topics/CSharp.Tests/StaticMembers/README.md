# StaticMembers

Static members belong to a type rather than a particular instance.

## Syntax

```csharp
public static int Square(int value) => value * value;
public const int DaysPerWeek = 7;
```

## How the examples work

Tests call a static calculation without constructing an object and compare constant and static readonly initialization.

Read [StaticMembersTests.cs](../Tests/StaticMembersTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use static methods for stateless operations and static readonly fields for shared immutable values.

## Best practices

Avoid mutable global state, especially in parallel tests. const values are embedded in consuming assemblies; static readonly values are initialized at runtime. A readonly reference can still point to a mutable object.

## Related reading

- [Classes](../Classes/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
