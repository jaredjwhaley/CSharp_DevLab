namespace C231_TemperatureMonitor
{
    /// <summary>
    /// Represents an air conditioner with a specified heat transfer rate (BTU/hr) and on/off state.
    /// </summary>
    public class AirConditioner
    {
        /// <summary>
        /// Heat transfer rate in British thermal units per hour.
        /// </summary>
        /// <remarks>Values are expected to be non‑negative.</remarks>
        public int BtuHr { get; set; }
        // - 1 BTU = ~1.05506 Kilojoules.
        // - The Btu/hr rating of an air conditioner indicates how much heat it can remove from a
        //   room in one hour.
        public bool _isOn;
        public bool IsOn { get => _isOn;}
        public bool IsOff { get => !_isOn;}

        public AirConditioner(int btuHr = 5000)
        {
            BtuHr = btuHr;
        }

        public void TurnOn()
        {
            _isOn = true;
        }

        public void TurnOff() {
            _isOn = false;
        }
    }
}