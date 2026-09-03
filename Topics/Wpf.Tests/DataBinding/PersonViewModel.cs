using System.ComponentModel;
namespace DevLab.Wpf.Tests.DataBinding;
/// <summary>Notifies bindings when a source property or its dependent display value changes.</summary>
public sealed class PersonViewModel : INotifyPropertyChanged
{
    private string _name = "Ada";
    /// <summary>Occurs when a binding should reread a property.</summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    /// <summary>Gets or sets the editable name; equal assignments do not notify.</summary>
    public string Name
    {
        get => _name;
        set
        {
            value ??= string.Empty;
            if (_name == value) return;
            _name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Greeting)));
        }
    }
    /// <summary>Gets a greeting derived from the current name.</summary>
    public string Greeting => $"Hello, {Name}!";
}
