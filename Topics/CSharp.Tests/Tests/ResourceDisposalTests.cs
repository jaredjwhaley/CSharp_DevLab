namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates ResourceDisposal with isolated, repeatable examples.</summary>
public class ResourceDisposalTests
{
    /// <summary>Releases an owned resource after leaving a using block.</summary>
    [Fact]
    public void UsingDisposesOnSuccess()
    {
        var resource = new Resource();
        using (resource) { Assert.False(resource.IsDisposed); }
        Assert.True(resource.IsDisposed);
        resource.Dispose();
        Assert.True(resource.IsDisposed);
    }

    /// <summary>Releases the resource while an exception leaves the block.</summary>
    [Fact]
    public void UsingDisposesOnFailure()
    {
        var resource = new Resource();
        Assert.Throws<InvalidOperationException>((Action)(() =>
        {
            using (resource) { throw new InvalidOperationException(); }
        }));
        Assert.True(resource.IsDisposed);
    }

    /// <summary>Verifies scope-based disposal with a real stream.</summary>
    [Fact]
    public void UsingDeclarationLastsThroughScope()
    {
        MemoryStream stream;
        {
            using var owned = new MemoryStream();
            stream = owned;
            owned.WriteByte(42);
            Assert.True(stream.CanRead);
        }
        Assert.False(stream.CanRead);
    }

    private sealed class Resource : IDisposable
    {
        public bool IsDisposed { get; private set; }
        public void Dispose() => IsDisposed = true;
    }
}
