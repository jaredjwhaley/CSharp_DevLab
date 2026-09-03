using DevLab.CSharp.Common;

namespace DevLab.CSharp.Linq;

/// <summary>Adds explicit-date and birth-date alternatives to the original age queries.</summary>
public static partial class PersonQueries
{
    /// <summary>Filters adults using completed years on a specified date.</summary>
    /// <param name="people">The people to examine.</param>
    /// <param name="date">The fixed date used by every age calculation.</param>
    /// <returns>A deferred sequence of adults in input order; empty input produces no results.</returns>
    /// <remarks>
    /// Where streams on enumeration. Source mutations remain visible, but the evaluation date
    /// is fixed. A person born after the date causes GetAgeOn to throw during enumeration.
    /// </remarks>
    /// <exception cref="ArgumentNullException">The source is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">During enumeration, a person is not yet born on the evaluation date.</exception>
    public static IEnumerable<Person> GetAdultsOn(IEnumerable<Person> people, DateOnly date)
        => people.Where(p => p.GetAgeOn(date) >= 18);

    /// <summary>Captures the greatest integer age now and defers the matching filter.</summary>
    /// <param name="people">A repeatable sequence of people.</param>
    /// <param name="date">The fixed date on which ages are calculated.</param>
    /// <returns>All people matching the captured age, or a fixed empty sequence for empty input.</returns>
    /// <remarks>
    /// Like GetOldestPeople, this deliberately demonstrates mixed timing: Max runs at the call,
    /// Where runs later. Added older people do not change the captured maximum. Distinct birth
    /// dates can tie in completed years. A future birth date throws when its age is evaluated.
    /// </remarks>
    /// <exception cref="ArgumentNullException">The source is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">A person is not yet born on the evaluation date, at the call or later enumeration.</exception>
    public static IEnumerable<Person> GetOldestPeopleOn(IEnumerable<Person> people, DateOnly date)
    {
        int? maximum = people.Max(p => (int?)p.GetAgeOn(date));
        return maximum.HasValue
            ? people.Where(p => p.GetAgeOn(date) == maximum.Value)
            : Enumerable.Empty<Person>();
    }

    /// <summary>Materializes the source and returns all people sharing its earliest birth date.</summary>
    /// <param name="people">The people to read once.</param>
    /// <returns>An immediately evaluated array of ties, or an empty array for empty input.</returns>
    /// <remarks>
    /// This alternative defines oldest chronologically instead of by integer age. It enumerates
    /// the input once, then computes over the local array. Membership is fixed on return, but
    /// the Person objects remain shared references; this is not a deep copy.
    /// </remarks>
    /// <exception cref="ArgumentNullException">The source is null.</exception>
    public static Person[] GetPeopleWithEarliestBirthDate(IEnumerable<Person> people)
    {
        var snapshot = people.ToArray();
        if (snapshot.Length == 0) return [];
        var earliest = snapshot.Min(p => p.DateOfBirth);
        return snapshot.Where(p => p.DateOfBirth == earliest).ToArray();
    }
}
