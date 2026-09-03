# Topics

Topics is the reusable reference area of DevLab: small, documented, executable demonstrations of language features and framework concepts. Courses retains complete assignments and applications in their original course/section/chapter order. Topics is organized by concept rather than lesson number, so a concept can be found without remembering which course taught it.

Only `<LanguageOrFramework>.Tests` projects belong directly under Topics. Test classes live in each project's Tests folder; supporting example types, views, and concept READMEs remain in the concept folders. Test namespaces are DevLab.CSharp.Tests and DevLab.Wpf.Tests.

## Projects and conventions

| Project | Purpose | Platform |
| --- | --- | --- |
| [CSharp.Tests](CSharp.Tests/README.md) | C# examples and xUnit assertions; one class per topic | .NET 10 |
| [Wpf.Tests](Wpf.Tests/README.md) | One test class per WPF concept, with XAML, models, and STA control checks | Windows, .NET 10 desktop |

Each source directory has a README. Concept READMEs explain what the feature does, its syntax, why and when to use it, how the local example works, and best practices. Links connect prerequisites and related topics. C# XML comments describe class/member contracts; inline C# and XAML comments explain local implementation details. Common contains deliberately shared fixtures, while test-specific helpers remain local.

## Requested course-section coverage

| Section | Reference topics |
| --- | --- |
| 1 — Types and variables | [DataTypesAndVariables](CSharp.Tests/DataTypesAndVariables/README.md), [TypeConversions](CSharp.Tests/TypeConversions/README.md), [Operators](CSharp.Tests/Operators/README.md), [Strings](CSharp.Tests/Strings/README.md), [Nullability](CSharp.Tests/Nullability/README.md) |
| 2 — Decisions | [Conditionals](CSharp.Tests/Conditionals/README.md) |
| 3 — Loops | [Loops](CSharp.Tests/Loops/README.md) |
| 4 — Methods | [Methods](CSharp.Tests/Methods/README.md) |
| 5 — OOP | [Classes](CSharp.Tests/Classes/README.md), [PropertiesAndEncapsulation](CSharp.Tests/PropertiesAndEncapsulation/README.md), [StaticMembers](CSharp.Tests/StaticMembers/README.md) |
| 6 — Collections | [Arrays](CSharp.Tests/Arrays/README.md), [Lists](CSharp.Tests/Lists/README.md), [Dictionaries](CSharp.Tests/Dictionaries/README.md), [Sets](CSharp.Tests/Sets/README.md), [StacksAndQueues](CSharp.Tests/StacksAndQueues/README.md), [Enumeration](CSharp.Tests/Enumeration/README.md) |
| 7 — Errors and cleanup | [Exceptions](CSharp.Tests/Exceptions/README.md), [ResourceDisposal](CSharp.Tests/ResourceDisposal/README.md) |
| 8 — Inheritance | [Inheritance](CSharp.Tests/Inheritance/README.md) |
| 9 — Interfaces and polymorphism | [Interfaces](CSharp.Tests/Interfaces/README.md), [Polymorphism](CSharp.Tests/Polymorphism/README.md), [Composition](CSharp.Tests/Composition/README.md) |
| 10 — Structs | [Structs](CSharp.Tests/Structs/README.md), [ValueAndReferenceTypes](CSharp.Tests/ValueAndReferenceTypes/README.md), [Enums](CSharp.Tests/Enums/README.md) |
| 11 — Events and delegates | [Delegates](CSharp.Tests/Delegates/README.md), [Events](CSharp.Tests/Events/README.md), [LambdasAndClosures](CSharp.Tests/LambdasAndClosures/README.md) |
| 12 — Regex | [RegularExpressions](CSharp.Tests/RegularExpressions/README.md) |
| 13 — WPF | [Layout](Wpf.Tests/Layout/README.md), [DataBinding](Wpf.Tests/DataBinding/README.md), [ResourcesAndStyles](Wpf.Tests/ResourcesAndStyles/README.md), [Commands](Wpf.Tests/Commands/README.md), [Mvvm](Wpf.Tests/Mvvm/README.md) |
| 17 — LINQ | [Linq](CSharp.Tests/Linq/README.md): operator families, joins, empty input, explicit dates, snapshots, and deferred execution |

## Running examples

From the repository root with .NET 10 SDK:

```shell
# Restore dependencies, build, and run this project's tests from the repository root.
dotnet test Topics/CSharp.Tests/CSharp.Tests.csproj
```

On Windows with desktop support:

```shell
# Build and run the WPF tests; this command requires Windows.
dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj
```

Use an individual project when learning one area. The full solution includes unrelated course applications and Windows projects. On non-Windows systems, the C# project runs independently; WPF may cross-compile with reference assemblies but cannot run there.

## Adding a concept

Create a concept directory with a README and any supporting types, and put one focused test class in the project's Tests directory using the shared DevLab.<Framework>.Tests namespace. Keep examples deterministic and isolated; test relevant boundaries as well as the ordinary path. Add helper classes only where they make the concept easier to understand. Link prerequisites and authoritative documentation. Update the project index and this mapping when adding coverage. Keep framework-specific examples in their own framework project.

- [Microsoft: C# reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
- [Microsoft: WPF overview](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/)
