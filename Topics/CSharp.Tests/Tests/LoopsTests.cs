namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Loops with isolated, repeatable examples.</summary>
public class LoopsTests
{
    /// <summary>Compares indexed and sequential sums.</summary>
    [Fact]
    public void ForAndForeachTraverseValues()
    {
        int[] values = [2, 4, 6];
        int indexed = 0, sequential = 0;
        for (int i = 0; i < values.Length; i++) indexed += values[i];
        foreach (int value in values) sequential += value;
        Assert.Equal(12, indexed);
        Assert.Equal(indexed, sequential);
    }

    /// <summary>Shows that do executes once even when its condition starts false.</summary>
    [Fact]
    public void WhileAndDoHaveDifferentMinimums()
    {
        bool repeat = false;
        int before = 0, after = 0;
        while (repeat) before++;
        do { after++; } while (repeat);
        Assert.Equal(0, before);
        Assert.Equal(1, after);
    }

    /// <summary>Skips even values and stops before six.</summary>
    [Fact]
    public void BreakAndContinueControlTraversal()
    {
        var visited = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            if (i == 6) break;
            if (i % 2 == 0) continue;
            visited.Add(i);
        }
        Assert.Equal(new[] { 1, 3, 5 }, visited);
    }
}
