using System.Windows.Controls;
namespace DevLab.Wpf.Tests.Commands;
/// <summary>Demonstrates Commands in an independently constructible view.</summary>
public partial class CommandsView : UserControl
{
    /// <summary>Loads the markup and initializes this example's state.</summary>
    public CommandsView()
    {
        InitializeComponent();
        DataContext = new CounterViewModel();
    }
}
