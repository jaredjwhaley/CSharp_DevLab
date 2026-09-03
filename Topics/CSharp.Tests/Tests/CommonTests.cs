using DevLab.CSharp.Common;
using System;
using Xunit;

namespace DevLab.CSharp.Tests;

/// <summary>
/// Demonstrates the shared person model's age calculation using fixed dates.
/// </summary>
public class CommonTests
{
    /// <summary>
    /// Verifies completed years before, on, and after an ordinary birthday.
    /// </summary>
    /// <param name="year">The evaluation year.</param>
    /// <param name="month">The evaluation month.</param>
    /// <param name="day">The evaluation day.</param>
    /// <param name="expectedAge">The expected number of completed years.</param>
    [Theory]
    [InlineData(2000, 6, 15, 0)]
    [InlineData(2001, 6, 14, 0)]
    [InlineData(2026, 1, 1, 25)]
    [InlineData(2026, 6, 14, 25)]
    [InlineData(2026, 6, 15, 26)]
    [InlineData(2026, 6, 16, 26)]
    [InlineData(2026, 12, 31, 26)]
    public void GetAgeOn_OrdinaryBirthday_ReturnsCompletedYears(
        int year, int month, int day, int expectedAge)
    {
        var person = new Person("Alex", "Smith", new DateOnly(2000, 6, 15));

        var age = person.GetAgeOn(new DateOnly(year, month, day));

        Assert.Equal(expectedAge, age);
    }

    /// <summary>
    /// Verifies that February 29 births age on March 1 in non-leap years.
    /// </summary>
    /// <param name="year">The evaluation year.</param>
    /// <param name="month">The evaluation month.</param>
    /// <param name="day">The evaluation day.</param>
    /// <param name="expectedAge">The expected number of completed years.</param>
    [Theory]
    [InlineData(2000, 2, 29, 0)]
    [InlineData(2023, 2, 28, 22)]
    [InlineData(2023, 3, 1, 23)]
    [InlineData(2024, 2, 28, 23)]
    [InlineData(2024, 2, 29, 24)]
    [InlineData(2024, 3, 1, 24)]
    [InlineData(2100, 2, 28, 99)]
    [InlineData(2100, 3, 1, 100)]
    public void GetAgeOn_LeapDayBirthday_UsesDocumentedConvention(
        int year, int month, int day, int expectedAge)
    {
        var person = new Person("Alex", "Smith", new DateOnly(2000, 2, 29));

        var age = person.GetAgeOn(new DateOnly(year, month, day));

        Assert.Equal(expectedAge, age);
    }

    /// <summary>
    /// Verifies that an evaluation date before birth is rejected rather than producing a negative age.
    /// </summary>
    [Fact]
    public void GetAgeOn_DateBeforeBirth_ThrowsArgumentOutOfRangeException()
    {
        var person = new Person("Alex", "Smith", new DateOnly(2000, 6, 15));
        var date = new DateOnly(2000, 6, 14);

        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => person.GetAgeOn(date));

        Assert.Equal("date", exception.ParamName);
        Assert.Equal(date, Assert.IsType<DateOnly>(exception.ActualValue));
    }

    /// <summary>
    /// Demonstrates that evaluating another date does not change the result for a fixed date.
    /// </summary>
    [Fact]
    public void GetAgeOn_FixedDate_RemainsRepeatable()
    {
        var person = new Person("Alex", "Smith", new DateOnly(2000, 6, 15));
        var date = new DateOnly(2026, 6, 14);

        Assert.Equal(25, person.GetAgeOn(date));
        Assert.Equal(40, person.GetAgeOn(new DateOnly(2040, 6, 15)));
        Assert.Equal(25, person.GetAgeOn(date));
    }
}
