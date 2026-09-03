namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Structs with isolated, repeatable examples.</summary>
public class StructsTests
{
    /// <summary>Copies an immutable value and changes only the copy.</summary>
    [Fact]
    public void CopyAndEquality()
    {
        var point = new Point(1, 2);
        var moved = point with { X = 3 };
        Assert.Equal(new Point(1, 2), point);
        Assert.Equal(new Point(3, 2), moved);
        Assert.NotEqual(point, moved);
    }

    /// <summary>Shows the default value without explicit constructor arguments.</summary>
    [Fact]
    public void DefaultIsZeroInitialized()
    {
        Point point = default;
        Assert.Equal(0, point.X);
        Assert.Equal(0, point.Y);
    }

    private readonly record struct Point(int X, int Y);
}
