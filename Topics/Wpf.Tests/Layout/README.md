# Layout

Layout arranges controls within available space. WPF measures desired sizes and then arranges children in the space their parent supplies.

## Syntax

```xml
<!-- Inside a WPF view, Grid arranges children into rows and columns.
     Unassigned Grid.Row and Grid.Column values default to zero. -->
<Grid Margin="12">
  <!-- Margin reserves space OUTSIDE this Grid, between it and its parent. -->
  <Grid.RowDefinitions>
    <RowDefinition Height="Auto" /> <!-- Fit this row to its content. -->
    <RowDefinition Height="*" />    <!-- Give this row the remaining height. -->
  </Grid.RowDefinitions>
  <Grid.ColumnDefinitions>
    <ColumnDefinition Width="180" /> <!-- Fixed device-independent units. -->
    <ColumnDefinition Width="*" />   <!-- Remaining width; not a fixed size. -->
  </Grid.ColumnDefinitions>

  <!-- Grid.ColumnSpan is an attached property: Grid interprets it when arranging
       this child. Spanning two columns makes this heading cover the full width. -->
  <TextBlock Grid.ColumnSpan="2" Text="Heading" />
  <Button Grid.Row="1" Grid.Column="0" Content="Sidebar" />
  <Border Grid.Row="1" Grid.Column="1" Padding="12" Background="AliceBlue">
    <!-- Padding reserves space INSIDE this Border, around its child. -->
    <TextBlock Text="Flexible content area" />
  </Border>
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
