namespace DevLab.CSharp.Events;

/// <summary>Subscribes to a sensor and controls air conditioners using two thresholds.</summary>
/// <remarks>
/// At or above the upper threshold, cooling turns on. At or below the lower threshold,
/// it turns off. Between thresholds, each actuator retains its state (hysteresis).
/// This avoids toggling around one boundary. Construction evaluates the current reading,
/// so an already-hot room does not wait for a future change. Dispose detaches the handler;
/// it does not dispose the borrowed sensor/actuators or change their final state.
/// </remarks>
public sealed class Thermostat : IDisposable
{
    private readonly TemperatureMonitor _sensor;
    private readonly AirConditioner[] _airConditioners;
    private bool _disposed;

    /// <summary>Gets the Celsius threshold at or below which cooling stops.</summary>
    public decimal LowerThreshold { get; }
    /// <summary>Gets the Celsius threshold at or above which cooling starts.</summary>
    public decimal UpperThreshold { get; }

    /// <summary>Validates configuration, subscribes once, and applies the current reading.</summary>
    /// <param name="sensor">The borrowed sensor to observe.</param>
    /// <param name="lowerThreshold">The cooling-off threshold, at least absolute zero.</param>
    /// <param name="upperThreshold">The cooling-on threshold, strictly above the lower threshold.</param>
    /// <param name="airConditioners">Borrowed actuators; the sequence is copied once and may be empty.</param>
    /// <exception cref="ArgumentNullException">The sensor or actuator sequence is null.</exception>
    /// <exception cref="ArgumentException">An actuator entry is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thresholds are physically invalid or unordered.</exception>
    public Thermostat(TemperatureMonitor sensor, decimal lowerThreshold, decimal upperThreshold,
        IEnumerable<AirConditioner> airConditioners)
    {
        ArgumentNullException.ThrowIfNull(sensor);
        ArgumentNullException.ThrowIfNull(airConditioners);
        if (lowerThreshold < -273.15m)
            throw new ArgumentOutOfRangeException(nameof(lowerThreshold));
        if (upperThreshold <= lowerThreshold)
            throw new ArgumentOutOfRangeException(nameof(upperThreshold));
        _airConditioners = airConditioners.ToArray();
        if (_airConditioners.Any(ac => ac is null))
            throw new ArgumentException("Actuators cannot contain null.", nameof(airConditioners));
        _sensor = sensor;
        LowerThreshold = lowerThreshold;
        UpperThreshold = upperThreshold;
        _sensor.TemperatureChanged += HandleTemperatureChanged;
        Apply(_sensor.Temperature);
    }

    // Keep the named handler so disposal removes exactly the delegate that was added.
    private void HandleTemperatureChanged(object? sender, TemperatureChangedEventArgs e)
        => Apply(e.NewTemperature);

    private void Apply(decimal temperature)
    {
        foreach (var ac in _airConditioners)
        {
            if (temperature >= UpperThreshold) ac.TurnOn();
            else if (temperature <= LowerThreshold) ac.TurnOff();
        }
    }

    /// <summary>Unsubscribes once, ending the subscription lifetime.</summary>
    /// <remarks>Safe to call repeatedly; intended for the same thread as sensor updates.</remarks>
    public void Dispose()
    {
        if (_disposed) return;
        _sensor.TemperatureChanged -= HandleTemperatureChanged;
        _disposed = true;
    }
}
