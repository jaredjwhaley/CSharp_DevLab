# WPF topics

This Windows-targeted xUnit project contains both executable tests and the example code they exercise. All test classes live in [Tests](Tests/README.md) under the namespace `DevLab.Wpf.Tests`. Topic folders hold XAML views, supporting types, and concept READMEs that link to their tests. There is no separate application or launcher.

| Topic | Purpose |
| --- | --- |
| [Layout](Layout/README.md) | Panels, sizing, spacing, and a measured Grid test |
| [DataBinding](DataBinding/README.md) | DataContext, source/target transfer, and property notifications |
| [ResourcesAndStyles](ResourcesAndStyles/README.md) | Shared styles, triggers, and dynamic resources |
| [Commands](Commands/README.md) | ICommand execution, eligibility, and notifications |
| [Mvvm](Mvvm/README.md) | Task-list presentation state, bindings, and commands |

Run from the repository root on Windows with .NET 10 SDK and desktop support:

```shell
# Build and run the WPF tests; this command requires Windows.
dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj
```

XAML remains useful reference material and is compiled as part of the test project. Control tests construct the views directly. [Sta.cs](Tests/Sta.cs) creates and uses WPF objects on one STA thread and propagates failures to xUnit. State-only tests exercise view models without creating controls. The binding test loads a temporary Window and processes queued dispatcher work before asserting initial, target-to-source, and source-to-target values. It does not simulate keyboard input. The window is closed in a finally block and each STA dispatcher is shut down after its test.

There is no interactive `dotnet run` application. For optional visual inspection, open the views in a XAML designer or temporarily host an individual view in a scratch WPF window. The concept guides describe expected behavior. Keep UI objects on their creating thread and avoid timing-based sleeps or shared Application instances.

The project supports cross-compilation with Windows reference assemblies, but running WPF tests requires Windows. Follow the same topic-folder structure when adding another framework concept.

- [Topics structure](../README.md)
- [Microsoft: WPF overview](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/)
