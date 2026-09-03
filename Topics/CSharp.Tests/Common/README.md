# Shared models

[Person.cs](Person.cs) and [Employee.cs](Employee.cs) supply small reusable fixtures for LINQ and model examples. They represent data shared by demonstrations rather than a full production domain model.

## Syntax and implementation

```csharp
// Person and Employee are this project's shared fixture types.
// DateOnly(year, month, day) describes a calendar date without a time of day.
var person = new Person("Ada", "Lovelace", new DateOnly(2000, 6, 15));

// Supply the evaluation date explicitly so an example does not change tomorrow.
int age = person.GetAgeOn(new DateOnly(2026, 6, 14)); // 25: birthday is tomorrow.
int birthdayAge = person.GetAgeOn(new DateOnly(2026, 6, 15)); // 26.

// person.Id links an employment record to a person; it does not embed the person.
// The m suffix declares a decimal hourly rate, matching Employee's parameter type.
var employee = new Employee(person.Id, 25m);
employee.Deactivate(); // IsActive becomes false; the Person link remains intact.
```

Person has an identifier, birth date, names, contact details, and a computed full name. `GetAgeOn` counts completed years on an explicit date and rejects dates before birth. February 29 birthdays advance on March 1 in non-leap years. `Age` remains a convenience property using today's UTC date. Use explicit dates in repeatable examples.

Employee associates employment information with `PersonId` rather than inheriting Person. This lets the LINQ examples show matched and unmatched records. Read its XML documentation for hourly-rate validation and active-state operations. The classes do not claim comprehensive contact-data or domain validation.

## Use cases and best practices

Shared fixtures keep examples comparable. Keep topic-specific helper types local so unrelated examples do not acquire unnecessary dependencies. Mutable model references remain shared after ToList/ToArray; those operations do not deep-clone people. Keep test dates explicit and create new fixtures per test.

- [CommonTests.cs](../Tests/CommonTests.cs)
- [LINQ](../Linq/README.md)
- [Classes](../Classes/README.md), [Properties and encapsulation](../PropertiesAndEncapsulation/README.md)
- [Microsoft: DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly)
