using System.Windows.Controls;
namespace DevLab.Wpf.Tests.DataBinding;
/// <summary>Demonstrates DataBinding in an independently constructible view.</summary>
public partial class DataBindingView : UserControl
{
    /// <summary>Loads the markup and initializes this example's state.</summary>
    public DataBindingView()
    {
        InitializeComponent();
        DataContext = new PersonViewModel();
    }
}
