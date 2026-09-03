using DevLab.CSharp.Linq;
using System.Collections.ObjectModel;
using DevLab.CSharp.Common;

namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates query operators, model queries, empty contracts, and execution timing.</summary>
public class LinqTests
{
    private static readonly DateOnly AsOf = new(2026, 6, 15);
    private readonly Collection<Person> _people;
    private readonly List<Employee> _employees;

    /// <summary>Creates independent people and employee fixtures for each test.</summary>
    public LinqTests()
    {
        var today = AsOf;

        // Every age-based example uses the same explicit date; the system clock is irrelevant.
        _people = new Collection<Person>
        {
            new Person("Alice", "Smith", today.AddYears(-30)),
            new Person("Bob", "Jones", today.AddYears(-35)),
            new Person("Charlie", "Brown", today.AddYears(-10)), // under 18
            new Person("Dana", "White", today.AddYears(-45))
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

    /// <summary>Verifies that the sequence contains every source person in order.</summary>
    [Fact]
    public void GetPeople_ShouldReturnAllPeople()
    {
        var result = PersonQueries.GetPeople(_people).ToList();

        Assert.Equal(_people.ToArray(), result.ToArray());
    }

    /// <summary>Verifies that Select returns every expected full name.</summary>
    [Fact]
    public void GetFullNames_ShouldReturnAllFullNames()
    {
        var result = PersonQueries.GetFullNames(_people).ToList();

        Assert.Equal(new[] { "Alice Smith", "Bob Jones", "Charlie Brown", "Dana White" }, result);
    }

    /// <summary>Verifies ascending name order from deliberately unsorted input.</summary>
    [Fact]
    public void GetAlphabeticalFullNames_ShouldReturnSortedNames()
    {
        var first = _people[0];
        _people.RemoveAt(0);
        _people.Add(first);

        var result = PersonQueries.GetAlphabeticalFullNames(_people).ToList();

        Assert.Equal(new[] { "Alice Smith", "Bob Jones", "Charlie Brown", "Dana White" }, result);
    }

    /// <summary>Verifies that the adult filter includes all adults and excludes the minor.</summary>
    [Fact]
    public void GetAdults_ShouldExcludeMinors()
    {
        var result = PersonQueries.GetAdultsOn(_people, AsOf).ToList();

        Assert.Equal(new[] { _people[0], _people[1], _people[3] }, result);
    }

    /// <summary>Verifies the exact oldest person rather than allowing an empty result.</summary>
    [Fact]
    public void GetOldestPeople_ShouldReturnOldestPerson()
    {
        var result = PersonQueries.GetOldestPeopleOn(_people, AsOf).ToList();

        Assert.Same(_people[3], Assert.Single(result));
    }

    // -----------------------------
    // EmployeeQueries Tests
    // -----------------------------

    /// <summary>Verifies that every linked employee produces one join result in this fixture.</summary>
    [Fact]
    public void GetValidEmployees_ShouldMatchEmployeesToPeople()
    {
        var result = EmployeeQueries
            .GetValidEmployees(_people, _employees)
            .ToList();

        Assert.Equal(_employees.ToArray(), result.ToArray());
    }

    /// <summary>Verifies that active filtering includes exactly the active employees.</summary>
    [Fact]
    public void GetActiveEmployees_ShouldReturnOnlyActiveEmployees()
    {
        var result = EmployeeQueries
            .GetActiveEmployees(_employees)
            .ToList();

        Assert.Equal(new[] { _employees[0], _employees[1] }, result);
    }

    /// <summary>Verifies that Any returns true when an active employee exists.</summary>
    [Fact]
    public void AreThereAnyActiveEmployees_ShouldReturnTrue()
    {
        var result = EmployeeQueries
            .AreThereAnyActiveEmployees(_employees);

        Assert.True(result);
    }

    /// <summary>Verifies that Any returns false when all employees are inactive.</summary>
    [Fact]
    public void AreThereAnyActiveEmployees_ShouldReturnFalse_WhenNoneActive()
    {
        foreach (var e in _employees)
            e.Deactivate();

        var result = EmployeeQueries
            .AreThereAnyActiveEmployees(_employees);

        Assert.False(result);
    }

    /// <summary>Verifies that all person queries accept an empty collection.</summary>
    [Fact]
    public void PersonQueries_EmptyInput_ReturnEmptySequences()
    {
        var people = new Collection<Person>();

        Assert.Empty(PersonQueries.GetPeople(people));
        Assert.Empty(PersonQueries.GetFullNames(people));
        Assert.Empty(PersonQueries.GetAlphabeticalFullNames(people));
        Assert.Empty(PersonQueries.GetAdultsOn(people, AsOf));
        Assert.Empty(PersonQueries.GetOldestPeopleOn(people, AsOf));
    }

    /// <summary>Verifies that different birthdays can tie for greatest integer age.</summary>
    [Fact]
    public void GetOldestPeople_SameAgeDifferentBirthdays_ReturnsBoth()
    {
        var birthday = AsOf.AddYears(-40);
        var first = new Person("First", "Person", birthday);
        var earlier = new Person("Earlier", "Person", birthday.AddDays(-1));
        var people = new Collection<Person> { first, earlier };

        Assert.Equal(new[] { first, earlier }, PersonQueries.GetOldestPeopleOn(people, AsOf).ToArray());
    }

    /// <summary>Demonstrates that Max runs at the call while Where reads the source later.</summary>
    [Fact]
    public void GetOldestPeople_SourceChanges_FilterUsesCapturedMaximum()
    {
        var originalOldest = _people[3];
        var result = PersonQueries.GetOldestPeopleOn(_people, AsOf);
        var sameAge = new Person("Same", "Age", originalOldest.DateOfBirth);
        var older = new Person("Even", "Older", originalOldest.DateOfBirth.AddYears(-10));
        _people.Add(sameAge);
        _people.Add(older);

        Assert.Equal(new[] { originalOldest, sameAge }, result.ToArray());
    }

    /// <summary>Verifies that an initially empty oldest query remains empty after additions.</summary>
    [Fact]
    public void GetOldestPeople_InitiallyEmpty_ReturnsFixedEmptySequence()
    {
        var people = new Collection<Person>();
        var result = PersonQueries.GetOldestPeopleOn(people, AsOf);
        people.Add(_people[0]);

        Assert.Empty(result);
    }

    /// <summary>Demonstrates that Select observes changed names when enumerated again.</summary>
    [Fact]
    public void GetFullNames_NameChanges_AreVisibleOnEnumeration()
    {
        var result = PersonQueries.GetFullNames(_people);
        Assert.Equal("Alice Smith", result.First());
        _people[0].FirstName = "Alicia";

        Assert.Equal("Alicia Smith", result.First());
    }

    /// <summary>Distinguishes join pairs from existence filtering with duplicate person identifiers.</summary>
    [Fact]
    public void EmployeeQueries_DuplicatePeople_JoinMultipliesButAnyDoesNot()
    {
        var person = _people[0];
        _people.Add(new Person("Duplicate", "Identifier", person.DateOfBirth, id: person.Id));

        Assert.Equal(
            new[] { _employees[0], _employees[0], _employees[1], _employees[2] },
            EmployeeQueries.GetValidEmployees(_people, _employees).ToArray());
        Assert.Equal(_employees.ToArray(),
            EmployeeQueries.GetEmployeesWithPeople(_people, _employees).ToArray());
    }

    /// <summary>Verifies that existence filtering preserves duplicate employee source entries.</summary>
    [Fact]
    public void GetEmployeesWithPeople_DuplicateEmployees_PreservesEntries()
    {
        _employees.Add(_employees[0]);

        Assert.Equal(_employees.ToArray(),
            EmployeeQueries.GetEmployeesWithPeople(_people, _employees).ToArray());
    }

    /// <summary>Verifies matching and unmatched queries without treating inactivity as an invalid link.</summary>
    [Fact]
    public void EmployeeQueries_MissingPerson_SeparatesMatchedAndUnmatchedEmployees()
    {
        var orphan = new Employee(Guid.NewGuid(), 25);
        _employees.Add(orphan);

        Assert.Equal(_employees.Take(3).ToArray(),
            EmployeeQueries.GetValidEmployees(_people, _employees).ToArray());
        Assert.Equal(_employees.Take(3).ToArray(),
            EmployeeQueries.GetEmployeesWithPeople(_people, _employees).ToArray());
        Assert.Same(orphan, Assert.Single(
            EmployeeQueries.GetEmployeesWithoutPeople(_people, _employees)));
        Assert.Contains(orphan, EmployeeQueries.GetActiveEmployees(_employees));
    }

    /// <summary>Verifies that empty people excludes matches but includes every unmatched employee.</summary>
    [Fact]
    public void EmployeeQueries_EmptyPeople_ReturnsOnlyUnmatchedEmployees()
    {
        var people = Array.Empty<Person>();

        Assert.Empty(EmployeeQueries.GetValidEmployees(people, _employees));
        Assert.Empty(EmployeeQueries.GetEmployeesWithPeople(people, _employees));
        Assert.Equal(_employees.ToArray(),
            EmployeeQueries.GetEmployeesWithoutPeople(people, _employees).ToArray());
    }

    /// <summary>Verifies empty employee sequences and the false identity of Any on empty input.</summary>
    [Fact]
    public void EmployeeQueries_EmptyEmployees_ReturnEmptySequencesAndFalse()
    {
        var employees = Array.Empty<Employee>();

        Assert.Empty(EmployeeQueries.GetValidEmployees(_people, employees));
        Assert.Empty(EmployeeQueries.GetEmployeesWithPeople(_people, employees));
        Assert.Empty(EmployeeQueries.GetEmployeesWithoutPeople(_people, employees));
        Assert.Empty(EmployeeQueries.GetActiveEmployees(employees));
        Assert.False(EmployeeQueries.AreThereAnyActiveEmployees(employees));
    }

    /// <summary>Contrasts a deferred Where filter with an immediately evaluated Any Boolean.</summary>
    [Fact]
    public void ActiveEmployeeQueries_StatusChanges_DemonstrateExecutionTiming()
    {
        var active = EmployeeQueries.GetActiveEmployees(_employees);
        var anyActive = EmployeeQueries.AreThereAnyActiveEmployees(_employees);
        foreach (var employee in _employees)
            employee.Deactivate();

        Assert.True(anyActive);
        Assert.Empty(active);
        Assert.False(EmployeeQueries.AreThereAnyActiveEmployees(_employees));
    }

    /// <summary>Query syntax and extension-method syntax express the same filtering and projection.</summary>
    [Fact]
    public void QueryAndMethodSyntax_ProduceSameResults()
    {
        int[] values = [1, 2, 3, 4];
        var query = from n in values where n % 2 == 0 select n * 10;
        var methods = values.Where(n => n % 2 == 0).Select(n => n * 10);
        Assert.Equal(new[] { 20, 40 }, query);
        Assert.Equal(query, methods);
    }

    /// <summary>Select preserves nesting while SelectMany flattens child sequences.</summary>
    [Fact]
    public void ProjectionAndFlattening_HaveDifferentShapes()
    {
        int[][] rows = [ [1, 2], [], [3] ];
        var nested = rows.Select(row => row.Select(n => n * 2)).ToArray();
        Assert.Equal(3, nested.Length);
        Assert.Empty(nested[1]);
        Assert.Equal(new[] { 2, 4, 6 }, rows.SelectMany(row => row, (_, n) => n * 2));
        Assert.Empty(Array.Empty<int[]>().SelectMany(row => row));
    }

    /// <summary>ThenBy adds a tie breaker instead of replacing the primary sort.</summary>
    [Fact]
    public void Ordering_UsesPrimaryAndSecondaryKeys()
    {
        var entries = new[] { (Team: "B", Name: "Ada"), (Team: "A", Name: "Zoe"), (Team: "A", Name: "Bob") };
        var names = entries.OrderBy(e => e.Team, StringComparer.Ordinal)
            .ThenBy(e => e.Name, StringComparer.Ordinal).Select(e => e.Name);
        Assert.Equal(new[] { "Bob", "Zoe", "Ada" }, names);
        Assert.Equal(new[] { 3, 2, 1 }, new[] { 1, 3, 2 }.OrderByDescending(n => n));
    }

    /// <summary>GroupBy creates deferred groups; ToLookup immediately creates a reusable index.</summary>
    [Fact]
    public void GroupingAndLookup_DifferInTiming()
    {
        var words = new List<string> { "ant", "ape", "bee" };
        var groups = words.GroupBy(w => w[0]);
        var lookup = words.ToLookup(w => w[0]);
        words.Add("bat");
        Assert.Equal(new[] { "bee", "bat" }, groups.Single(g => g.Key == 'b'));
        Assert.Equal(new[] { "bee" }, lookup['b']);
        Assert.Empty(lookup['z']);
        Assert.Empty(Array.Empty<string>().GroupBy(w => w.Length));
    }

    /// <summary>GroupJoin plus DefaultIfEmpty retains an outer row with no inner match.</summary>
    [Fact]
    public void LeftJoin_PreservesUnmatchedRowsAndMatchingPairs()
    {
        var departments = new[] { (Id: 1, Name: "Engineering"), (Id: 2, Name: "Support") };
        var staff = new[] { (Department: 1, Name: "Ada"), (Department: 1, Name: "Bob") };
        var grouped = departments.GroupJoin(staff, d => d.Id, s => s.Department,
            (d, matches) => new { d.Name, Staff = matches.Select(s => s.Name) });
        var rows = grouped.SelectMany(g => g.Staff.DefaultIfEmpty("(unassigned)"),
            (g, name) => $"{g.Name}: {name}");
        Assert.Equal(new[] { "Engineering: Ada", "Engineering: Bob", "Support: (unassigned)" }, rows);
    }

    /// <summary>Aggregates execute immediately and differ on empty nonnullable input.</summary>
    [Fact]
    public void Aggregates_DefineEmptyContracts()
    {
        int[] values = [2, 4, 6];
        Assert.Equal(3, values.Count());
        Assert.Equal(12, values.Sum());
        Assert.Equal(4.0, values.Average());
        Assert.Equal(2, values.Min());
        Assert.Equal(6, values.Max());
        Assert.Equal(48, values.Aggregate(1, (product, n) => product * n));
        int[] empty = [];
        Assert.Equal(0, empty.Sum());
        Assert.Equal(1, empty.Aggregate(1, (product, n) => product * n));
        Assert.Throws<InvalidOperationException>(() => empty.Average());
        Assert.Throws<InvalidOperationException>(() => empty.Min());
        Assert.Throws<InvalidOperationException>(() => empty.Max());
        Assert.Throws<InvalidOperationException>(() => empty.Aggregate((a, b) => a + b));
        Assert.Null(empty.Select(n => (int?)n).Max());
    }

    /// <summary>First accepts several matches; Single enforces exactly one, even with OrDefault.</summary>
    [Fact]
    public void ElementOperators_EnforceCardinality()
    {
        int[] values = [2, 4, 6];
        Assert.Equal(2, values.First());
        Assert.Equal(6, values.Last());
        Assert.Equal(4, values.ElementAt(1));
        Assert.Equal(4, values.Single(n => n == 4));
        Assert.Throws<InvalidOperationException>(() => values.Single());
        Assert.Throws<InvalidOperationException>(() => values.SingleOrDefault());
        int[] empty = [];
        Assert.Throws<InvalidOperationException>(() => empty.First());
        Assert.Throws<InvalidOperationException>(() => empty.Single());
        Assert.Equal(0, empty.FirstOrDefault());
        Assert.Equal(-1, empty.FirstOrDefault(-1));
        Assert.Equal(0, empty.SingleOrDefault());
        Assert.Throws<ArgumentOutOfRangeException>(() => values.ElementAt(3));
    }

    /// <summary>Any short-circuits and All returns true for an empty sequence.</summary>
    [Fact]
    public void Quantifiers_ShortCircuitAndHandleEmptyInput()
    {
        int visited = 0;
        bool found = new[] { 1, 2, 3 }.Any(n => { visited++; return n == 2; });
        Assert.True(found);
        Assert.Equal(2, visited);
        Assert.False(Array.Empty<int>().Any());
        Assert.True(Array.Empty<int>().All(n => n > 0));
        Assert.True(new[] { 1, 2 }.Contains(2));
        Assert.False(new[] { 1, -2 }.All(n => n > 0));
    }

    /// <summary>Set operators remove duplicates while Concat preserves every entry.</summary>
    [Fact]
    public void SetOperators_RespectEqualityAndMultiplicity()
    {
        int[] left = [1, 1, 2], right = [2, 3];
        Assert.Equal(new[] { 1, 2 }, left.Distinct());
        Assert.Equal(new[] { 1, 2, 3 }, left.Union(right).OrderBy(n => n));
        Assert.Equal(new[] { 2 }, left.Intersect(right));
        Assert.Equal(new[] { 1 }, left.Except(right));
        Assert.Equal(new[] { 1, 1, 2, 2, 3 }, left.Concat(right));
        Assert.Single(new[] { "Ada", "ADA" }.Distinct(StringComparer.OrdinalIgnoreCase));
        Assert.Empty(left.Intersect(Array.Empty<int>()));
    }

    /// <summary>Skip/Take use positions; While variants stop testing after the first failed predicate.</summary>
    [Fact]
    public void Partitioning_UsesPositionsOrBoundaries()
    {
        int[] values = [1, 2, 5, 1];
        Assert.Equal(new[] { 2, 5 }, values.Skip(1).Take(2));
        Assert.Equal(new[] { 1, 2 }, values.TakeWhile(n => n < 5));
        Assert.Equal(new[] { 5, 1 }, values.SkipWhile(n => n < 5));
        Assert.Empty(values.Skip(20));
        Assert.Empty(values.Take(0));
    }

    /// <summary>A deferred query sees later source changes; a materialized value array does not.</summary>
    [Fact]
    public void DeferredQueryAndSnapshot_ObserveDifferentStates()
    {
        var values = new List<int> { 1, 2 };
        int calls = 0;
        var query = values.Where(n => { calls++; return n > 1; });
        Assert.Equal(0, calls);
        var snapshot = query.ToArray();
        Assert.Equal(2, calls);
        values.Add(3);
        Assert.Equal(new[] { 2, 3 }, query);
        Assert.Equal(new[] { 2 }, snapshot);
        Assert.Equal(5, calls);
    }

    /// <summary>Where streams to a consumer while OrderBy needs all input before yielding ordered results.</summary>
    [Fact]
    public void StreamingAndBuffering_ConsumeDifferentAmounts()
    {
        int visited = 0;
        IEnumerable<int> Source()
        {
            foreach (int n in new[] { 3, 1, 2 }) { visited++; yield return n; }
        }
        Assert.Equal(3, Source().Where(n => n > 0).Take(1).Single());
        Assert.Equal(1, visited);
        visited = 0;
        // Explicit enumeration avoids relying on terminal-operator optimization details.
        using var ordered = Source().OrderBy(n => n).GetEnumerator();
        Assert.True(ordered.MoveNext());
        Assert.Equal(1, ordered.Current);
        Assert.Equal(3, visited);
    }

    /// <summary>Repeated enumeration reruns predicates; iterator failures occur during consumption.</summary>
    [Fact]
    public void ReenumerationAndDeferredExceptions()
    {
        int calls = 0;
        var query = new[] { 1, 2 }.Where(n => { calls++; return n > 0; });
        Assert.Equal(new[] { 1, 2 }, query.ToArray());
        Assert.Equal(new[] { 1, 2 }, query.ToArray());
        Assert.Equal(4, calls);
        var failing = new[] { 1, 0 }.Select(n => 10 / n);
        Assert.Equal(10, failing.First());
        Assert.Throws<DivideByZeroException>(() => failing.ToArray());
    }

    /// <summary>ToDictionary rejects duplicate keys, whereas ToLookup groups them.</summary>
    [Fact]
    public void Materialization_ControlsDuplicateKeys()
    {
        string[] names = ["Ada", "Amy", "Bob"];
        Assert.Throws<ArgumentException>(() => names.ToDictionary(n => n[0]));
        var lookup = names.ToLookup(n => n[0]);
        Assert.Equal(new[] { "Ada", "Amy" }, lookup['A']);
        Assert.Empty(lookup['Z']);
        Assert.Empty(Array.Empty<string>().ToDictionary(n => n));
    }

    /// <summary>OfType skips incompatible objects while Cast throws when it encounters one.</summary>
    [Fact]
    public void TypeOperators_FilterOrRequireCompatibility()
    {
        object[] values = [1, "two", 3];
        Assert.Equal(new[] { 1, 3 }, values.OfType<int>());
        Assert.Throws<InvalidCastException>(() => values.Cast<int>().ToArray());
    }

    /// <summary>Earliest birth date distinguishes birthdays tied in integer age and fixes membership immediately.</summary>
    [Fact]
    public void EarliestBirthDate_IsDifferentFromGreatestIntegerAge()
    {
        var later = new Person("Later", "Birth", new DateOnly(1986, 5, 1));
        var earlier = new Person("Earlier", "Birth", new DateOnly(1986, 4, 1));
        var tie = new Person("Tie", "Birth", earlier.DateOfBirth);
        var people = new List<Person> { later, earlier, tie };
        Assert.Equal(3, PersonQueries.GetOldestPeopleOn(people, AsOf).Count());
        var result = PersonQueries.GetPeopleWithEarliestBirthDate(people);
        people.Clear();
        Assert.Equal(new[] { earlier, tie }, result);
        Assert.Empty(PersonQueries.GetPeopleWithEarliestBirthDate(people));
    }

    /// <summary>Explicit dates make birthday boundaries repeatable and reject a not-yet-born person.</summary>
    [Fact]
    public void AdultsOn_UsesExactBirthdayBoundary()
    {
        var person = new Person("New", "Adult", new DateOnly(2008, 6, 15));
        Assert.Empty(PersonQueries.GetAdultsOn(new[] { person }, AsOf.AddDays(-1)));
        Assert.Same(person, Assert.Single(PersonQueries.GetAdultsOn(new[] { person }, AsOf)));
        var deferred = PersonQueries.GetAdultsOn(new[] { person }, new DateOnly(2000, 1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => deferred.ToArray());
    }
}
