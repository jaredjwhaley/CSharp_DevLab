using System.Text.RegularExpressions;

namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates RegularExpressions with isolated, repeatable examples.</summary>
public class RegularExpressionsTests
{
    /// <summary>Matches a whole identifier and reads named captures.</summary>
    [Fact]
    public void NamedGroupsExtractValidatedInput()
    {
        var pattern = new Regex(@"\A(?<code>[A-Z]{2})-(?<number>[0-9]+)\z", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(100));
        var match = pattern.Match("AB-123");
        Assert.True(match.Success);
        Assert.Equal("AB", match.Groups["code"].Value);
        Assert.Equal("123", match.Groups["number"].Value);
        Assert.DoesNotMatch(pattern, "AB-123\n");
    }

    /// <summary>Uses capture groups in replacement and escapes metacharacters in literal input.</summary>
    [Fact]
    public void ReplacementAndLiteralEscaping()
    {
        var pattern = new Regex(@"(?<last>\w+), (?<first>\w+)", RegexOptions.None, TimeSpan.FromMilliseconds(100));
        Assert.Equal("Ada Lovelace", pattern.Replace("Lovelace, Ada", "${first} ${last}"));
        string literal = "a+b.txt";
        var exact = new Regex(@"\A" + Regex.Escape(literal) + @"\z", RegexOptions.None, TimeSpan.FromMilliseconds(100));
        Assert.Matches(exact, literal);
        Assert.DoesNotMatch(exact, "abXtxt");
    }

    /// <summary>Makes the timeout contract explicit for a supported nonbacktracking pattern.</summary>
    [Fact]
    public void FiniteTimeoutAndNonBacktracking()
    {
        var timeout = TimeSpan.FromMilliseconds(100);
        var pattern = new Regex(@"\A[a-z]+\z", RegexOptions.NonBacktracking, timeout);
        Assert.Equal(timeout, pattern.MatchTimeout);
        Assert.Matches(pattern, "abc");
        Assert.DoesNotMatch(pattern, "abc1");
    }
}
