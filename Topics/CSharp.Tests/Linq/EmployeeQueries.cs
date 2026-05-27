using DevLab.CSharp.Common;

namespace DevLab.CSharp.Linq;

public static class EmployeeQueries
{
    public static IEnumerable<Employee> GetValidEmployees(
        IEnumerable<Person> people,
        IEnumerable<Employee> employees)
    {
        return employees.Join(people, e => e.PersonId, p => p.Id, (e, p) => e);
    }

    public static IEnumerable<Employee> GetEmployeesWithoutPeople(
        IEnumerable<Person> people,
        IEnumerable<Employee> employees)
    {
        return employees.Where(e => !people.Any(p => p.Id == e.PersonId));
    }

    public static IEnumerable<Employee> GetActiveEmployees(
        IEnumerable<Person> people,
        IEnumerable<Employee> employees)
    {
        return employees.Where( e => e.IsActive);
    }

    public static bool AreThereAnyActiveEmployees(
        IEnumerable<Employee> employees)
    {
        return employees.Any(e => e.IsActive);
    }
}