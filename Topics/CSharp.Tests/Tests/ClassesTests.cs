namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Classes with isolated, repeatable examples.</summary>
public class ClassesTests
{
    /// <summary>Verifies that changing one instance does not change another.</summary>
    [Fact]
    public void InstancesOwnTheirState()
    {
        var first = new Counter(2);
        var second = new Counter(2);
        first.Increment();
        Assert.Equal(3, first.Value);
        Assert.Equal(2, second.Value);
    }

    /// <summary>Shows that an assigned reference points to the original object.</summary>
    [Fact]
    public void ReferencesCanAlias()
    {
        var first = new Counter(0);
        var alias = first;
        alias.Increment();
        Assert.Same(first, alias);
        Assert.Equal(1, first.Value);
    }

    private sealed class Counter(int initial)
    {
        public int Value { get; private set; } = initial;
        public void Increment() => Value++;
    }
}
