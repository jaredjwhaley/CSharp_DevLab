namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Enumeration with isolated, repeatable examples.</summary>
public class EnumerationTests
{
    /// <summary>Shows when the iterator body first runs.</summary>
    [Fact]
    public void IteratorRunsOnDemand()
    {
        int produced = 0;
        IEnumerable<int> Generate()
        {
            produced++; yield return 10;
            produced++; yield return 20;
        }
        var sequence = Generate();
        Assert.Equal(0, produced);
        Assert.Equal(10, sequence.First());
        Assert.Equal(1, produced);
    }

    /// <summary>Verifies iterator finally execution after breaking out of foreach.</summary>
    [Fact]
    public void EarlyExitDisposesIterator()
    {
        bool cleaned = false;
        IEnumerable<int> Generate()
        {
            try { yield return 1; yield return 2; }
            finally { cleaned = true; }
        }
        foreach (var value in Generate()) { Assert.Equal(1, value); break; }
        Assert.True(cleaned);
    }

    /// <summary>Demonstrates why structural changes during traversal are unsafe.</summary>
    [Fact]
    public void ListMutationInvalidatesEnumerator()
    {
        var values = new List<int> { 1, 2 };
        using var iterator = values.GetEnumerator();
        Assert.True(iterator.MoveNext());
        values.Add(3);
        Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }
}
