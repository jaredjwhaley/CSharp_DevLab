namespace C231_TemperatureMonitor
{
    /// <summary>
    /// Event arguments for the TemperatureChanged event, containing the old and new temperature values.
    /// </summary>
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
}