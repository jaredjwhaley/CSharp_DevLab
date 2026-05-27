using System.Collections.ObjectModel;
using DevLab.CSharp.Common;
using DevLab.CSharp.Linq;
using Xunit;

namespace DevLab.CSharp.Tests.Linq;

public class LinqTests
{
    private Collection<Person> _people;
    private List<Employee> _employees;

    public LinqTests()
    {
        // Create dummy people
        _people = new Collection<Person>
        {
            new Person("Alice", "Smith", new DateOnly(1990, 1, 1)),
            new Person("Bob", "Jones", new DateOnly(1985, 1, 1)),
            new Person("Charlie", "Brown", new DateOnly(2005, 1, 1)), // under 18
            new Person("Dana", "White", new DateOnly(1975, 1, 1))
        };

        // Create employees linked to people
        _employees = new List<Employee>
        {
            new Employee(_people[0].Id, 25),
            new Employee(_people[1].Id, 30),
            new Employee(_people[2].Id, 20)
        };

        // Make one inactive
        _employees[2].Deactivate();
    }

    // -----------------------------
    // PersonQueries Tests
    // -----------------------------

    [Fact]
    public void GetPeople_ShouldReturnAllPeople()
    {
        var result = PersonQueries.GetPeople(_people).ToList();

        Assert.Equal(_people.Count, result.Count);
    }

    [Fact]
    public void GetFullNames_ShouldReturnAllFullNames()
    {
        var result = PersonQueries.GetFullNames(_people).ToList();

        Assert.Contains("Alice Smith", result);
        Assert.Contains("Bob Jones", result);
    }

    [Fact]
    public void GetAlphabeticalFullNames_ShouldReturnSortedNames()
    {
        var result = PersonQueries.GetAlphabeticalFullNames(_people).ToList();

        var sorted = result.OrderBy(x => x).ToList();

        Assert.Equal(sorted, result);
    }

    [Fact]
    public void GetAdults_ShouldExcludeMinors()
    {
        var result = PersonQueries.GetAdults(_people).ToList();

        Assert.DoesNotContain(result, p => p.Age < 18);
    }

    [Fact]
    public void GetOldestPeople_ShouldReturnOldestPerson()
    {
        var result = PersonQueries.GetOldestPeople(_people).ToList();

        int maxAge = _people.Max(p => p.Age);

        Assert.All(result, p => Assert.Equal(maxAge, p.Age));
    }

    // -----------------------------
    // EmployeeQueries Tests
    // -----------------------------

    [Fact]
    public void GetValidEmployees_ShouldMatchEmployeesToPeople()
    {
        var result = EmployeeQueries
            .GetValidEmployees(_people, _employees)
            .ToList();

        Assert.Equal(_employees.Count, result.Count);
    }

    [Fact]
    public void GetActiveEmployees_ShouldReturnOnlyActiveEmployees()
    {
        var result = EmployeeQueries
            .GetActiveEmployees(_people, _employees)
            .ToList();

        Assert.All(result, e => Assert.True(e.IsActive));
    }

    [Fact]
    public void AreThereAnyActiveEmployees_ShouldReturnTrue()
    {
        var result = EmployeeQueries
            .AreThereAnyActiveEmployees(_employees);

        Assert.True(result);
    }

    [Fact]
    public void AreThereAnyActiveEmployees_ShouldReturnFalse_WhenNoneActive()
    {
        foreach (var e in _employees)
            e.Deactivate();

        var result = EmployeeQueries
            .AreThereAnyActiveEmployees(_employees);

        Assert.False(result);
    }
}