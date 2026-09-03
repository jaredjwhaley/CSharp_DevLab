using System;

namespace DevLab.CSharp.Common;

/// <summary>
/// Represents an employee record associated with a person.
/// </summary>
public sealed class Employee
{
    /// <summary>
    /// Gets the employee identifier assigned at construction.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the associated person's identifier, assigned at construction.
    /// </summary>
    /// <remarks>
    /// A non-empty identifier is required, but the existence of a matching
    /// <see cref="Person"/> record is not checked by this class.
    /// </remarks>
    public Guid PersonId { get; private set; }

    /// <summary>
    /// Gets the hourly pay rate, which can be changed through <see cref="UpdateHourlyRate"/>.
    /// </summary>
    public decimal HourlyRate { get; private set; }

    /// <summary>
    /// Gets whether the employee is active.
    /// </summary>
    /// <remarks>
    /// Employees start active. Use <see cref="Deactivate"/> and <see cref="Reactivate"/>
    /// to change this status.
    /// </remarks>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Initializes a new active <see cref="Employee"/> with the specified person
    /// identifier, hourly pay rate, and optional employee identifier.
    /// </summary>
    /// <param name="personId">The associated person's identifier; must not be <see cref="Guid.Empty"/>.</param>
    /// <param name="hourlyRate">The hourly pay rate; must be greater than or equal to zero.</param>
    /// <param name="id">The employee identifier to retain, or null to generate a new GUID.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="personId"/> is <see cref="Guid.Empty"/> or
    /// <paramref name="hourlyRate"/> is negative.
    /// </exception>
    public Employee(
        Guid personId,
        decimal hourlyRate,
        Guid? id = null)
    {
        if (personId == Guid.Empty)
            throw new ArgumentException("Employee must reference a valid Person.");

        if (hourlyRate < 0)
            throw new ArgumentException("Hourly rate must be greater than or equal to zero.");

        Id = id ?? Guid.NewGuid();
        PersonId = personId;
        HourlyRate = hourlyRate;
        IsActive = true;
    }

    /// <summary>
    /// Replaces the employee's hourly pay rate.
    /// </summary>
    /// <param name="newHourlyRate">The new rate; must be greater than or equal to zero.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="newHourlyRate"/> is negative. The existing rate remains unchanged.
    /// </exception>
    public void UpdateHourlyRate(decimal newHourlyRate)
    {
        if (newHourlyRate < 0)
            throw new ArgumentException("Hourly rate must be greater than or equal to zero.");

        HourlyRate = newHourlyRate;
    }

    /// <summary>
    /// Marks the employee as inactive; calling this again leaves the employee inactive.
    /// </summary>
    public void Deactivate() => IsActive = false;

    /// <summary>
    /// Marks the employee as active; calling this again leaves the employee active.
    /// </summary>
    public void Reactivate() => IsActive = true;
}
