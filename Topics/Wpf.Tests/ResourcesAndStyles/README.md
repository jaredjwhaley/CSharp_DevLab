# ResourcesAndStyles

Resources give reusable values names; styles apply shared property values and state-dependent triggers to controls.

## Syntax

```xml
<SolidColorBrush x:Key="AccentBrush" Color="SteelBlue" />
<Style x:Key="AccentButton" TargetType="Button">
  <Setter Property="Background" Value="{StaticResource AccentBrush}" />
</Style>
```

## Implementation

ResourcesAndStylesView declares a brush, a keyed Button style, and an implicit TextBlock style. Both buttons share the keyed style. A trigger lowers opacity when IsEnabled is false. The preview border uses DynamicResource so replacing the brush resource changes that border; StaticResource resolves the shared object when the value is loaded.

Start with [ResourcesAndStylesView.xaml](ResourcesAndStylesView.xaml) and its [code-behind](ResourcesAndStylesView.xaml.cs). Read the XML comments in the C# classes and the local XAML comments for implementation details.

## Use cases

Use resources for repeated brushes, sizes, templates, and styles. A style changes properties; a ControlTemplate changes the visual tree; a DataTemplate describes how data should be displayed.

## Best practices

Place resources at the narrowest useful scope and use merged dictionaries as an application grows. Local property values can override style setters. Use DynamicResource when runtime resource replacement is needed; mutating an already-shared brush object is different from replacing its resource entry.

## Run and verify

On Windows with the .NET 10 SDK, run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` from the repository root. The XAML view and its tests belong to this same project; test classes are in Tests.

For an optional interactive check, temporarily host `ResourcesAndStylesView` in a Windows WPF window in a scratch application. Both buttons should share formatting; the disabled one is dim. The automated example replaces AccentBrush and verifies the DynamicResource preview changes.

[Automated tests](../Tests/ResourcesAndStylesTests.cs) verify the core contract. Run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` on Windows. Control tests use an STA thread; these do not replace visual inspection.

## Related reading

- [Layout](../Layout/README.md)
- [C# events](../../CSharp.Tests/Events/README.md) and [delegates](../../CSharp.Tests/Delegates/README.md)
- [WPF project guide](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/styles-templates-overview)
