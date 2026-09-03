using System;

namespace DevLab.CSharp.Common;

/// <summary>
/// Represents a person whose details can be shared by topic examples and tests.
/// </summary>
public class Person
{
    /// <summary>
    /// Gets the identifier assigned at construction.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the birth date assigned at construction.
    /// </summary>
    public DateOnly DateOfBirth { get; private set; }

    /// <summary>
    /// Gets or sets the person's first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the person's last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address without format validation.
    /// </summary>
    /// <remarks>
    /// TODO: Add format validation through a value object or the setter if needed.
    /// </remarks>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number without format validation.
    /// </summary>
    /// <remarks>
    /// TODO: Add format validation through a value object or the setter if needed.
    /// </remarks>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets the person's age in completed years as of the current UTC date.
    /// </summary>
    /// <remarks>
    /// The current date is read on each access. Use <see cref="GetAgeOn"/> with
    /// a fixed date for repeatable demonstrations and tests.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The current UTC date precedes <see cref="DateOfBirth"/>.
    /// </exception>
    public int Age => GetAgeOn(DateOnly.FromDateTime(DateTime.UtcNow));

    /// <summary>
    /// Gets the current first and last names joined by a space, with outer whitespace trimmed.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}".Trim();

    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class with personal
    /// details, optional contact information, and an optional identifier.
    /// </summary>
    /// <param name="firstName">The person's first name; must not be null.</param>
    /// <param name="lastName">The person's last name; must not be null.</param>
    /// <param name="dateOfBirth">The person's birth date; must not be null.</param>
    /// <param name="email">The email address; defaults to an empty string. Its format is not validated.</param>
    /// <param name="phoneNumber">The phone number; defaults to an empty string. Its format is not validated.</param>
    /// <param name="id">The identifier to retain, or null to generate a new GUID.</param>
    /// <remarks>
    /// Construction permits future birth dates. Age calculations require an
    /// evaluation date on or after the birth date. Name setters do not repeat
    /// the constructor's null checks.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="firstName"/>, <paramref name="lastName"/>, or
    /// <paramref name="dateOfBirth"/> is null.
    /// </exception>
    public Person(
        string firstName,
        string lastName,
        DateOnly? dateOfBirth,
        string email = "",
        string phoneNumber = "",
        Guid? id = null)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        DateOfBirth = dateOfBirth ?? throw new ArgumentNullException(nameof(dateOfBirth));
        Email = email;
        PhoneNumber = phoneNumber;
        Id = id ?? Guid.NewGuid();
    }

    /// <summary>
    /// Calculates the person's age in completed years on the specified date.
    /// </summary>
    /// <param name="date">The evaluation date, on or after <see cref="DateOfBirth"/>.</param>
    /// <returns>The number of completed years, including zero on the birth date.</returns>
    /// <remarks>
    /// This calculation does not read the system clock. For a February 29 birth,
    /// age increases on March 1 in a non-leap year and February 29 in a leap year.
    /// This is the convention used by these examples.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="date"/> precedes <see cref="DateOfBirth"/>.
    /// </exception>
    /// <example>
    /// <code>
    /// var person = new Person("Alex", "Smith", new DateOnly(2000, 6, 15));
    /// int age = person.GetAgeOn(new DateOnly(2026, 6, 14)); // 25
    /// </code>
    /// </example>
    public int GetAgeOn(DateOnly date)
    {
        if (date < DateOfBirth)
            throw new ArgumentOutOfRangeException(
                nameof(date), date, "The evaluation date must be on or after the birth date.");

        var age = date.Year - DateOfBirth.Year;
        if (date.Month < DateOfBirth.Month ||
            (date.Month == DateOfBirth.Month && date.Day < DateOfBirth.Day))
        {
            age--;
        }

        return age;
    }
}
