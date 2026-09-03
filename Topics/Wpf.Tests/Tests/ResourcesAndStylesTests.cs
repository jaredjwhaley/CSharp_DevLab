using System.Windows;
using System.Windows.Controls;
using DevLab.Wpf.Tests.ResourcesAndStyles;
namespace DevLab.Wpf.Tests;
/// <summary>Verifies the ResourcesAndStyles example's observable behavior.</summary>
public class ResourcesAndStylesTests
{
    /// <summary>Loads the keyed style and verifies the disabled-state trigger.</summary>
    [Fact]
    public void Style_UsesSharedResourceAndTrigger() => Sta.Run(() =>
    {
        var view = new ResourcesAndStylesView();
        var enabled = (Button)view.FindName("EnabledExample");
        var disabled = (Button)view.FindName("DisabledExample");
        Assert.Same(enabled.Style, disabled.Style);
        Assert.Equal(1.0, enabled.Opacity);
        Assert.Equal(0.45, disabled.Opacity);
        var preview = (Border)view.FindName("DynamicPreview");
        var replacement = System.Windows.Media.Brushes.Coral;
        view.Resources["AccentBrush"] = replacement;
        Assert.Same(replacement, preview.Background);
    });
}
