# DataBinding

Data binding connects a control property to a source property so the view can follow state changes without manually assigning every control.

## Syntax

```xml
<TextBox Text="{Binding Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
<TextBlock Text="{Binding Greeting, Mode=OneWay}" />
```

## Implementation

DataBindingView sets its DataContext to PersonViewModel. Name is a mutable source property; Greeting is computed from it. The setter raises INotifyPropertyChanged for both properties. TextBox edits update Name on each keystroke; the output reads Greeting. DataContext is inherited down the element tree unless overridden.

Start with [DataBindingView.xaml](DataBindingView.xaml) and its [code-behind](DataBindingView.xaml.cs). Read the XML comments in the C# classes and the local XAML comments for implementation details.

## Use cases

Use binding for forms, status displays, item lists, and editable presentation state. OneWay displays changes, TwoWay also accepts edits, and OneTime avoids ongoing source-property updates for static data.

## Best practices

Set update timing deliberately: TextBox.Text normally updates its source on lost focus. Binding paths are resolved at runtime, so inspect binding errors in the debugger output. INotifyPropertyChanged handles item properties; ObservableCollection handles collection membership. Keep UI-bound mutations on the UI thread.

## Run and verify

On Windows with the .NET 10 SDK, run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` from the repository root. The XAML view and its tests belong to this same project; test classes are in Tests.

For an optional interactive check, temporarily host `DataBindingView` in a scratch WPF window and replace Ada with Grace. The greeting must update while typing, before focus leaves the input. Empty input should display an empty-name greeting without an exception.

[Automated tests](../Tests/DataBindingTests.cs) verify the core contract. Run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` on Windows. The binding test creates a temporary Window, waits for queued binding/layout/Loaded work using the dispatcher, and verifies both transfer directions. Construction alone does not guarantee that inherited DataContext and bindings are ready. The window is closed in a finally block. These assertions do not replace keyboard/focus or visual inspection.

## Related reading

- [Mvvm](../Mvvm/README.md)
- [C# events](../../CSharp.Tests/Events/README.md) and [delegates](../../CSharp.Tests/Delegates/README.md)
- [WPF project guide](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/)
