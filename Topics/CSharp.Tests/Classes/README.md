# Classes

Classes describe reference-type objects that combine state and behavior. A constructor establishes the initial state.

## Syntax

```csharp
// Class declarations belong at namespace scope (or inside another type).
class Counter
{
    // private set allows callers to read Value, but only Counter can assign it.
    public int Value { get; private set; }

    // A constructor has the class name and no return type. It establishes state.
    public Counter(int initial) => Value = initial;

    // An instance method operates on the particular object receiving the call.
    public void Increment() => Value++;
}

// Inside a method, create and use an instance:
// var counter = new Counter(2); // new constructs an object; initial receives 2.
// counter.Increment();          // Value becomes 3 on this object.
// var alias = counter;          // Copies the reference, not the Counter object.
// alias.Increment();            // counter.Value and alias.Value are now both 4.
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
