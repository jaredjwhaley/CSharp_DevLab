# Inheritance

Inheritance specializes a base class. Constructors initialize the base part, and virtual members provide overridable behavior.

## Syntax

```csharp
// Type declarations go at namespace scope. abstract prevents direct construction
// and can require derived types to supply missing behavior.
abstract class Animal
{
    public string Name { get; }
    protected Animal(string name) => Name = name;
    public abstract string Speak(); // No body: derived types must implement it.
}

// ':' declares inheritance; sealed prevents another type from deriving from Dog.
sealed class Dog : Animal
{
    // base(name) calls the base constructor before this constructor's body.
    public Dog(string name) : base(name) { }
    public override string Speak() => "Woof"; // Fills the inherited abstract slot.
}

// Caller code can refer to a Dog through its Animal contract:
// Animal pet = new Dog("Rex");
// string sound = pet.Speak(); // "Woof": override dispatch follows the real object.
// 'new' on a member would HIDE a name instead of overriding its virtual slot.
```

## How the examples work

Tests contrast virtual dispatch with member hiding, demonstrate a base constructor, and instantiate a sealed concrete implementation of an abstract base.

Read [InheritanceTests.cs](../Tests/InheritanceTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use inheritance when a derived object genuinely satisfies the base contract and shared behavior has a stable design.

## Best practices

Prefer composition for interchangeable collaborators. new hides a member according to the variable type; override participates in runtime dispatch. sealed prevents further inheritance or overriding. Avoid calling overridable methods from constructors.

## Related reading

- [Polymorphism](../Polymorphism/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
