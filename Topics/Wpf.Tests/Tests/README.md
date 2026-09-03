# Wpf tests

All executable test classes are stored here and use the namespace `DevLab.Wpf.Tests`. Each concept has one class named `<Topic>Tests`; helper types and views used by multiple tests remain in their concept directories. This gives test-runner names such as `DevLab.Wpf.Tests.DataBindingTests` without an extra topic namespace.

Run from the repository root:

```shell
dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj
```

WPF requires Windows. Sta.cs runs control tests on an STA thread; the binding test loads a temporary window and pumps pending dispatcher operations rather than sleeping.

| Test class | Concept guide |
| --- | --- |
| [CommandsTests.cs](CommandsTests.cs) | [Commands](../Commands/README.md) |
| [DataBindingTests.cs](DataBindingTests.cs) | [DataBinding](../DataBinding/README.md) |
| [LayoutTests.cs](LayoutTests.cs) | [Layout](../Layout/README.md) |
| [MvvmTests.cs](MvvmTests.cs) | [Mvvm](../Mvvm/README.md) |
| [ResourcesAndStylesTests.cs](ResourcesAndStylesTests.cs) | [ResourcesAndStyles](../ResourcesAndStyles/README.md) |
