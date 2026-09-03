# ResourceDisposal

Disposal releases resources at a known point. Garbage collection manages memory but does not replace timely resource cleanup.

## Syntax

```csharp
// A using statement disposes the resource when its block ends, even if code throws.
// IDisposable.Dispose is cleanup; it is separate from garbage collection.
using (var stream = new MemoryStream())
{
    stream.WriteByte(42);
} // stream is disposed here.

// A using declaration lasts until the end of its ENCLOSING scope.
using var reader = new StringReader("first\nsecond");
string? first = reader.ReadLine(); // "first"
string? second = reader.ReadLine(); // "second"
// reader remains usable through the rest of this method/block, not just this line.
// It is disposed automatically when that scope exits.

// Do not return a resource owned by a using declaration: the caller would receive
// an already-disposed object. Decide explicitly who owns and disposes a resource.
```

## How the examples work

A tracking resource records cleanup on normal and exceptional exits. A MemoryStream example shows that using var lasts until its enclosing scope ends.

Read [ResourceDisposalTests.cs](../Tests/ResourceDisposalTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use using for files, streams, database connections, and other owned IDisposable objects. Use await using for IAsyncDisposable resources.

## Best practices

Dispose resources you own and avoid disposing borrowed objects without an ownership agreement. Make Dispose safe to call repeatedly. A using declaration is scope-bound, not last-use-bound.

## Related reading

- [Exceptions](../Exceptions/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
