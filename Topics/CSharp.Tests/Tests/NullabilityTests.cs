namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Nullability with isolated, repeatable examples.</summary>
public class NullabilityTests
{
    /// <summary>Safely reads a missing string and supplies a default.</summary>
    [Fact]
    public void ConditionalAccessAndFallback()
    {
        string? name = null;
        Assert.Equal(0, name?.Length ?? 0);
        name ??= "Ada";
        Assert.Equal("Ada", name);
    }

    /// <summary>Shows HasValue, GetValueOrDefault, and the invalid Value access.</summary>
    [Fact]
    public void NullableValuesRepresentAbsence()
    {
        int? count = null;
        Assert.False(count.HasValue);
        Assert.Equal(0, count.GetValueOrDefault());
        // Deliberately demonstrate the runtime failure that nullable analysis warns about.
#pragma warning disable CS8629
        Assert.Throws<InvalidOperationException>(() => count.Value);
#pragma warning restore CS8629
    }

    /// <summary>Rejects a null argument before using it.</summary>
    [Fact]
    public void GuardRejectsMissingInput()
    {
        Assert.Throws<ArgumentNullException>(() => Length(null!));
        Assert.Equal(3, Length("Ada"));
    }

    private static int Length(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return text.Length;
    }
}
