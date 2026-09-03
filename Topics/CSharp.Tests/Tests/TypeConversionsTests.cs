using System.Globalization;

namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates TypeConversions with isolated, repeatable examples.</summary>
public class TypeConversionsTests
{
    /// <summary>Shows safe widening and truncation toward zero.</summary>
    [Fact]
    public void WideningAndTruncation()
    {
        int count = 12;
        long wide = count;
        Assert.Equal(12L, wide);
        Assert.Equal(-3, (int)-3.9);
    }

    /// <summary>Separates invalid text from checked numeric overflow.</summary>
    [Fact]
    public void OverflowAndParsing()
    {
        long tooLarge = (long)int.MaxValue + 1;
        Assert.Throws<OverflowException>(() => checked((int)tooLarge));
        Assert.True(decimal.TryParse("12.50", NumberStyles.Number, CultureInfo.InvariantCulture, out var value));
        Assert.Equal(12.5m, value);
        Assert.False(int.TryParse("twelve", out _));
    }

    /// <summary>Demonstrates that unboxing is not numeric conversion.</summary>
    [Fact]
    public void UnboxingRequiresOriginalType()
    {
        object boxed = 42;
        Assert.Equal(42, (int)boxed);
        Assert.Throws<InvalidCastException>(() => (long)boxed);
    }
}
