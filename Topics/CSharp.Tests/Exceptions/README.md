# Exceptions

Exceptions signal that an operation cannot complete normally. Catch blocks handle selected failures; finally performs cleanup.

## Syntax

```csharp
string input = "twelve";
try
{
    // Parse cannot interpret this input, so it throws instead of returning a value.
    int number = int.Parse(input);
    Console.WriteLine(number); // Not reached for "twelve".
}
catch (FormatException ex)
{
    // This catch handles only FormatException; ex exposes the failure details.
    Console.WriteLine($"Invalid integer: {ex.Message}");
}
finally
{
    // Runs when control leaves the try/catch, including ordinary exception paths.
    Console.WriteLine("Parsing attempt finished.");
}

// Inside a catch, use 'throw;' to propagate the current exception while retaining
// its original stack trace. 'throw ex;' resets the throw location.
// Use TryParse when malformed input is expected rather than exceptional.
```

## How the examples work

Tests check guard exceptions, catch filters, finally, and rethrowing the same exception with throw;.

Read [ExceptionsTests.cs](../Tests/ExceptionsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use exceptions for failed operations and violated preconditions. Use Try-style APIs for expected unsuccessful input.

## Best practices

Catch only failures you can handle. Use throw; to preserve the original stack trace; throw ex; resets the throw location. Do not swallow failures or use broad catches as a substitute for recovery.

## Related reading

- [ResourceDisposal](../ResourceDisposal/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
