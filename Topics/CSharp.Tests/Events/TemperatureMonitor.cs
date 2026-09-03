namespace DevLab.CSharp.Events;

/// <summary>Stores a Celsius reading and notifies subscribers when it changes.</summary>
/// <remarks>
/// Adapted from the course temperature monitor. This topic uses decimal Celsius values
/// to focus on events rather than unit conversion or a physical simulation.
/// Calls are synchronous and intended for a single thread. Reentrant handlers can cause
/// nested notifications; handlers should normally observe the sensor, not write to it.
/// </remarks>
public class TemperatureMonitor
{
    private decimal _temperature;

    /// <summary>Initializes the sensor without raising a change event.</summary>
    /// <param name="initialTemperature">The initial Celsius reading, at least absolute zero.</param>
    /// <exception cref="ArgumentOutOfRangeException">The reading is below -273.15 Celsius.</exception>
    public TemperatureMonitor(decimal initialTemperature)
    {
        Validate(initialTemperature);
        _temperature = initialTemperature;
    }

    /// <summary>Gets or sets the current Celsius reading; equal assignments do not notify.</summary>
    /// <remarks>
    /// State is updated before invoking subscribers, so a handler reading this property
    /// sees the new value. A throwing handler propagates its exception to the setter and
    /// stops subsequent handlers. The committed reading is not rolled back.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">The reading is below -273.15 Celsius.</exception>
    public decimal Temperature
    {
        get => _temperature;
        set
        {
            Validate(value);
            if (_temperature == value) return;
            decimal previous = _temperature;
            _temperature = value;
            OnTemperatureChanged(new TemperatureChangedEventArgs(previous, value));
        }
    }

    /// <summary>Occurs after a changed reading is stored.</summary>
    /// <remarks>
    /// EventHandler&lt;TemperatureChangedEventArgs&gt; defines the handler signature.
    /// Consumers can add or remove handlers, but cannot raise or replace this event.
    /// </remarks>
    public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;

    /// <summary>Provides a derived-class extension point for raising notifications.</summary>
    /// <param name="e">The readings to deliver to each subscribed handler.</param>
    /// <remarks>Call the base implementation to deliver the notification; omitting it suppresses delivery.</remarks>
    protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        => TemperatureChanged?.Invoke(this, e);

    private static void Validate(decimal value)
    {
        if (value < -273.15m)
            throw new ArgumentOutOfRangeException(nameof(value), value, "Temperature cannot be below absolute zero.");
    }
}
