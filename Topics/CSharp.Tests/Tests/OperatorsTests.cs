namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Operators with isolated, repeatable examples.</summary>
public class OperatorsTests
{
    /// <summary>Contrasts integer and floating-point division and operator precedence.</summary>
    [Fact]
    public void ArithmeticUsesOperandTypes()
    {
        Assert.Equal(3, 7 / 2);
        Assert.Equal(1, 7 % 2);
        Assert.Equal(3.5, 7 / 2.0);
        Assert.Equal(14, 2 + 3 * 4);
        Assert.Equal(20, (2 + 3) * 4);
    }

    /// <summary>Verifies that a false left operand prevents evaluation of the right operand.</summary>
    [Fact]
    public void ShortCircuitSkipsWork()
    {
        int calls = 0;
        bool Check() { calls++; return true; }
        bool left = false;
        Assert.False(left && Check());
        Assert.Equal(0, calls);
        Assert.False(left & Check());
        Assert.Equal(1, calls);
    }

    /// <summary>Uses AND to inspect bits and OR to combine them.</summary>
    [Fact]
    public void BitwiseMaskSelectsFlags()
    {
        int read = 1, write = 2;
        int permissions = read | write;
        Assert.Equal(read, permissions & read);
        Assert.Equal(4, 1 << 2);
    }
}
