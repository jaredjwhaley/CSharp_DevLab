using System.Globalization;
using System.Text;

namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Strings with isolated, repeatable examples.</summary>
public class StringsTests
{
    /// <summary>Verifies that replacing text leaves the original intact.</summary>
    [Fact]
    public void StringsAreImmutable()
    {
        string original = "cat";
        string changed = original.Replace("c", "b");
        Assert.Equal("cat", original);
        Assert.Equal("bat", changed);
        bool sameIdentifier = string.Equals("FILE", "file", StringComparison.OrdinalIgnoreCase);
        Assert.True(sameIdentifier);
    }

    /// <summary>Demonstrates interpolation, verbatim paths, and invariant formatting.</summary>
    [Fact]
    public void FormattingAndEscaping()
    {
        var name = "Ada";
        Assert.Equal("Hello, Ada", $"Hello, {name}");
        Assert.Equal("C:\\temp", @"C:\temp");
        Assert.Equal("12.50", 12.5m.ToString("F2", CultureInfo.InvariantCulture));
    }

    /// <summary>Builds delimited text without a trailing separator.</summary>
    [Fact]
    public void BuilderAccumulatesText()
    {
        var builder = new StringBuilder();
        foreach (var word in new[] { "one", "two" })
        {
            if (builder.Length > 0) builder.Append(", ");
            builder.Append(word);
        }
        Assert.Equal("one, two", builder.ToString());
    }
}
