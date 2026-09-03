# Commands

A command separates a user action from the control that triggers it. ICommand exposes execution, availability, and an availability-change notification.

## Syntax

```xml
<Button Content="Increment" Command="{Binding IncrementCommand}" />
```

## Implementation

RelayCommand accepts an Action and an optional Func<bool>. CounterViewModel supplies Increment and Reset behavior and raises CanExecuteChanged after a count change. The same command could be bound to multiple controls. Execute rechecks eligibility so a direct caller cannot bypass the teaching command's rule.

Start with [CommandsView.xaml](CommandsView.xaml) and its [code-behind](CommandsView.xaml.cs). Read the XML comments in the C# classes and the local XAML comments for implementation details.

## Use cases

Use commands when buttons, menu items, or gestures should invoke reusable actions and share enabled-state rules. A simple UI-only action can still use a click handler. RoutedCommand is a WPF-specific alternative that routes through command bindings on the element tree; this example is a plain delegate-backed ICommand.

## Best practices

Raise CanExecuteChanged whenever the predicate's dependencies change. Keep CanExecute quick and free of side effects. This synchronous RelayCommand does not handle asynchronous cancellation, progress, or errors; use a deliberately designed async command for those operations.

## Run and verify

On Windows with the .NET 10 SDK, run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` from the repository root. The XAML view and its tests belong to this same project; test classes are in Tests.

For an optional interactive check, temporarily host `CommandsView` in a Windows WPF window in a scratch application. Reset starts disabled. Increment three times: Increment becomes disabled and Count displays 3. Reset returns Count to zero and re-enables Increment.

[Automated tests](../Tests/CommandsTests.cs) verify the core contract. Run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` on Windows. Control tests use an STA thread; these do not replace visual inspection.

## Related reading

- [Mvvm](../Mvvm/README.md)
- [C# events](../../CSharp.Tests/Events/README.md) and [delegates](../../CSharp.Tests/Delegates/README.md)
- [WPF project guide](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/advanced/commanding-overview)
