namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Methods with isolated, repeatable examples.</summary>
public class MethodsTests
{
    /// <summary>Selects overloads by parameter types and supplies named optional arguments.</summary>
    [Fact]
    public void OverloadsAndOptionalArguments()
    {
        Assert.Equal(5, Add(2, 3));
        Assert.Equal(5.5m, Add(2m, 3.5m));
        Assert.Equal("Hi, Ada", Greet(name: "Ada", greeting: "Hi"));
        Assert.Equal("Hello, Ada", Greet("Ada"));
        Assert.Equal(6, Sum(1, 2, 3));
        Assert.Equal(0, Sum());
    }

    /// <summary>Contrasts ref, out, and in parameter behavior.</summary>
    [Fact]
    public void ReferenceParameters()
    {
        int value = 2;
        Increment(ref value);
        Assert.Equal(3, value);
        Assert.True(int.TryParse("12", out int parsed));
        Assert.Equal(24, Double(in parsed));
        Assert.Equal(12, parsed);
    }

    /// <summary>Computes factorial and rejects input outside the supported range.</summary>
    [Fact]
    public void RecursionHasBaseCaseAndGuard()
    {
        Assert.Equal(1, Factorial(0));
        Assert.Equal(120, Factorial(5));
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorial(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => Factorial(13));
    }

    private static int Add(int a, int b) => a + b;
    private static decimal Add(decimal a, decimal b) => a + b;
    private static string Greet(string name, string greeting = "Hello") => $"{greeting}, {name}";
    private static int Sum(params int[] values) => values.Sum();
    private static void Increment(ref int value) => value++;
    private static int Double(in int value) => value * 2;
    private static int Factorial(int n)
    {
        // 13! exceeds Int32, so limit both recursion and arithmetic range.
        if (n is < 0 or > 12) throw new ArgumentOutOfRangeException(nameof(n));
        return n == 0 ? 1 : n * Factorial(n - 1);
    }
}
