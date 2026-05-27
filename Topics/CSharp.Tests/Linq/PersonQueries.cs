using System.Collections.ObjectModel;
using DevLab.CSharp.Common;

namespace DevLab.CSharp.Linq;

public static class PersonQueries
{
    public static IEnumerable<Person> GetPeople(Collection<Person> people)
    {
        return people;
    }

    public static IEnumerable<string> GetFullNames(Collection<Person> people)
    {
        return people.Select(p => p.FullName);
    }

    public static IEnumerable<string> GetAlphabeticalFullNames(Collection<Person> people)
    {
        return people
            .OrderBy(p => p.FullName)
            .Select(p => p.FullName);
    }

    public static IEnumerable<Person> GetAdults(Collection<Person> people)
    {
        return people.Where(p => p.Age >= 18);
    }

    public static IEnumerable<Person> GetOldestPeople(Collection<Person> people)
    {
        int maxAge = people.Max(p => p.Age);

        return people.Where(p => p.Age == maxAge);
    }
}