# C# topics

This .NET 10 xUnit project is a language reference made of executable examples. All test classes live in [Tests](Tests/README.md) under the namespace `DevLab.CSharp.Tests`. Supporting types stay local unless they are deliberately reused, as in Common, Events, and LINQ. Each concept README links to its corresponding test class. Supporting types remain in the concept folder; small test-only helpers are nested in the test class.

From the repository root:

```shell
dotnet test Topics/CSharp.Tests/CSharp.Tests.csproj
dotnet test Topics/CSharp.Tests/CSharp.Tests.csproj --filter FullyQualifiedName~LinqTests
```

Read a concept README for purpose, syntax, implementation, use cases, and best practices. Then read and run its tests. Every example owns its state, avoids interactive input, and asserts its result. XML summaries describe declarations; ordinary inline comments explain implementation choices. Tests deliberately demonstrating compiler warnings suppress only the specific warning at that example.

| Folder | Purpose |
| --- | --- |
| [Arrays](Arrays/README.md) | Arrays hold a fixed number of elements of one type, addressed by zero-based indexes. |
| [Classes](Classes/README.md) | Classes describe reference-type objects that combine state and behavior. A constructor establishes the initial state. |
| [Common](Common/README.md) | Shared Person and Employee models and explicit-date age calculations. |
| [Composition](Composition/README.md) | Composition builds an object from collaborators: it has a dependency instead of inheriting that dependency. |
| [Conditionals](Conditionals/README.md) | Conditionals choose a path based on a Boolean expression or a matched pattern. |
| [DataTypesAndVariables](DataTypesAndVariables/README.md) | Types describe which values a variable can hold and which operations are legal. Variables name storage; constants name values that cannot change. |
| [Delegates](Delegates/README.md) | A delegate is a strongly typed reference to callable behavior. Its signature specifies parameter types and a return type. Passing a delegate lets a caller choose an operation without making the receiving method know every possible implementation. |
| [Dictionaries](Dictionaries/README.md) | Dictionary<TKey,TValue> maps unique keys to values using equality and hashing. |
| [Enumeration](Enumeration/README.md) | Enumeration provides sequential access through IEnumerable<T> and IEnumerator<T>. An iterator can yield values as they are requested. |
| [Enums](Enums/README.md) | Enums give names to integral values. Flags enums represent combinations of independent bits. |
| [Events](Events/README.md) | An event lets an object announce that something happened while leaving the response to other objects. A temperature sensor can report a changed reading without knowing whether a thermostat, chart, or logger is listening. |
| [Exceptions](Exceptions/README.md) | Exceptions signal that an operation cannot complete normally. Catch blocks handle selected failures; finally performs cleanup. |
| [Inheritance](Inheritance/README.md) | Inheritance specializes a base class. Constructors initialize the base part, and virtual members provide overridable behavior. |
| [Interfaces](Interfaces/README.md) | An interface defines a contract that unrelated types can implement. Consumers depend on capabilities rather than a particular class. |
| [LambdasAndClosures](LambdasAndClosures/README.md) | A lambda is an inline function. A closure retains access to captured variables after their original scope has ended. |
| [Linq](Linq/README.md) | Language Integrated Query describes how to select, transform, combine, and summarize data. These examples use **LINQ to Objects**, which executes C# operations over `IEnumerable<T>` in memory. |
| [Lists](Lists/README.md) | List<T> is a resizable indexed collection that preserves element order and permits duplicates. |
| [Loops](Loops/README.md) | Loops repeat a block until a condition or sequence is exhausted. |
| [Methods](Methods/README.md) | Methods name reusable operations, accept parameters, and return results or perform actions. |
| [Nullability](Nullability/README.md) | Null represents a missing reference or an absent nullable value. Nullable annotations help the compiler detect unsafe dereferences. |
| [Operators](Operators/README.md) | Operators combine, compare, assign, or transform values. Operand types determine what an operator means. |
| [Polymorphism](Polymorphism/README.md) | Polymorphism lets the same call produce behavior appropriate to the actual object behind a common contract. |
| [PropertiesAndEncapsulation](PropertiesAndEncapsulation/README.md) | Encapsulation keeps an object responsible for maintaining its own valid state. Properties control access to that state. |
| [RegularExpressions](RegularExpressions/README.md) | Regular expressions describe text patterns for recognition, extraction, and replacement. |
| [ResourceDisposal](ResourceDisposal/README.md) | Disposal releases resources at a known point. Garbage collection manages memory but does not replace timely resource cleanup. |
| [Sets](Sets/README.md) | A set stores unique values and supports membership and set operations. |
| [StacksAndQueues](StacksAndQueues/README.md) | Stacks remove the newest item first (LIFO); queues remove the oldest item first (FIFO). |
| [StaticMembers](StaticMembers/README.md) | Static members belong to a type rather than a particular instance. |
| [Strings](Strings/README.md) | A string is an immutable sequence of UTF-16 code units. Text operations return new strings instead of modifying the original. |
| [Structs](Structs/README.md) | Structs are value types: assignment copies the value. Small immutable values are a common use. |
| [TypeConversions](TypeConversions/README.md) | Conversions translate values between types; parsing interprets text as a value. |
| [ValueAndReferenceTypes](ValueAndReferenceTypes/README.md) | Value-type assignment copies a value; reference-type assignment copies a reference to an object. |

For a learning sequence, begin with values/conversions/operators, conditionals/loops/methods, classes/properties, collections/enumeration, then interfaces/inheritance/composition, delegates/events, and LINQ. WPF has a [separate project](../Wpf.Tests/README.md).

Keep examples focused and repeatable. Do not turn a topic into a full course application. Add a README link and an observable assertion for new concepts, document empty/invalid input where relevant, and use fixed dates in tests. Test names describe behavior rather than numbered course chapters.

- [Topics structure and requested section mapping](../README.md)
- [Microsoft: C# language reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
