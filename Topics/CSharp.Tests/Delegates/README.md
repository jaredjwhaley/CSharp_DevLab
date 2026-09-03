# Delegates

A delegate is a strongly typed reference to callable behavior. Its signature specifies parameter types and a return type. Passing a delegate lets a caller choose an operation without making the receiving method know every possible implementation.

## Syntax and implementation

```csharp
Func<int, int, int> add = (left, right) => left + right;
int result = add(2, 3);
Action<string> display = Console.WriteLine;
Predicate<int> positive = value => value > 0;
```

A method name without parentheses is a **method group**; the compiler can convert it to a compatible delegate. Parentheses invoke the method instead. A lambda supplies an inline implementation.

[BinaryMathOperation.cs](BinaryMathOperation.cs) and [UnaryMathOperation.cs](UnaryMathOperation.cs) declare named generic delegate types. [Calculator.cs](Calculator.cs) accepts those delegates and uses generic numeric constraints. [DelegatesTests.cs](../Tests/DelegatesTests.cs) demonstrates method groups, multicast behavior, and standard delegate types in one class.

| Delegate | Purpose |
| --- | --- |
| `Action<T>` | Accepts a value and returns void |
| `Func<T, TResult>` | Accepts a value and returns a result |
| `Predicate<T>` | Tests a value and returns bool |
| Named delegate | Expresses a domain-specific signature or API meaning |

## Use cases

Delegates suit callbacks, selectable calculations, comparison functions, LINQ predicates, and event handlers. Prefer a direct method call when the operation is fixed. Prefer an interface when the collaborator has several related operations or its own meaningful state.

## Multicast and best practices

Combining delegates with `+=` builds an invocation list. Normal invocation runs targets synchronously in order. For a returning delegate, only the final target's result is returned; it does not aggregate earlier results. A throwing target stops the remaining invocation. Delegates are immutable: adding/removing produces another delegate rather than changing a previously captured delegate object.

Use named methods when they explain behavior better than a long lambda. Avoid unnecessary captures. Retain the exact handler when managing subscription lifetimes. Use `event` when outside callers should subscribe without being allowed to invoke or replace the publisher's callback list.

- [Lambdas and closures](../LambdasAndClosures/README.md)
- [Events](../Events/README.md)
- [Methods](../Methods/README.md), [LINQ](../Linq/README.md)
- [Microsoft: Delegates](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)
- [Topic index](../README.md)
