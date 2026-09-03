using System.Collections.ObjectModel;
using DevLab.CSharp.Common;

namespace DevLab.CSharp.Linq;

/// <summary>
/// Demonstrates LINQ projection, ordering, filtering, and aggregation over people.
/// </summary>
public static partial class PersonQueries
{
    /// <summary>Exposes the supplied collection as an enumerable sequence.</summary>
    /// <param name="people">The source collection.</param>
    /// <returns>The same collection, including when it is empty.</returns>
    /// <remarks>No LINQ operator, enumeration, or copy is performed. Later changes remain visible.</remarks>
    public static IEnumerable<Person> GetPeople(Collection<Person> people) => people;

    /// <summary>Projects each person to a full name using Select.</summary>
    /// <param name="people">The source collection.</param>
    /// <returns>One name per person in source order, or an empty sequence for empty input.</returns>
    /// <remarks>Execution is deferred. Names are read again on each enumeration.</remarks>
    public static IEnumerable<string> GetFullNames(Collection<Person> people)
    {
        return people.Select(p => p.FullName);
    }

    /// <summary>Orders people by full name using OrderBy, then projects names using Select.</summary>
    /// <param name="people">The source collection.</param>
    /// <returns>Names in ascending default string-comparer order, or an empty sequence.</returns>
    /// <remarks>
    /// Execution is deferred, but ordering buffers the source before producing results.
    /// The default string comparison is culture-sensitive. Each enumeration repeats the query.
    /// </remarks>
    public static IEnumerable<string> GetAlphabeticalFullNames(Collection<Person> people)
    {
        return people.OrderBy(p => p.FullName).Select(p => p.FullName);
    }

    /// <summary>Filters people aged at least eighteen using Where.</summary>
    /// <param name="people">The source collection.</param>
    /// <returns>Adults in source order, or an empty sequence if none qualify.</returns>
    /// <remarks>
    /// Execution is deferred and streaming. Age is evaluated using the current UTC date
    /// when each person is examined, rather than when this method is called.
    /// </remarks>
    public static IEnumerable<Person> GetAdults(Collection<Person> people)
    {
        return people.Where(p => p.Age >= 18);
    }

    /// <summary>Finds the greatest integer age using Max, then filters all ties using Where.</summary>
    /// <param name="people">The source collection.</param>
    /// <returns>
    /// People whose age matches the captured maximum, in source order.
    /// Empty input returns an empty sequence.
    /// </returns>
    /// <remarks>
    /// Oldest means greatest whole-year age, not earliest birth date; distinct birthdays can tie.
    /// Max enumerates immediately. Its nullable projection returns null for empty input,
    /// whereas Max over non-nullable integers throws for empty input.
    /// The returned Where filter is deferred and re-reads the source on each enumeration,
    /// but does not recalculate the maximum. Changes to the collection or ages between
    /// the call and enumeration can therefore produce results that are no longer the oldest.
    /// Empty input returns a fixed empty sequence, even if people are added later.
    /// </remarks>
    public static IEnumerable<Person> GetOldestPeople(Collection<Person> people)
    {
        int? maxAge = people.Max(p => (int?)p.Age);

        return maxAge.HasValue
            ? people.Where(p => p.Age == maxAge.Value)
            : Enumerable.Empty<Person>();
    }
}
