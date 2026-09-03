namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates DataTypesAndVariables with isolated, repeatable examples.</summary>
public class DataTypesAndVariablesTests
{
    /// <summary>Shows that var infers a concrete type from its initializer.</summary>
    [Fact]
    public void InferencePreservesStaticType()
    {
        var count = 3;
        count += 2;
        Assert.IsType<int>(count);
        Assert.Equal(5, count);
    }

    /// <summary>Contrasts decimal arithmetic and the default values of value and reference types.</summary>
    [Fact]
    public void LiteralsAndDefaults()
    {
        decimal total = 0.1m + 0.2m;
        Assert.Equal(0.3m, total);
        Assert.Equal(0, default(int));
        Assert.False(default(bool));
        Assert.Null(default(string));
    }
}
