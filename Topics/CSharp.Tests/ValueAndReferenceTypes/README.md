# ValueAndReferenceTypes

Value-type assignment copies a value; reference-type assignment copies a reference to an object.

## Syntax

```csharp
// Assignment of a value type copies its value into a separate variable.
int original = 10;
int copy = original;
copy++; // copy is 11; original is still 10.

// Assignment of a reference type copies the reference, so both variables refer
// to the same mutable object. It does not create a second StringBuilder.
var text = new System.Text.StringBuilder("A");
var alias = text;
alias.Append("B"); // text and alias both refer to the builder containing "AB".

// Reassignment changes which object alias points to, not the original object.
alias = new System.Text.StringBuilder("C");
// text still contains "AB"; alias now refers to a different builder containing "C".

// A struct containing a reference also copies that reference when copied.
// "Value copy" does not mean every object reachable from it is cloned.
```

## How the examples work

Tests distinguish value copies, shared object state, ordinary reference parameters, and shallow copies of structs containing references.

Read [ValueAndReferenceTypesTests.cs](../Tests/ValueAndReferenceTypesTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use this distinction when reasoning about mutations, method arguments, collection copies, and equality.

## Best practices

Passing a class instance normally passes its reference by value. Reassigning that parameter does not reassign the caller variable, but mutating the object remains visible. Storage location is not the definition of a value type.

## Related reading

- [Structs](../Structs/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
