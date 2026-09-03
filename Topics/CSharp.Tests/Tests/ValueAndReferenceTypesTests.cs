using System.Text;

namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates ValueAndReferenceTypes with isolated, repeatable examples.</summary>
public class ValueAndReferenceTypesTests
{
    /// <summary>Contrasts independent numeric copies and shared object state.</summary>
    [Fact]
    public void ValuesCopyReferencesAlias()
    {
        int original = 1;
        int copy = original;
        copy++;
        Assert.Equal(1, original);
        Assert.Equal(2, copy);
        var text = new StringBuilder("A");
        var alias = text;
        alias.Append("B");
        Assert.Equal("AB", text.ToString());
    }

    /// <summary>Mutates the object but does not replace the caller reference.</summary>
    [Fact]
    public void ReferenceParameterIsPassedByValue()
    {
        var text = new StringBuilder("A");
        MutateAndReassign(text);
        Assert.Equal("AB", text.ToString());
    }

    /// <summary>Demonstrates shallow copying of a value containing a reference.</summary>
    [Fact]
    public void StructReferenceFieldsAreShared()
    {
        var first = new Container(new StringBuilder("A"));
        var second = first;
        second.Text.Append("B");
        Assert.Equal("AB", first.Text.ToString());
    }

    private readonly record struct Container(StringBuilder Text);
    private static void MutateAndReassign(StringBuilder text)
    {
        text.Append("B");
        text = new StringBuilder("Replacement");
    }
}
