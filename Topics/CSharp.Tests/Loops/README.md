# Loops

Loops repeat a block until a condition or sequence is exhausted.

## Syntax

```csharp
int[] items = [10, 20, 30];
// for has three parts: initialize once; test before each pass; update afterward.
for (int i = 0; i < items.Length; i++)
    Console.WriteLine(items[i]); // Prints 10, 20, 30; i is the current index.

// foreach gets each value directly when an index is not needed.
foreach (int item in items)
    Console.WriteLine(item); // Also prints 10, 20, 30.

int remaining = 2;
// while checks first, so its body may never run. Decrement makes progress.
while (remaining > 0)
    remaining--; // Runs twice; remaining becomes 0.

// do checks AFTER the body, so it always runs at least once.
do { remaining++; } while (remaining < 1); // Runs once; remaining becomes 1.

for (int i = 1; i <= 6; i++)
{
    if (i == 5) break;         // End the nearest loop entirely.
    if (i % 2 == 0) continue;  // Skip the rest of this iteration for even values.
    Console.WriteLine(i);      // Prints only 1 and 3.
}
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
