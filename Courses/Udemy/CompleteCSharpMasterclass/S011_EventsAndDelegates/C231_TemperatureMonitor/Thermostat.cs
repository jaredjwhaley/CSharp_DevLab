using System;
using System.Collections.Generic;
using System.Text;

namespace C231_TemperatureMonitor
{
    /// <summary>
    /// Model of an event driven thermostat that monitors temperature and controls air conditioners
    /// based on specified minimum and maximum temperature thresholds.
    /// </summary>
    /// <remarks>
    /// The Thermostat class subscribes to temperature change events from a TemperatureMonitor
    /// and turns air conditioners on or off based on the current temperature relative to the
    /// defined thresholds.
    /// </remarks>
    public class Thermostat
    {
        /// <summary>
        /// Gets or sets the maximum temperature threshold for the thermostat. If the monitored
        /// temperature exceeds this value, the thermostat will turn on the air conditioners.
        /// </summary>
        public Temperature MaxTemperature { get; set; }
        /// <summary>
        /// Gets or sets the minimum temperature threshold for the thermostat. If the monitored
        /// temperature falls below this value, the thermostat will turn off the air conditioners.
        /// </summary>
        public Temperature MinTemperature { get; set; }

        private TemperatureMonitor? _temperatureMonitor;
        /// <summary>
        /// Gets or sets the TemperatureMonitor that the thermostat uses to monitor temperature
        /// changes. When set, the thermostat subscribes to the TemperatureChanged event of the
        /// monitor to handle temperature changes accordingly.
        /// </summary>
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
        /// <summary>
        /// Gets or sets the list of AirConditioners that the thermostat controls. The thermostat
        /// will turn these air conditioners on or off based on the monitored temperature relative
        /// to the defined thresholds.
        /// </summary>
        public IList<AirConditioner> AirConditioners { get; set; }

        /// <summary>
        /// Initializes a new instance of the Thermostat class with specified minimum and maximum
        /// temperature thresholds, an optional TemperatureMonitor, and an optional list of
        /// AirConditioners. If no TemperatureMonitor is provided, a default one is created with an
        /// initial temperature of 20°C. If no AirConditioners are provided, a default list
        /// containing one AirConditioner is created.
        /// </summary>
        /// <param name="minTemp">The minimum temperature threshold for the thermostat.</param>
        /// <param name="maxTemp">The maximum temperature threshold for the thermostat.</param>
        /// <param name="sensor">The TemperatureMonitor that the thermostat will use to monitor
        /// temperature changes. If not provided, a default TemperatureMonitor is created with an
        /// initial temperature of 20°C.</param>
        /// <param name="airConditioners">The list of AirConditioners that the thermostat will
        /// control based on temperature changes. If not provided, a default list with one
        /// AirConditioner is created.</param>
        public Thermostat(Temperature minTemp, Temperature maxTemp, TemperatureMonitor? sensor = null, IList<AirConditioner>? airConditioners = null)
        {
            MinTemperature = minTemp;
            MaxTemperature = maxTemp;
            TemperatureMonitor = sensor ?? new TemperatureMonitor(new Temperature(20, Temperature.UnitTypes.Celsius));
            AirConditioners = airConditioners ?? new List<AirConditioner>() { new AirConditioner() };

        }

        /// <summary>
        /// Handles the TemperatureChanged event from the TemperatureMonitor. This method checks
        /// the new temperature against the defined minimum and maximum thresholds and turns the
        /// air conditioners on or off accordingly. If the temperature exceeds the maximum
        /// threshold, it turns on all air conditioners. If it falls below the minimum threshold,
        /// it turns off all air conditioners. If the temperature is within the thresholds, it
        /// ensures that all air conditioners are turned off.
        /// </summary>
        /// <param name="sender">The source of the event, typically the TemperatureMonitor that
        /// raised the event.</param>
        /// <param name="e">The TemperatureChangedEventArgs containing the old and new temperature
        /// values.</param>
        public void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.Write($"Temperature is {e.NewTemperature:F2}.");
            if (e.NewTemperature > MaxTemperature)
            {
                if (AirConditioners.First().IsOff)
                {
                    Console.WriteLine($" Turning on AC.");
                    foreach (var ac in AirConditioners)
                    {
                        ac.TurnOn();
                    }
                    // TODO: for each Heater in Heaters, turn off the heater
                }
                else
                {
                    Console.WriteLine();
                }
            }
            else if (e.NewTemperature < MinTemperature)
            {
                // TODO: Implement Heater class and use them
                Console.WriteLine($".. Guess we're gonna freeze.");
                foreach (var ac in AirConditioners)
                {
                    // Heaters don't exist
                    ac.TurnOff();
                }
            }
            else
            {
                if (AirConditioners.First().IsOn)
                {
                    Console.WriteLine($" Turning off AC.");
                    foreach (var ac in AirConditioners)
                    {
                        ac.TurnOff();
                    }
                } else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
