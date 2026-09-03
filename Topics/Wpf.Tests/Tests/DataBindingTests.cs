using System.Windows;
using System.Windows.Controls;
using DevLab.Wpf.Tests.DataBinding;
namespace DevLab.Wpf.Tests;
/// <summary>Verifies the DataBinding example's observable behavior.</summary>
public class DataBindingTests
{
    /// <summary>Loads a real binding and transfers edits in both directions on the STA thread.</summary>
    [Fact]
    public void Binding_TransfersSourceAndTarget() => Sta.Run(() =>
    {
        var view = new DataBindingView();
        var window = new Window
        {
            Content = view,
            Width = 420,
            Height = 200,
            ShowInTaskbar = false,
            ShowActivated = false
        };
        try
        {
            // Construction alone does not run the queued work that attaches bindings
            // and resolves inherited DataContext. Load the real view, then process
            // pending layout, Loaded, and data-binding operations before asserting.
            window.Show();
            Sta.DrainDispatcher();
            Assert.True(view.IsLoaded);

            var model = (PersonViewModel)view.DataContext;
            var input = (TextBox)view.FindName("NameInput");
            var output = (TextBlock)view.FindName("GreetingOutput");
            Assert.Same(model, input.DataContext);
            Assert.Equal("Ada", input.Text);
            Assert.Equal("Hello, Ada!", output.Text);

            // Preserve the binding while changing the target value. PropertyChanged
            // update timing should propagate the edit without a manual UpdateSource.
            input.SetCurrentValue(TextBox.TextProperty, "Grace");
            Sta.DrainDispatcher();
            Assert.Equal("Grace", model.Name);
            Assert.Equal("Hello, Grace!", output.Text);

            // Verify the opposite direction through the actual change notifications,
            // without forcing UpdateTarget and potentially hiding a broken binding.
            model.Name = "Linus";
            Sta.DrainDispatcher();
            Assert.Equal("Linus", input.Text);
            Assert.Equal("Hello, Linus!", output.Text);
        }
        finally
        {
            window.Close();
        }
    });

    /// <summary>Raises dependent property notifications once and ignores an unchanged name.</summary>
    [Fact]
    public void PropertyChanges_IncludeDependentGreeting()
    {
        var model = new PersonViewModel();
        var names = new List<string?>();
        model.PropertyChanged += (_, e) => names.Add(e.PropertyName);
        model.Name = "Grace";
        model.Name = "Grace";
        Assert.Equal(new[] { "Name", "Greeting" }, names);
    }
}
