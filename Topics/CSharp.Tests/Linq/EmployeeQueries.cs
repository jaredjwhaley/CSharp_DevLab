using DevLab.CSharp.Common;

namespace DevLab.CSharp.Linq;

/// <summary>Demonstrates joins, existence checks, and filtering over employee records.</summary>
public static class EmployeeQueries
{
    /// <summary>Uses an inner Join to associate employees with matching person identifiers.</summary>
    /// <param name="people">Person records to match by identifier.</param>
    /// <param name="employees">Employee records to examine.</param>
    /// <returns>
    /// One employee result per matching employee/person pair, in employee order and then
    /// matching-person order. Returns an empty sequence if either source is empty or no pairs match.
    /// </returns>
    /// <remarks>
    /// Execution is deferred. During enumeration, Join builds a lookup from people when needed.
    /// Multiple people with the same identifier repeat the employee in the output.
    /// This demonstrates join multiplicity; it does not validate other fields or require active status.
    /// Each enumeration repeats the join. Use GetEmployeesWithPeople for an existence-only filter.
    /// </remarks>
    public static IEnumerable<Employee> GetValidEmployees(
        IEnumerable<Person> people,
        IEnumerable<Employee> employees)
    {
        return employees.Join(people, e => e.PersonId, p => p.Id, (e, p) => e);
    }

    /// <summary>Filters employees using Where and an Any check for a matching person.</summary>
    /// <param name="people">Person records to search for each employee.</param>
    /// <param name="employees">Employee records to examine.</param>
    /// <returns>Matching employee entries in source order, or an empty sequence if none match.</returns>
    /// <remarks>
    /// The outer filter is deferred. During enumeration, Any searches people for each employee
    /// and stops at the first match. Duplicate matching people do not multiply results;
    /// duplicate entries in employees are still preserved. People may be enumerated repeatedly.
    /// Either source being empty produces no results. Each enumeration repeats the query.
    /// </remarks>
    public static IEnumerable<Employee> GetEmployeesWithPeople(
        IEnumerable<Person> people,
        IEnumerable<Employee> employees)
    {
        return employees.Where(e => people.Any(p => p.Id == e.PersonId));
    }

    /// <summary>Filters employees using Where and a negated Any check for a matching person.</summary>
    /// <param name="people">Person records to search for each employee.</param>
    /// <param name="employees">Employee records to examine.</param>
    /// <returns>
    /// Unmatched employee entries in source order. Empty people includes every employee;
    /// empty employees produces an empty sequence.
    /// </returns>
    /// <remarks>
    /// The filter is deferred. Any executes for each employee during enumeration and stops
    /// at the first match. People may be enumerated repeatedly. Each enumeration repeats the query.
    /// </remarks>
    public static IEnumerable<Employee> GetEmployeesWithoutPeople(
        IEnumerable<Person> people,
        IEnumerable<Employee> employees)
    {
        return employees.Where(e => !people.Any(p => p.Id == e.PersonId));
    }

    /// <summary>Filters employees by IsActive using Where.</summary>
    /// <param name="employees">Employee records to examine.</param>
    /// <returns>Active entries in source order, or an empty sequence if none are active.</returns>
    /// <remarks>
    /// Execution is deferred and streaming; current status is checked on each enumeration.
    /// A matching person is not required. Empty input produces an empty sequence.
    /// </remarks>
    public static IEnumerable<Employee> GetActiveEmployees(IEnumerable<Employee> employees)
    {
        return employees.Where(e => e.IsActive);
    }

    /// <summary>Uses Any to determine whether at least one employee is active.</summary>
    /// <param name="employees">Employee records to examine.</param>
    /// <returns>True if an active employee exists; false for empty input or all-inactive records.</returns>
    /// <remarks>
    /// Execution is immediate and stops at the first active employee. The returned Boolean
    /// does not change if employee status changes later.
    /// </remarks>
    public static bool AreThereAnyActiveEmployees(IEnumerable<Employee> employees)
    {
        return employees.Any(e => e.IsActive);
    }
}
