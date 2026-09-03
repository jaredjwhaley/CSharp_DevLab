namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Conditionals with isolated, repeatable examples.</summary>
public class ConditionalsTests
{
    /// <summary>Selects both pass and fail branches.</summary>
    [Fact]
    public void IfElseAndConditionalExpression()
    {
        Assert.Equal("Pass", Grade(60));
        Assert.Equal("Fail", Grade(59));
        int score = 80;
        Assert.Equal("High", score >= 80 ? "High" : "Low");
    }

    /// <summary>Matches null, integer ranges, and a fallback.</summary>
    [Fact]
    public void SwitchPatternsHandleTypesAndRanges()
    {
        Assert.Equal("Missing", Describe(null));
        Assert.Equal("Small", Describe(3));
        Assert.Equal("Other", Describe("3"));
        Assert.Equal("Other", Describe(10));
    }

    /// <summary>Shows a statement switch with explicit break.</summary>
    [Fact]
    public void SwitchStatementSelectsAction()
    {
        int day = 6;
        string label;
        switch (day)
        {
            case 6:
            case 7: label = "Weekend"; break;
            default: label = "Weekday"; break;
        }
        Assert.Equal("Weekend", label);
    }

    private static string Grade(int score)
    {
        if (score >= 60) return "Pass";
        else return "Fail";
    }
    private static string Describe(object? value) => value switch
    {
        null => "Missing",
        int n when n is > 0 and < 10 => "Small",
        _ => "Other"
    };
}
