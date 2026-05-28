namespace C231_TemperatureMonitor
{

    public class TemperatureChangedEventArgs : EventArgs
    {
        public Temperature OldTemperature { get; }
        public Temperature NewTemperature { get; }
        public TemperatureChangedEventArgs(Temperature oldTemp, Temperature newTemp)
        {
            OldTemperature = oldTemp;
            NewTemperature = newTemp;
        }
    }

    /// <summary>
    /// Monitors a Temperature value and raises the TemperatureChanged event when the value changes.
    /// </summary>
    /// <remarks>Maintains the last known temperature. Assigning to the Temperature property updates the
    /// stored value and invokes OnTemperatureChanged (raising TemperatureChanged) only when the new value differs from
    /// the previous one. The constructor initializes the last known temperature.</remarks>
    public class TemperatureMonitor
    {
        // Backing field for the last known temperature.
        //   - This is used to determine if the temperature has changed
        private Temperature _lastKnownTemp;

        /// <summary>
        /// Gets or sets the last known temperature.
        /// </summary>
        /// <remarks>Setting the property updates the stored temperature and invokes OnTemperatureChanged
        /// with a TemperatureChangedEventArgs when the value changes. Assigning the same value does not raise the change
        /// notification.</remarks>
        public Temperature Temperature
        {
            get { return _lastKnownTemp; }
            set
            {
                // Only raise the event if the temperature has actually changed.
                if (_lastKnownTemp != value)
                {
                    // Update the last known temperature and raise the event.
                    _lastKnownTemp = value;
                    OnTemperatureChanged(new TemperatureChangedEventArgs(_lastKnownTemp, value));
                }
            }
        }

        /// <summary>
        /// Initializes a new TemperatureMonitor and records the provided temperature as the last known value.
        /// </summary>
        /// <param name="temperature">The initial last known temperature.</param>
        public TemperatureMonitor(Temperature temperature)
        {
            _lastKnownTemp = temperature;
        }

        /// <summary>
        /// Occurs when the temperature changes.
        /// </summary>
        /// <remarks>Provides the new temperature value in the TemperatureChangedEventArgs. Subscribers
        /// can handle this event to respond to temperature changes.</remarks>
        public event EventHandler<TemperatureChangedEventArgs> ?TemperatureChanged;
        protected void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
    }

    public class Thermostat
    {
        public Temperature MaxTemperature { get; set; }
        public Temperature MinTemperature { get; set; }
        public TemperatureMonitor TemperatureMonitor { get; set; }
        public IList<AirConditioner> AirConditioners { get; set; }

        public Thermostat(Temperature minTemp, Temperature maxTemp, TemperatureMonitor? sensor = null, IList<AirConditioner>? airConditioners = null)
        {
            MinTemperature = minTemp;
            MaxTemperature = maxTemp;
            TemperatureMonitor = sensor ?? new TemperatureMonitor(new Temperature(20, Temperature.UnitTypes.Celsius));
            AirConditioners = airConditioners ?? new List<AirConditioner>() { new AirConditioner() };

        }

        public void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            if (e.NewTemperature > MaxTemperature)
            {
                Console.WriteLine($"Temperature is {e.NewTemperature:F0}°F. Turning on AC.");
            }
            else if (e.NewTemperature < MinTemperature)
            {
                Console.WriteLine($"Temperature is {e.NewTemperature:F0}°F. Turning on heater.");
            }
            else
            {
                Console.WriteLine($"Temperature is {e.NewTemperature:F0}°F. Temperature is within the comfortable range.");
            }
        }
    }

    public class AirConditioner
    {
        public int Btus { get; set; }

        public AirConditioner(int btus = 5000)
        {
            Btus = btus;
        }

    }
    internal partial class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}