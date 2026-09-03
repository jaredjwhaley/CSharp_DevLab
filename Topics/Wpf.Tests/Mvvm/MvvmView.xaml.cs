using System.Windows.Controls;
namespace DevLab.Wpf.Tests.Mvvm;
/// <summary>Demonstrates Mvvm in an independently constructible view.</summary>
public partial class MvvmView : UserControl
{
    /// <summary>Loads the markup and initializes this example's state.</summary>
    public MvvmView()
    {
        InitializeComponent();
        DataContext = new TaskListViewModel();
    }
}
