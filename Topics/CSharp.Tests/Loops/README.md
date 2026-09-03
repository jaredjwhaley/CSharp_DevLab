# Loops

Loops repeat a block until a condition or sequence is exhausted.

## Syntax

```csharp
for (int i = 0; i < items.Length; i++) { /* index available */ }
foreach (var item in items) { /* each value */ }
while (ready) { /* condition first */ }
do { /* at least once */ } while (ready);
```

## How the examples work

Tests compare indexed and sequential traversal, zero versus one minimum iteration, and the difference between skipping an iteration and ending the loop.

Read [LoopsTests.cs](../Tests/LoopsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use foreach for traversal, for for index-based work, and while for a condition whose iteration count is unknown.

## Best practices

Ensure the loop makes progress. break exits the nearest loop; continue skips its remaining body. Avoid changing a collection while enumerating it unless its API explicitly supports that behavior.

## Related reading

- [Enumeration](../Enumeration/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
