# Classes

Classes describe reference-type objects that combine state and behavior. A constructor establishes the initial state.

## Syntax

```csharp
var counter = new Counter(2);
counter.Increment();
```

## How the examples work

Tests instantiate independent objects and then show how two variables can refer to the same instance.

Read [ClassesTests.cs](../Tests/ClassesTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use a class for an entity with identity, mutable state, or behavior shared through references.

## Best practices

Construct valid objects, keep state private when possible, and do not confuse a variable holding a reference with the object itself.

## Related reading

- [PropertiesAndEncapsulation](../PropertiesAndEncapsulation/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
