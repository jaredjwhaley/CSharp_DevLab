namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Enums with isolated, repeatable examples.</summary>
public class EnumsTests
{
    /// <summary>Combines and removes permissions using bitwise operations.</summary>
    [Fact]
    public void FlagsCombineIndependentBits()
    {
        Access access = Access.Read | Access.Write;
        Assert.True(access.HasFlag(Access.Read));
        access &= ~Access.Write;
        Assert.Equal(Access.Read, access);
    }

    /// <summary>Rejects an unnamed numeric enum value explicitly.</summary>
    [Fact]
    public void ParsingDoesNotGuaranteeDefinedValue()
    {
        Assert.True(Enum.TryParse<Status>("Ready", out var ready));
        Assert.Equal(Status.Ready, ready);
        Assert.True(Enum.TryParse<Status>("99", out var unknown));
        Assert.False(Enum.IsDefined(unknown));
    }

    private enum Status { Unknown = 0, Ready = 1 }
    [Flags]
    private enum Access { None = 0, Read = 1, Write = 2 }
}
