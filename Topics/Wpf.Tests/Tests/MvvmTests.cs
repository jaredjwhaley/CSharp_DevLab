using System.Windows;
using System.Windows.Controls;
using DevLab.Wpf.Tests.Mvvm;
namespace DevLab.Wpf.Tests;
/// <summary>Verifies the Mvvm example's observable behavior.</summary>
public class MvvmTests
{
    /// <summary>Adds trimmed tasks, clears input, and removes only a valid selected task.</summary>
    [Fact]
    public void TaskList_AddsAndRemovesThroughCommands()
    {
        var model = new TaskListViewModel();
        Assert.False(model.AddCommand.CanExecute(null));
        model.Draft = "  Read Events  ";
        Assert.True(model.AddCommand.CanExecute(null));
        model.AddCommand.Execute(null);
        Assert.Equal("Read Events", Assert.Single(model.Tasks).Title);
        Assert.Equal(string.Empty, model.Draft);
        Assert.False(model.RemoveCommand.CanExecute(null));
        model.SelectedTask = model.Tasks[0];
        Assert.True(model.RemoveCommand.CanExecute(null));
        model.RemoveCommand.Execute(null);
        Assert.Empty(model.Tasks);
        Assert.Null(model.SelectedTask);
    }

    /// <summary>Whitespace drafts and selections from outside the collection cannot mutate the task list.</summary>
    [Fact]
    public void TaskList_RejectsInvalidOperations()
    {
        var model = new TaskListViewModel { Draft = "   " };
        model.AddCommand.Execute(null);
        Assert.Empty(model.Tasks);
        model.SelectedTask = new TaskItem("Foreign");
        Assert.False(model.RemoveCommand.CanExecute(null));
        model.RemoveCommand.Execute(null);
        Assert.Empty(model.Tasks);
        Assert.Throws<ArgumentException>(() => new TaskItem(" "));
    }
}
