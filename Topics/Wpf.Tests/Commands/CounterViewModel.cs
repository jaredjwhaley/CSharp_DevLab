using System.ComponentModel;
namespace DevLab.Wpf.Tests.Commands;
/// <summary>Demonstrates command availability as a function of presentation state.</summary>
public sealed class CounterViewModel : INotifyPropertyChanged
{
    /// <summary>Gets the number of accepted increments.</summary>
    public int Count { get; private set; }
    /// <summary>Gets the command that increments while Count is below three.</summary>
    public RelayCommand IncrementCommand { get; }
    /// <summary>Gets the command that resets a nonzero count.</summary>
    public RelayCommand ResetCommand { get; }
    /// <summary>Occurs when the displayed count changes.</summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    /// <summary>Connects state transitions to commands.</summary>
    public CounterViewModel()
    {
        IncrementCommand = new RelayCommand(() => SetCount(Count + 1), () => Count < 3);
        ResetCommand = new RelayCommand(() => SetCount(0), () => Count != 0);
    }
    private void SetCount(int count)
    {
        Count = count;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
        IncrementCommand.NotifyCanExecuteChanged();
        ResetCommand.NotifyCanExecuteChanged();
    }
}
