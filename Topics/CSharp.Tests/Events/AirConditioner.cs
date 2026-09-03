namespace DevLab.CSharp.Events;

/// <summary>Models an actuator's on/off state without simulating heat transfer.</summary>
public sealed class AirConditioner
{
    /// <summary>Gets whether cooling is currently enabled.</summary>
    public bool IsOn { get; private set; }
    /// <summary>Enables cooling; repeating the call is harmless.</summary>
    public void TurnOn() => IsOn = true;
    /// <summary>Disables cooling; repeating the call is harmless.</summary>
    public void TurnOff() => IsOn = false;
}
