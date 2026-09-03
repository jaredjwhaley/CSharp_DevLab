# Polymorphism

Polymorphism lets the same call produce behavior appropriate to the actual object behind a common contract.

## Syntax

```csharp
interface IShape { int Area { get; } }

// These independent implementations expose the same property contract.
class Square : IShape
{
    private readonly int _side;
    public Square(int side) => _side = side;
    public int Area => _side * _side;
}
class Rectangle : IShape
{
    private readonly int _width, _height;
    public Rectangle(int width, int height) { _width = width; _height = height; }
    public int Area => _width * _height;
}

// Caller code uses one interface while runtime dispatch chooses each implementation:
// IShape[] shapes = [new Square(3), new Rectangle(3, 4)];
// foreach (IShape shape in shapes)
//     Console.WriteLine(shape.Area); // 9, then 12; no concrete-type checks needed.
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
