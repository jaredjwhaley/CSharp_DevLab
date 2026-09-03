namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Polymorphism with isolated, repeatable examples.</summary>
public class PolymorphismTests
{
    /// <summary>Calculates areas through one shared abstraction.</summary>
    [Fact]
    public void InterfaceDispatchSelectsImplementation()
    {
        IShape[] shapes = [new Rectangle(3, 4), new Square(5)];
        Assert.Equal(new[] { 12, 25 }, shapes.Select(s => s.Area));
    }

    /// <summary>Shows compile-time overload choice without dynamic binding.</summary>
    [Fact]
    public void OverloadResolutionUsesDeclaredType()
    {
        object value = "text";
        Assert.Equal("object", Describe(value));
        Assert.Equal("string", Describe((string)value));
    }

    private interface IShape { int Area { get; } }
    private sealed class Rectangle(int width, int height) : IShape { public int Area => width * height; }
    private sealed class Square(int side) : IShape { public int Area => side * side; }
    private static string Describe(object value) => "object";
    private static string Describe(string value) => "string";
}
