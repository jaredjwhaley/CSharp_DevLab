# Polymorphism

Polymorphism lets the same call produce behavior appropriate to the actual object behind a common contract.

## Syntax

```csharp
IShape shape = new Rectangle(3, 4);
double area = shape.Area;
```

## How the examples work

Tests call different implementations through one interface and select overloads using the compile-time type to contrast the two mechanisms.

Read [PolymorphismTests.cs](../Tests/PolymorphismTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use polymorphism when callers should work with multiple kinds of objects without repeatedly checking their concrete types.

## Best practices

Honor the shared contract in every implementation. Runtime virtual/interface dispatch differs from ordinary overload resolution, which uses compile-time argument types.

## Related reading

- [Inheritance](../Inheritance/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
