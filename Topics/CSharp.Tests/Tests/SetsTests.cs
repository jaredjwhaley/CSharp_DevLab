namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Sets with isolated, repeatable examples.</summary>
public class SetsTests
{
    /// <summary>Rejects a duplicate under case-insensitive comparison.</summary>
    [Fact]
    public void UniquenessUsesComparer()
    {
        var tags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        Assert.True(tags.Add("CSharp"));
        Assert.False(tags.Add("csharp"));
        Assert.Single(tags);
    }

    /// <summary>Computes intersection, union, and difference.</summary>
    [Fact]
    public void SetOperationsMutateReceiver()
    {
        var values = new HashSet<int> { 1, 2, 3 };
        values.IntersectWith(new[] { 2, 3, 4 });
        Assert.True(values.SetEquals(new[] { 2, 3 }));
        values.UnionWith(new[] { 4 });
        values.ExceptWith(new[] { 3 });
        Assert.True(values.SetEquals(new[] { 2, 4 }));
        Assert.Equal(new[] { 1, 2, 3 }, new SortedSet<int> { 3, 1, 2 });
    }
}
