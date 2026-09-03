# Exceptions

Exceptions signal that an operation cannot complete normally. Catch blocks handle selected failures; finally performs cleanup.

## Syntax

```csharp
 try { Work(); }
 catch (FormatException) { /* recover from malformed text */ }
 finally { /* cleanup */ }
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
