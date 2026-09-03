namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates StaticMembers with isolated, repeatable examples.</summary>
public class StaticMembersTests
{
    /// <summary>Invokes a pure operation directly through its type.</summary>
    [Fact]
    public void StaticMethodNeedsNoInstance()
    {
        Assert.Equal(16, MathExample.Square(4));
        Assert.Equal(7, MathExample.DaysPerWeek);
    }

    /// <summary>Reads a runtime-initialized shared value.</summary>
    [Fact]
    public void ReadonlyRuntimeValue()
    {
        Assert.Equal(new DateOnly(2020, 1, 1), MathExample.Epoch);
    }

    private static class MathExample
    {
        public const int DaysPerWeek = 7;
        public static readonly DateOnly Epoch = new(2020, 1, 1);
        public static int Square(int value) => value * value;
    }
}
