using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DevLab.Wpf.Tests.Commands;
namespace DevLab.Wpf.Tests.Mvvm;
/// <summary>Owns task-list presentation state and operations without referring to UI controls.</summary>
/// <remarks>
/// ObservableCollection reports membership changes. INotifyPropertyChanged reports changes
/// to Draft and SelectedTask. The read-only wrapper prevents callers bypassing the commands.
/// This view model and its collection are intended for the UI thread.
/// </remarks>
public sealed class TaskListViewModel : INotifyPropertyChanged
{
    private readonly ObservableCollection<TaskItem> _tasks = [];
    private string _draft = string.Empty;
    private TaskItem? _selectedTask;
    /// <summary>Gets an observable read-only view of the task collection.</summary>
    public ReadOnlyObservableCollection<TaskItem> Tasks { get; }
    /// <summary>Gets the command that adds a nonblank draft and clears the input.</summary>
    public RelayCommand AddCommand { get; }
    /// <summary>Gets the command that removes an existing selection.</summary>
    public RelayCommand RemoveCommand { get; }
    /// <summary>Occurs when a scalar presentation property changes.</summary>
    public event PropertyChangedEventHandler? PropertyChanged;
    /// <summary>Gets or sets the editable draft title.</summary>
    public string Draft
    {
        get => _draft;
        set
        {
            value ??= string.Empty;
            if (_draft == value) return;
            _draft = value;
            Notify();
            AddCommand.NotifyCanExecuteChanged();
        }
    }
    /// <summary>Gets or sets the selected task; null means no selection.</summary>
    public TaskItem? SelectedTask
    {
        get => _selectedTask;
        set
        {
            if (ReferenceEquals(_selectedTask, value)) return;
            _selectedTask = value;
            Notify();
            RemoveCommand.NotifyCanExecuteChanged();
        }
    }
    /// <summary>Initializes commands and the observable collection view.</summary>
    public TaskListViewModel()
    {
        Tasks = new ReadOnlyObservableCollection<TaskItem>(_tasks);
        AddCommand = new RelayCommand(Add, () => !string.IsNullOrWhiteSpace(Draft));
        RemoveCommand = new RelayCommand(Remove, () => SelectedTask is not null && _tasks.Contains(SelectedTask));
    }
    private void Add()
    {
        _tasks.Add(new TaskItem(Draft));
        Draft = string.Empty;
        RemoveCommand.NotifyCanExecuteChanged();
    }
    private void Remove()
    {
        if (SelectedTask is null) return;
        _tasks.Remove(SelectedTask);
        SelectedTask = null;
    }
    private void Notify([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
