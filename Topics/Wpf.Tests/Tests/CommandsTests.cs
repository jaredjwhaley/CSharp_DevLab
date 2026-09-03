using System.Windows;
using System.Windows.Controls;
using DevLab.Wpf.Tests.Commands;
namespace DevLab.Wpf.Tests;
/// <summary>Verifies the Commands example's observable behavior.</summary>
public class CommandsTests
{
    /// <summary>Execution respects the upper limit and notifies controls after state changes.</summary>
    [Fact]
    public void Counter_EnforcesEligibilityAndNotifies()
    {
        var model = new CounterViewModel();
        int changes = 0;
        model.IncrementCommand.CanExecuteChanged += (_, _) => changes++;
        Assert.False(model.ResetCommand.CanExecute(null));
        for (int i = 0; i < 4; i++) model.IncrementCommand.Execute(null);
        Assert.Equal(3, model.Count);
        Assert.Equal(3, changes);
        Assert.False(model.IncrementCommand.CanExecute(null));
        model.ResetCommand.Execute(null);
        Assert.Equal(0, model.Count);
        Assert.True(model.IncrementCommand.CanExecute(null));
    }

    /// <summary>Rejects a missing action and forwards a permitted action's exception.</summary>
    [Fact]
    public void Command_ValidatesActionAndPropagatesFailure()
    {
        Assert.Throws<ArgumentNullException>(() => new RelayCommand(null!));
        var command = new RelayCommand(() => throw new InvalidOperationException());
        Assert.Throws<InvalidOperationException>(() => command.Execute(null));
    }
}
