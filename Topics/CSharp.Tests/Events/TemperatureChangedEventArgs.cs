namespace DevLab.CSharp.Events;

/// <summary>Contains immutable Celsius readings for one temperature change.</summary>
public sealed class TemperatureChangedEventArgs : EventArgs
{
    /// <summary>Gets the reading before the change, in degrees Celsius.</summary>
    public decimal OldTemperature { get; }
    /// <summary>Gets the reading after the change, in degrees Celsius.</summary>
    public decimal NewTemperature { get; }

    /// <summary>Records the two readings without retaining a mutable sensor reference.</summary>
    /// <param name="oldTemperature">The previous Celsius reading.</param>
    /// <param name="newTemperature">The new Celsius reading.</param>
    public TemperatureChangedEventArgs(decimal oldTemperature, decimal newTemperature)
    {
        OldTemperature = oldTemperature;
        NewTemperature = newTemperature;
    }
}
