namespace DevLab.Wpf.Tests.Mvvm;
/// <summary>Represents task data independently of WPF controls.</summary>
public sealed class TaskItem
{
    /// <summary>Gets the immutable display title.</summary>
    public string Title { get; }
    /// <summary>Creates a task with a nonblank, trimmed title.</summary>
    /// <param name="title">The task title.</param>
    /// <exception cref="ArgumentException">The title is null, empty, or whitespace.</exception>
    public TaskItem(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("A title is required.", nameof(title));
        Title = title.Trim();
    }
}
