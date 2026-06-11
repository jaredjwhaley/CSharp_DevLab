namespace C231_TemperatureMonitor
{
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
                    OnTemperatureChanged(new TemperatureChangedEventArgs(_lastKnownTemp, value));
                    _lastKnownTemp = value;
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
        public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;

        /// <summary>
        /// Raises the TemperatureChanged event with the provided TemperatureChangedEventArgs.
        /// </summary>
        /// <param name="e"></param>
        protected void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
    }
}