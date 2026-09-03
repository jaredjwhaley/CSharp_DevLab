namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Composition with isolated, repeatable examples.</summary>
public class CompositionTests
{
    /// <summary>Changes report output by supplying another formatter.</summary>
    [Fact]
    public void CollaboratorChangesBehavior()
    {
        Assert.Equal("HELLO", new Report(new UpperFormatter()).Render("hello"));
        Assert.Equal("hello", new Report(new PlainFormatter()).Render("hello"));
    }

    /// <summary>Rejects a report without its required dependency.</summary>
    [Fact]
    public void RequiredCollaboratorCannotBeMissing()
    {
        Assert.Throws<ArgumentNullException>(() => new Report(null!));
    }

    private interface IFormatter { string Format(string value); }
    private sealed class UpperFormatter : IFormatter { public string Format(string value) => value.ToUpperInvariant(); }
    private sealed class PlainFormatter : IFormatter { public string Format(string value) => value; }
    private sealed class Report
    {
        private readonly IFormatter _formatter;
        public Report(IFormatter formatter)
        {
            ArgumentNullException.ThrowIfNull(formatter);
            _formatter = formatter;
        }
        public string Render(string text) => _formatter.Format(text);
    }
}
