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
}