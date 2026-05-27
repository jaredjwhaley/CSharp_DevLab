using System;
using System.Net;

namespace DevLab.CSharp.Common
{
    /// <summary>
    /// Represents a person in the system. Used for testing other classes.
    /// </summary>
    public class Person
    {
        // Identifier
        public Guid Id { get; private set; }

        // Core personal info
        public DateOnly DateOfBirth { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // TODO: Add format verification for email and phone number if needed in the future.
        // This could be done through a value object or by adding validation logic in the setters for these properties.
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Calculated properties
        public int Age {
            get
            {
                var today = DateOnly.FromDateTime(DateTime.UtcNow);
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age)) age--;
                return age;
            }
        }
        public string FullName { get => $"{FirstName} {LastName}".Trim(); }

        /// <summary>
        /// Initializes a new instance of the Person class with the specified personal details, contact information, and
        /// optional identifiers.
        /// </summary>
        /// <param name="firstName">The first name of the person. Cannot be null.</param>
        /// <param name="lastName">The last name of the person. Cannot be null.</param>
        /// <param name="dateOfBirth">The date of birth of the person. Cannot be null.</param>
        /// <param name="email">The email address of the person. If not specified, defaults to an empty string.</param>
        /// <param name="phoneNumber">The phone number of the person. If not specified, defaults to an empty string.</param>
        /// <param name="id">An optional unique identifier for the person. If not specified, a new GUID is generated.</param>
        /// <exception cref="ArgumentNullException">Thrown if firstName, lastName, dateOfBirth, or address is null.</exception>
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
    }
}
