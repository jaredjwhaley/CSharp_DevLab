# Composition

Composition builds an object from collaborators: it has a dependency instead of inheriting that dependency.

## Syntax

```csharp
// The Report class owns a reference to a collaborator rather than inheriting it.
// These declarations are placed at namespace scope.
interface IFormatter { string Format(string value); }
class UpperFormatter : IFormatter
{
    public string Format(string value) => value.ToUpperInvariant();
}
class Report
{
    private readonly IFormatter _formatter;
    public Report(IFormatter formatter)
    {
        ArgumentNullException.ThrowIfNull(formatter); // A collaborator is required.
        _formatter = formatter; // Store the supplied implementation for later use.
    }
    public string Render(string text) => _formatter.Format(text); // Delegate work.
}

// Caller code supplies the collaborator through the constructor:
// var report = new Report(new UpperFormatter());
// string result = report.Render("hello"); // "HELLO"
// Passing a different formatter changes formatting without modifying Report.
```

## How the examples work

A report delegates formatting to an injected collaborator. Tests use different implementations to change behavior without changing the report.

Read [CompositionTests.cs](../Tests/CompositionTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use composition for interchangeable behavior, services, and independently testable components.

## Best practices

Make required dependencies explicit in constructors, validate them, and document ownership. Prefer small collaborator contracts over deep inheritance trees.

## Related reading

- [Interfaces](../Interfaces/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
