using System.Text;

namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Lists with isolated, repeatable examples.</summary>
public class ListsTests
{
    /// <summary>Changes an ordered list and verifies its resulting contents.</summary>
    [Fact]
    public void AddInsertAndRemove()
    {
        var values = new List<int>(10) { 1, 3 };
        values.Insert(1, 2);
        values.Add(2);
        Assert.True(values.Remove(2));
        Assert.Equal(new[] { 1, 3, 2 }, values);
        Assert.Equal(3, values.Count);
        Assert.True(values.Capacity >= values.Count);
    }

    /// <summary>Shows that copying a list does not clone its objects.</summary>
    [Fact]
    public void ContainerCopyIsShallow()
    {
        var original = new List<StringBuilder> { new("A") };
        var copy = original.ToList();
        copy[0].Append("B");
        copy.Add(new("C"));
        Assert.Single(original);
        Assert.Equal("AB", original[0].ToString());
    }
}
