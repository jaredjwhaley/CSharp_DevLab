# Enums

Enums give names to integral values. Flags enums represent combinations of independent bits.

## Syntax

```csharp
enum Status { Unknown = 0, Ready = 1 }
[Flags] enum Access { None = 0, Read = 1, Write = 2 }
```

## How the examples work

Tests show combined flags, named parsing, and the fact that casting or parsing a number can produce an unnamed enum value.

Read [EnumsTests.cs](../Tests/EnumsTests.cs). Each test owns its data and asserts an observable result. Small test-only helper types are nested in the test class so the examples can be read independently. XML comments explain the test's purpose; inline comments explain the less obvious steps.

## When to use it

Use enums for a closed set of named choices and flags for independently combinable options.

## Best practices

Give zero a meaningful name. Use powers of two for independent flags. Validate external values; Enum.TryParse alone accepts numeric values that may be undefined. Enum.IsDefined does not validate all combinations of flags.

## Related reading

- [Operators](../Operators/README.md)
- [C# topic index](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
