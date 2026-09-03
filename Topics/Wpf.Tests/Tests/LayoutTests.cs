using System.Windows;
using System.Windows.Controls;
using DevLab.Wpf.Tests.Layout;
namespace DevLab.Wpf.Tests;
/// <summary>Verifies the Layout example's observable behavior.</summary>
public class LayoutTests
{
    /// <summary>Loads compiled markup and verifies the fixed column and fill column behavior.</summary>
    [Fact]
    public void Grid_UsesFixedAndStarColumns() => Sta.Run(() =>
    {
        var view = new LayoutView();
        var grid = (Grid)view.FindName("ExampleGrid");
        view.Measure(new Size(800, 500));
        view.Arrange(new Rect(0, 0, 800, 500));
        Assert.Equal(180.0, grid.ColumnDefinitions[0].ActualWidth);
        Assert.True(grid.ColumnDefinitions[1].ActualWidth > 180);
        Assert.True(grid.RowDefinitions[0].Height.IsAuto);
    });
}
