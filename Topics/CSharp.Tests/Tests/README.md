# CSharp tests

All executable test classes are stored here and use the namespace `DevLab.CSharp.Tests`. Each concept has one class named `<Topic>Tests`; helper types and views used by multiple tests remain in their concept directories. This gives test-runner names such as `DevLab.CSharp.Tests.EventsTests` without an extra topic namespace.

Run from the repository root:

```shell
dotnet test Topics/CSharp.Tests/CSharp.Tests.csproj
```

Tests use isolated fixtures and fixed dates. Inline helper types stay with the test that demonstrates them.

| Test class | Concept guide |
| --- | --- |
| [ArraysTests.cs](ArraysTests.cs) | [Arrays](../Arrays/README.md) |
| [ClassesTests.cs](ClassesTests.cs) | [Classes](../Classes/README.md) |
| [CommonTests.cs](CommonTests.cs) | [Common](../Common/README.md) |
| [CompositionTests.cs](CompositionTests.cs) | [Composition](../Composition/README.md) |
| [ConditionalsTests.cs](ConditionalsTests.cs) | [Conditionals](../Conditionals/README.md) |
| [DataTypesAndVariablesTests.cs](DataTypesAndVariablesTests.cs) | [DataTypesAndVariables](../DataTypesAndVariables/README.md) |
| [DelegatesTests.cs](DelegatesTests.cs) | [Delegates](../Delegates/README.md) |
| [DictionariesTests.cs](DictionariesTests.cs) | [Dictionaries](../Dictionaries/README.md) |
| [EnumerationTests.cs](EnumerationTests.cs) | [Enumeration](../Enumeration/README.md) |
| [EnumsTests.cs](EnumsTests.cs) | [Enums](../Enums/README.md) |
| [EventsTests.cs](EventsTests.cs) | [Events](../Events/README.md) |
| [ExceptionsTests.cs](ExceptionsTests.cs) | [Exceptions](../Exceptions/README.md) |
| [InheritanceTests.cs](InheritanceTests.cs) | [Inheritance](../Inheritance/README.md) |
| [InterfacesTests.cs](InterfacesTests.cs) | [Interfaces](../Interfaces/README.md) |
| [LambdasAndClosuresTests.cs](LambdasAndClosuresTests.cs) | [LambdasAndClosures](../LambdasAndClosures/README.md) |
| [LinqTests.cs](LinqTests.cs) | [Linq](../Linq/README.md) |
| [ListsTests.cs](ListsTests.cs) | [Lists](../Lists/README.md) |
| [LoopsTests.cs](LoopsTests.cs) | [Loops](../Loops/README.md) |
| [MethodsTests.cs](MethodsTests.cs) | [Methods](../Methods/README.md) |
| [NullabilityTests.cs](NullabilityTests.cs) | [Nullability](../Nullability/README.md) |
| [OperatorsTests.cs](OperatorsTests.cs) | [Operators](../Operators/README.md) |
| [PolymorphismTests.cs](PolymorphismTests.cs) | [Polymorphism](../Polymorphism/README.md) |
| [PropertiesAndEncapsulationTests.cs](PropertiesAndEncapsulationTests.cs) | [PropertiesAndEncapsulation](../PropertiesAndEncapsulation/README.md) |
| [RegularExpressionsTests.cs](RegularExpressionsTests.cs) | [RegularExpressions](../RegularExpressions/README.md) |
| [ResourceDisposalTests.cs](ResourceDisposalTests.cs) | [ResourceDisposal](../ResourceDisposal/README.md) |
| [SetsTests.cs](SetsTests.cs) | [Sets](../Sets/README.md) |
| [StacksAndQueuesTests.cs](StacksAndQueuesTests.cs) | [StacksAndQueues](../StacksAndQueues/README.md) |
| [StaticMembersTests.cs](StaticMembersTests.cs) | [StaticMembers](../StaticMembers/README.md) |
| [StringsTests.cs](StringsTests.cs) | [Strings](../Strings/README.md) |
| [StructsTests.cs](StructsTests.cs) | [Structs](../Structs/README.md) |
| [TypeConversionsTests.cs](TypeConversionsTests.cs) | [TypeConversions](../TypeConversions/README.md) |
| [ValueAndReferenceTypesTests.cs](ValueAndReferenceTypesTests.cs) | [ValueAndReferenceTypes](../ValueAndReferenceTypes/README.md) |
