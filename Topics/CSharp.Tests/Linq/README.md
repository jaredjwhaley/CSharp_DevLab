# LINQ

Language Integrated Query describes how to select, transform, combine, and summarize data. These examples use **LINQ to Objects**, which executes C# operations over `IEnumerable<T>` in memory.

## Syntax

```csharp
int[] numbers = [1, 2, 3, 4];
var methods = numbers.Where(n => n % 2 == 0).Select(n => n * 10);
var query = from n in numbers
            where n % 2 == 0
            select n * 10;
int[] snapshot = methods.ToArray(); // [20, 40]
```

Query syntax is translated into method calls. Both forms compose operators; some operations, including `Any` and `ToArray`, require method syntax. Read [Lambdas and closures](../LambdasAndClosures/README.md) for predicates/selectors and [Enumeration](../Enumeration/README.md) for consumption.

## Operator guide

| Family | Syntax examples | Result and empty-input behavior |
| --- | --- | --- |
| Filtering | `Where`, `OfType<T>` | Keeps matching entries; empty stays empty. OfType skips incompatible values. |
| Projection | `Select`, `SelectMany` | Transforms each item or flattens child sequences; empty stays empty. |
| Ordering | `OrderBy`, `OrderByDescending`, `ThenBy` | Sorts values; empty stays empty. ThenBy adds a secondary key; another OrderBy establishes a new primary order. |
| Grouping | `GroupBy`, `ToLookup` | Groups values by key. Empty input has no groups; a missing lookup key yields an empty sequence. |
| Joins | `Join`, `GroupJoin`, `DefaultIfEmpty` | Join emits matching pairs; empty sides yield no pairs. GroupJoin retains outer groups. DefaultIfEmpty supplies an unmatched row for a left join. |
| Aggregation | `Count`, `Sum`, `Average`, `Min`, `Max`, `Aggregate` | Produces a scalar. Empty integer Sum/Count yield zero; nonnullable Average/Min/Max and unseeded Aggregate throw. Seeded Aggregate returns its seed. Nullable Max returns null for no nonnull values. |
| Elements | `First`, `Last`, `Single`, `ElementAt` | Selects an item. First/Single throw on empty; Single also throws for multiple matches. OrDefault handles absence, not multiple matches. An invalid ElementAt index throws. |
| Quantifiers | `Any`, `All`, `Contains` | Produces bool, usually stopping once known. Empty Any/Contains are false; empty All is true. |
| Sets | `Distinct`, `Union`, `Intersect`, `Except` | Uses equality to emit unique values. Concat instead preserves duplicates. Explicit comparers control string equality. |
| Partitioning | `Skip`, `Take`, `SkipWhile`, `TakeWhile` | Takes a positional slice or stops at a predicate boundary. Empty input stays empty. |
| Materialization | `ToArray`, `ToList`, `ToDictionary`, `ToLookup` | Evaluates now and stores results. ToDictionary rejects duplicate keys; ToLookup groups them. |
| Type conversion | `Cast<T>` | Requires each encountered item to be compatible; failure is deferred until the offending item is read. |

## When does a query execute?

Defining a query often builds an enumerable rather than running it. Enumerating it with `foreach`, a terminal operator, or materialization triggers work. Repeating enumeration can repeat work and observe changed data. Do not confuse **deferred** with **streaming**:

| Kind | Examples | Consequence |
| --- | --- | --- |
| Deferred, streaming | `Where`, `Select`, `Take` | Can yield output while reading input incrementally. |
| Deferred, buffering | `OrderBy`, `GroupBy` | Must collect input before yielding their normal enumerated output. Join buffers its inner side as needed. |
| Immediate scalar | `Any`, `Count`, `Max` | Computes a value at the call; later mutations cannot change that returned value. |
| Immediate materialization | `ToArray`, `ToLookup` | Captures membership now, using memory to hold the result. Reference-type elements remain shared. |

Runtime implementations may optimize terminal operators and specialized source types. Depend on results and documented contracts rather than incidental predicate counts. The timing tests use observable predicates or explicit enumerators where needed to isolate the intended lesson.

## Read the implementations

- [PersonQueries.cs](PersonQueries.cs): names, ordering, adults, and the original mixed-timing oldest query.
- [PersonQueries.Deterministic.cs](PersonQueries.Deterministic.cs): explicit-date age filters and a chronological birth-date snapshot alternative.
- [EmployeeQueries.cs](EmployeeQueries.cs): active status, inner joins, existence-only matching, and unmatched employees.
- [LinqTests.cs](../Tests/LinqTests.cs): broad operator examples and boundary contracts.
The same test class includes people/employee fixtures and query-specific regressions. Age tests use June 15, 2026 explicitly.

### What does “oldest” mean?

`GetOldestPeople` and `GetOldestPeopleOn` mean **greatest completed integer age**. Different birth dates can tie. The maximum is captured immediately and the returned filter is deferred; later source changes can make that maximum stale. The explicit-date version removes clock dependence, not source mutation effects. An initially empty source returns a fixed empty sequence.

`GetPeopleWithEarliestBirthDate` means **earliest birth date**, returning all exact-date ties in an immediately evaluated array. It reads the source once and fixes result membership. It still shares the Person objects. Pick the contract that matches the question rather than silently treating these definitions as interchangeable.

### Why can a join repeat an employee?

`GetValidEmployees` returns an employee for each matching person/employee pair. Two matching person entries cause two output entries for that employee. `GetEmployeesWithPeople` uses `Where` plus `Any`, so duplicate matching people do not multiply the output. Duplicate employee source entries are still retained. `GetEmployeesWithoutPeople` uses the opposite existence test.

The Any-based examples can repeatedly scan people. For large, stable inputs, materializing person identifiers in a `HashSet<Guid>` can reduce lookup work, but it also fixes those identifiers at construction time. Choose that tradeoff explicitly.

## Use cases and best practices

Use LINQ for readable data transformations and summaries. Prefer a loop when the task is primarily side effects, early control flow is complex, or a measured hot path needs specialized handling. Keep query lambdas free of unrelated mutations.

Materialize when you need a stable membership snapshot or repeated expensive reads; avoid copying automatically at every step. Define empty-input and duplicate-key behavior. Specify string comparers for reproducible programmatic ordering. Use Any for existence rather than calculating a full count solely to compare with zero.

`IQueryable<T>` is different: a provider may translate expressions to SQL or another query language, with different translation limits and execution behavior. These tests do not claim to demonstrate database query performance or semantics.

## References

- [Microsoft: Standard query operators](https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/)
- [Microsoft: Enumerable API](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable)
- [Collections: Lists](../Lists/README.md), [Dictionaries](../Dictionaries/README.md), [Sets](../Sets/README.md)
- [Shared models](../Common/README.md), [Topic index](../README.md)
