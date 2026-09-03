namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates LambdasAndClosures with isolated, repeatable examples.</summary>
public class LambdasAndClosuresTests
{
    /// <summary>Distinguishes returning, action, and predicate delegates.</summary>
    [Fact]
    public void StandardDelegateShapes()
    {
        Func<int, int> square = static x => x * x;
        Predicate<int> positive = x => x > 0;
        int recorded = 0;
        Action<int> record = x => recorded = x;
        record(square(3));
        Assert.Equal(9, recorded);
        Assert.True(positive(recorded));
    }

    /// <summary>Shows that a captured variable is read at invocation time.</summary>
    [Fact]
    public void ClosureObservesChangedVariable()
    {
        int offset = 2;
        Func<int, int> add = x => x + offset;
        offset = 10;
        Assert.Equal(13, add(3));
    }

    /// <summary>Contrasts a shared for variable with independent copies.</summary>
    [Fact]
    public void LoopCaptureNeedsPerIterationCopy()
    {
        var shared = new List<Func<int>>();
        var copied = new List<Func<int>>();
        for (int i = 0; i < 3; i++)
        {
            shared.Add(() => i);
            int snapshot = i;
            copied.Add(() => snapshot);
        }
        Assert.Equal(new[] { 3, 3, 3 }, shared.Select(f => f()));
        Assert.Equal(new[] { 0, 1, 2 }, copied.Select(f => f()));
    }
}
