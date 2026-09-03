# Enumeration

Enumeration provides sequential access through IEnumerable<T> and IEnumerator<T>. An iterator can yield values as they are requested.

## Syntax

```csharp
// IEnumerable<int> promises sequential access to integers, not a stored list.
IEnumerable<int> Numbers()
{
    // yield return emits one value and pauses until the consumer requests another.
    yield return 10;
    yield return 20;
}

var sequence = Numbers(); // Creates an enumerable; the iterator body has not run.
foreach (int number in sequence)
    Console.WriteLine(number); // Requests values and prints 10, then 20.

// This is the lower-level mechanism used by foreach for this kind of sequence.
// MoveNext advances and returns false at the end; Current reads the current item.
using var iterator = sequence.GetEnumerator();
while (iterator.MoveNext())
    Console.WriteLine(iterator.Current);
// using disposes the enumerator at scope exit, including on an exception.
```

## How the examples work

Tests demonstrate lazy iterator execution, iterator cleanup after early termination, and List invalidation during structural mutation.

Read [EnumerationTests.cs](../Tests/EnumerationTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use IEnumerable when consumers only need traversal, or yield return to describe a sequence without building a full list.

## Best practices

Do not assume an enumerable is repeatable, cheap, or finite. Iterator bodies start at enumeration, including checks inside them. foreach disposes an enumerator when appropriate, even after break.

## Related reading

- [Linq](../Linq/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
