# Interfaces

An interface defines a contract that unrelated types can implement. Consumers depend on capabilities rather than a particular class.

## Syntax

```csharp
interface IFormatter { string Format(string value); }
class Upper : IFormatter { public string Format(string value) => value.ToUpperInvariant(); }
```

## How the examples work

Tests substitute two implementations and call an explicitly implemented member through its interface.

Read [InterfacesTests.cs](../Tests/InterfacesTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use interfaces at meaningful boundaries, such as persistence or formatting, where alternate implementations or test doubles are useful.

## Best practices

Keep contracts focused and name what callers can rely on. Do not add interfaces mechanically to every class. Explicit implementations are accessed through the interface, not the concrete variable.

## Related reading

- [Polymorphism](../Polymorphism/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
