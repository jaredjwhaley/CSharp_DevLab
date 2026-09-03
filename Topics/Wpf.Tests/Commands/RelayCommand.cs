using System.Windows.Input;
namespace DevLab.Wpf.Tests.Commands;
/// <summary>Adapts an action and optional predicate to the ICommand contract.</summary>
/// <remarks>
/// This synchronous teaching command explicitly signals eligibility changes rather than
/// relying on CommandManager polling. It is not an async command or exception handler.
/// </remarks>
public sealed class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;
    /// <summary>Creates a command from its behavior and availability rule.</summary>
    /// <param name="execute">The synchronous action to perform.</param>
    /// <param name="canExecute">The availability predicate, or null to always allow execution.</param>
    /// <exception cref="ArgumentNullException">The action is null.</exception>
    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        ArgumentNullException.ThrowIfNull(execute);
        _execute = execute;
        _canExecute = canExecute ?? (() => true);
    }
    /// <summary>Occurs when controls should query CanExecute again.</summary>
    public event EventHandler? CanExecuteChanged;
    /// <summary>Reports whether execution is currently allowed.</summary>
    /// <param name="parameter">Unused by this parameterless teaching command.</param>
    /// <returns>The current result of the supplied predicate.</returns>
    public bool CanExecute(object? parameter) => _canExecute();
    /// <summary>Performs the action only if the availability rule currently permits it.</summary>
    /// <param name="parameter">Unused by this parameterless teaching command.</param>
    public void Execute(object? parameter)
    {
        if (CanExecute(parameter)) _execute();
    }
    /// <summary>Requests that bound controls refresh their enabled state.</summary>
    public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
