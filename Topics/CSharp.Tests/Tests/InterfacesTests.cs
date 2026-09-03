namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Interfaces with isolated, repeatable examples.</summary>
public class InterfacesTests
{
    /// <summary>Substitutes behavior without changing the caller.</summary>
    [Fact]
    public void ImplementationsShareContract()
    {
        Assert.Equal("ADA", Apply(new Upper(), "Ada"));
        Assert.Equal("[Ada]", Apply(new Brackets(), "Ada"));
    }

    /// <summary>Accesses an explicitly implemented member through its contract.</summary>
    [Fact]
    public void ExplicitImplementationUsesInterfaceReference()
    {
        IFormatter formatter = new Brackets();
        Assert.Equal("[x]", formatter.Format("x"));
    }

    private interface IFormatter { string Format(string value); }
    private sealed class Upper : IFormatter
    {
        public string Format(string value) => value.ToUpperInvariant();
    }
    private sealed class Brackets : IFormatter
    {
        string IFormatter.Format(string value) => $"[{value}]";
    }
    private static string Apply(IFormatter formatter, string value) => formatter.Format(value);
}
