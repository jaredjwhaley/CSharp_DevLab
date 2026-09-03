namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Exceptions with isolated, repeatable examples.</summary>
public class ExceptionsTests
{
    /// <summary>Checks both exception type and parameter name.</summary>
    [Fact]
    public void GuardIdentifiesBadParameter()
    {
        var error = Assert.Throws<ArgumentOutOfRangeException>(() => RequirePositive(0));
        Assert.Equal("value", error.ParamName);
    }

    /// <summary>Selects a catch with a filter and always runs finally.</summary>
    [Fact]
    public void FilterAndFinally()
    {
        bool caught = false, cleaned = false;
        try { throw new InvalidOperationException("retryable"); }
        catch (InvalidOperationException ex) when (ex.Message == "retryable") { caught = true; }
        finally { cleaned = true; }
        Assert.True(caught);
        Assert.True(cleaned);
    }

    /// <summary>Demonstrates throw without constructing a replacement exception.</summary>
    [Fact]
    public void RethrowPreservesException()
    {
        var original = new InvalidOperationException("failure");
        var actual = Assert.Throws<InvalidOperationException>((Action)(() =>
        {
            try { throw original; }
            catch (InvalidOperationException) { throw; }
        }));
        Assert.Same(original, actual);
    }

    private static void RequirePositive(int value)
    {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
    }
}
