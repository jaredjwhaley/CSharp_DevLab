# Mvvm

Model–View–ViewModel separates data, presentation state, and markup. The view binds to a view model instead of containing the task-list behavior in event handlers.

## Syntax

```xml
<!-- Inside MvvmView, DataContext is a TaskListViewModel.
     The view describes bindings; the view model owns task-list operations. -->
<StackPanel>
  <!-- Each text edit updates Draft. The view model uses Draft to decide whether
       AddCommand can execute; blank or whitespace input is not eligible. -->
  <TextBox Text="{Binding Draft, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
  <Button Content="Add" Command="{Binding AddCommand}" />

  <!-- ItemsSource supplies the sequence of TaskItem objects to display.
       DisplayMemberPath reads Title from EACH item, not from the view model.
       TwoWay SelectedItem keeps the UI selection and SelectedTask synchronized. -->
  <ListBox ItemsSource="{Binding Tasks}"
           SelectedItem="{Binding SelectedTask, Mode=TwoWay}"
           DisplayMemberPath="Title" />

  <!-- RemoveCommand is available only when SelectedTask belongs to Tasks. -->
  <Button Content="Remove selected" Command="{Binding RemoveCommand}" />
</StackPanel>
<!-- Add appends a trimmed title and clears Draft. Collection notifications refresh
     the list; property notifications refresh scalar values such as Draft. -->
```

## Implementation

TaskItem is the model. TaskListViewModel owns a private ObservableCollection, exposes a read-only observable wrapper, validates commands, and notifies scalar property changes. MvvmView is the view; its code-behind only loads markup and supplies a DataContext. The view model reuses the small RelayCommand from Commands. Task titles are immutable, so they do not need individual change notifications.

Start with [MvvmView.xaml](MvvmView.xaml) and its [code-behind](MvvmView.xaml.cs). Read the XML comments in the C# classes and the local XAML comments for implementation details.

## Use cases

Use MVVM when presentation behavior needs isolated tests or a screen has substantial state. It is an organization pattern, not a requirement to eliminate all code-behind or introduce a framework.

## Best practices

Keep control references out of view models and put durable domain rules in models/services. Distinguish collection notifications from item notifications. Make command eligibility reflect valid state. Production screens may need validation feedback, persistence, navigation, and async operations; this focused example does not implement those concerns.

## Run and verify

On Windows with the .NET 10 SDK, run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` from the repository root. The XAML view and its tests belong to this same project; test classes are in Tests.

For an optional interactive check, temporarily host `MvvmView` in a Windows WPF window in a scratch application. Add is disabled for blank/whitespace input. Enter a title and add it: the trimmed title appears and input clears. Select an item to enable Remove; removing it clears the selection.

[Automated tests](../Tests/MvvmTests.cs) verify the core contract. Run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` on Windows. Control tests use an STA thread; these do not replace visual inspection.

## Related reading

- [Commands](../Commands/README.md)
- [C# events](../../CSharp.Tests/Events/README.md) and [delegates](../../CSharp.Tests/Delegates/README.md)
- [WPF project guide](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/)
