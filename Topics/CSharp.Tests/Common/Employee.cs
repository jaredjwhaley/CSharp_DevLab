using System;

namespace DevLab.CSharp.Common;

/// <summary>
/// Represents an employee record associated with a person.
/// </summary>
public sealed class Employee
{
    public Guid Id { get; private set; }
    /// <summary>
    /// Gets the unique identifier for the person that the employee is linked to.
    /// </summary>
    /// <remarks>The PersonId is assigned upon creation and cannot be modified thereafter.</remarks>
    public Guid PersonId { get; private set; }
    /// <summary>
    /// Gets the hourly rate for the employee.
    /// </summary>
    public decimal HourlyRate { get; private set; }
    /// <summary>
    /// Gets a value indicating whether the employee is currently employed with the business.
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Employee class with the specified person identifier, hourly rate, compensation
    /// type, and an optional employee identifier.
    /// </summary>
    /// <param name="personId">The unique identifier of the person associated with the employee. This value must be a non-empty GUID.</param>
    /// <param name="hourlyRate">The hourly pay rate for the employee. Must be greater than or equal to zero.</param>
    /// <param name="id">An optional unique identifier for the employee (only provided for data rehydration). If not provided, a new identifier is generated.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="personId"/> is an empty GUID or if <paramref name="hourlyRate"/> is less than zero.</exception>
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

    public void UpdateHourlyRate(decimal newHourlyRate)
    {
        if (newHourlyRate < 0)
            throw new ArgumentException("Hourly rate must be greater than or equal to zero.");
        HourlyRate = newHourlyRate;
    }

    public void Deactivate() => IsActive = false;
    public void Reactivate() => IsActive = true;
}
