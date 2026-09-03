namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Dictionaries with isolated, repeatable examples.</summary>
public class DictionariesTests
{
    /// <summary>Retrieves a differently cased key and handles a missing key.</summary>
    [Fact]
    public void LookupUsesChosenComparer()
    {
        var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase) { ["Ada"] = 2 };
        Assert.True(counts.TryGetValue("ADA", out int count));
        Assert.Equal(2, count);
        Assert.False(counts.TryGetValue("Bob", out _));
    }

    /// <summary>Contrasts duplicate-key rejection and replacement.</summary>
    [Fact]
    public void AddAndIndexerHaveDifferentContracts()
    {
        var values = new Dictionary<int, string> { [1] = "first" };
        Assert.Throws<ArgumentException>(() => values.Add(1, "duplicate"));
        values[1] = "replacement";
        Assert.Equal("replacement", values[1]);
        Assert.False(values.TryAdd(1, "ignored"));
    }
}
