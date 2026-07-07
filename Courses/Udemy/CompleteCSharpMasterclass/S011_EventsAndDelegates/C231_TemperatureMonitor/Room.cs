using System;
using System.Collections.Generic;
using System.Text;

namespace C231_TemperatureMonitor
{
    /// <summary>
    /// Represents a room with properties for temperature, cubic footage, insulation factor, and associated devices like air conditioners and thermostats.
    /// </summary>
    public class Room
    {

        /// <summary>
        /// Gets or sets the current temperature of the room.
        /// </summary>
        public Temperature Temperature { get; set; }
        /// <summary>
        /// Gets or sets the cubic footage of the room, which is used to calculate air mass and other properties.
        /// </summary>
        public double CubicFootage { get; set; }
        /// <summary>
        /// Gets or sets the insulation factor of the room, which affects how quickly the room's
        /// temperature changes in response to external conditions.
        /// </summary>
        /// <remarks>
        /// The insulation factor is a value between 0 and 1, where 0 indicates no insulation (the
        /// room loses heat quickly) and 1 indicates perfect insulation (the room retains heat
        /// perfectly).
        /// </remarks>
        public double InsulationFactor { get; set; }
        /// <summary>
        /// Gets or sets a list of standalone temperature monitors in the room.
        /// </summary>
        /// <remarks>
        /// These monitors are still connected to the thermostat, but they are not the primary
        /// temperature monitor for that thermostat.
        /// </remarks>
        public IList<TemperatureMonitor> StandaloneTemperatureMonitors { get; set; } = new List<TemperatureMonitor>();
        /// <summary>
        /// Gets or sets the air conditioner associated with the room, if any.
        /// </summary>
        public AirConditioner? AirConditioner { get; set; }
        /// <summary>
        /// Gets or sets the thermostat associated with the room, if any.
        /// </summary>
        public Thermostat? Thermostat { get; set; }
        /// <summary>
        /// Gets an enumerable collection of all temperature monitors in the room, including the thermostat's primary monitor and any standalone monitors.
        /// </summary>
        public IEnumerable<TemperatureMonitor> TemperatureMonitors
        {
            get {
                if (Thermostat != null && Thermostat.TemperatureMonitor != null)
                {
                    yield return Thermostat.TemperatureMonitor;
                }
                foreach (var temperatureMonitor in StandaloneTemperatureMonitors) {
                    yield return temperatureMonitor;
                }
            }
        }

        /// <summary>
        /// Gets the air density in the room, calculated based on the current temperature and standard atmospheric pressure.
        /// </summary>
        /// <remarks>
        /// Measured in lbs/ft³ at sea level
        /// <\remarks>
        public double AirDensity { get { return 101325 / (287.058 * this.Temperature.DegreesKelvin) * 0.062428; } }

        /// <summary>
        /// Gets the air mass in the room, calculated as the product of air density and cubic footage.
        /// </summary>
        /// <remarks>
        /// Measured in lbs
        /// <\remarks>
        public double AirMass { get { return AirDensity * CubicFootage; } }

        public Room(Temperature temperature,
            double cubicFootage,
            double insulationFactor = 0.2,
            AirConditioner? airConditioner = null,
            Thermostat? thermostat = null,
            IList<TemperatureMonitor>? standaloneTemperatureMonitors = null)
        {
            Temperature = temperature;
            CubicFootage = cubicFootage;
            InsulationFactor = insulationFactor;
            AirConditioner = airConditioner;
            Thermostat = thermostat;
            StandaloneTemperatureMonitors = standaloneTemperatureMonitors
                ?? new List<TemperatureMonitor>();
        }
    }
}
