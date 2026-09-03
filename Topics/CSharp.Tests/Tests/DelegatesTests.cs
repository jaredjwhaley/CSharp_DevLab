using DevLab.CSharp.Delegates;
using FluentAssertions;

namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates method groups, standard delegates, and multicast invocation.</summary>
public class DelegatesTests
{
    /// <summary>
    /// Verifies that a binary delegate invokes Add with both supplied operands.
    /// </summary>
    [Fact]
    public void Delegate_Should_Execute_Addition()
    {
        var calc = new Calculator<int>();

        // Passing Add without parentheses supplies the operation for Execute to invoke.
        var result = calc.Execute(2, 3, Calculator<int>.Add);

        Assert.Equal(5, result);
    }

    /// <summary>
    /// Demonstrates changing the calculation by supplying another method with
    /// the same binary delegate signature.
    /// </summary>
    [Fact]
    public void Delegate_Should_Execute_Multiplication()
    {
        var calc = new Calculator<int>();

        var result = calc.Execute(2, 3, Calculator<int>.Multiply);

        Assert.Equal(6, result);
    }

    /// <summary>
    /// Verifies that the unary Execute overload invokes Negate with one operand.
    /// </summary>
    [Fact]
    public void Delegate_Should_Execute_Negation()
    {
        var calc = new Calculator<int>();

        var result = calc.Execute(5, Calculator<int>.Negate);

        result.Should().Be(-5);
    }

    /// <summary>
    /// Demonstrates substituting Square for Negate through their shared unary
    /// delegate signature.
    /// </summary>
    [Fact]
    public void Delegate_Should_Execute_Square()
    {
        var calc = new Calculator<int>();

        var result = calc.Execute(4, Calculator<int>.Square);

        result.Should().Be(16);
    }

    /// <summary>A multicast function runs every target but returns only the last target's result.</summary>
    [Fact]
    public void Multicast_ReturnsLastResult()
    {
        var calls = new List<string>();
        int First(int value) { calls.Add("first"); return value + 1; }
        int Second(int value) { calls.Add("second"); return value * 2; }
        Func<int, int> operation = First;
        operation += Second;
        Assert.Equal(6, operation(3));
        Assert.Equal(new[] { "first", "second" }, calls);
    }

    /// <summary>Removing a handler creates a new invocation list without modifying an earlier delegate.</summary>
    [Fact]
    public void Delegates_AreImmutableInvocationLists()
    {
        int total = 0;
        void AddOne() => total++;
        void AddTen() => total += 10;
        Action? actions = AddOne;
        actions += AddTen;
        Action snapshot = actions;
        actions -= AddTen;
        actions!();
        Assert.Equal(1, total);
        snapshot();
        Assert.Equal(12, total);
    }

    /// <summary>A throwing target prevents later targets from running during normal multicast invocation.</summary>
    [Fact]
    public void Multicast_StopsAtException()
    {
        bool laterCalled = false;
        Action action = () => throw new InvalidOperationException();
        action += () => laterCalled = true;
        Assert.Throws<InvalidOperationException>(() => action());
        Assert.False(laterCalled);
    }

    /// <summary>Func returns a result, Action returns void, and Predicate returns a Boolean.</summary>
    [Fact]
    public void BuiltInDelegates_AcceptMethodGroups()
    {
        Func<string, string> trim = Trim;
        Predicate<string> blank = string.IsNullOrWhiteSpace;
        var output = new List<string>();
        Action<string> record = output.Add;
        record(trim(" Ada "));
        Assert.Equal("Ada", Assert.Single(output));
        Assert.True(blank(" "));
    }

    private static string Trim(string value) => value.Trim();
}
