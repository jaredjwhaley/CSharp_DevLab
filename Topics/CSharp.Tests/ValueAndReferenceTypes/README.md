# ValueAndReferenceTypes

Value-type assignment copies a value; reference-type assignment copies a reference to an object.

## Syntax

```csharp
int copy = original;
var alias = originalObject;
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
