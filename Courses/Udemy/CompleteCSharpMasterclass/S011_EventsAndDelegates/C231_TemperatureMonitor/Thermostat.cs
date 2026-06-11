using System;
using System.Collections.Generic;
using System.Text;

namespace C231_TemperatureMonitor
{
    public class Thermostat
    {
        public Temperature MaxTemperature { get; set; }
        public Temperature MinTemperature { get; set; }

        private TemperatureMonitor? _temperatureMonitor;
        public TemperatureMonitor TemperatureMonitor
        {
            get => _temperatureMonitor;
            set
            {
                if (_temperatureMonitor != null && _temperatureMonitor != value)
                {
                    _temperatureMonitor.TemperatureChanged -= HandleTemperatureChanged;
                }

                _temperatureMonitor = value;

                if (_temperatureMonitor != null)
                {
                    _temperatureMonitor.TemperatureChanged += HandleTemperatureChanged;
                }
            }
        }
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
            Console.Write($"Temperature is {e.NewTemperature:F0}.");
            if (e.NewTemperature > MaxTemperature)
            {
                Console.WriteLine($" Turning on AC.");
                foreach (var ac in AirConditioners)
                {
                    ac.TurnOn();
                }
            }
            else if (e.NewTemperature < MinTemperature)
            {
                Console.WriteLine($".. Guess we're gonna freeze.");
                foreach (var ac in AirConditioners)
                {
                    // Heaters don't exist
                    ac.TurnOff();
                }
            }
            else
            {
                Console.WriteLine();
                foreach (var ac in AirConditioners)
                {
                    ac.TurnOff();
                }
            }
        }
    }
}
