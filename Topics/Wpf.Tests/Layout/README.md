# Layout

Layout arranges controls within available space. WPF measures desired sizes and then arranges children in the space their parent supplies.

## Syntax

```xml
<Grid>
  <Grid.ColumnDefinitions>
    <ColumnDefinition Width="180" />
    <ColumnDefinition Width="*" />
  </Grid.ColumnDefinitions>
</Grid>
```

## Implementation

LayoutView uses Grid for a fixed sidebar and a flexible content area, StackPanel for a vertical group, and DockPanel for a header plus filling content. Auto sizes to content; star sizing shares remaining space; a numeric size uses device-independent units. Margin reserves space outside a control; Padding creates space inside a supporting control.

Start with [LayoutView.xaml](LayoutView.xaml) and its [code-behind](LayoutView.xaml.cs). Read the XML comments in the C# classes and the local XAML comments for implementation details.

## Use cases

Use Grid for aligned forms and resizable pages, StackPanel for simple one-dimensional groups, and DockPanel for edge-docked content. Canvas is useful for deliberate coordinate positioning rather than ordinary forms.

## Best practices

Avoid fixing every width and height. Test resizing, larger fonts, and long labels. A StackPanel offers effectively unbounded space along its stacking direction, which can interfere with expected scrolling or stretching. Use row/column definitions to express relationships.

## Run and verify

On Windows with the .NET 10 SDK, run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` from the repository root. The XAML view and its tests belong to this same project; test classes are in Tests.

For an optional visual check, open LayoutView.xaml in the Visual Studio XAML designer and vary the preview width. The 180-unit sidebar stays fixed while the right area changes. The heading wraps and the footer remains in its fixed-height row.

[Automated tests](../Tests/LayoutTests.cs) verify the core contract. Run `dotnet test Topics/Wpf.Tests/Wpf.Tests.csproj` on Windows. Control tests use an STA thread; these do not replace visual inspection.

## Related reading

- [DataBinding](../DataBinding/README.md)
- [C# events](../../CSharp.Tests/Events/README.md) and [delegates](../../CSharp.Tests/Delegates/README.md)
- [WPF project guide](../README.md)
- [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/advanced/layout)
