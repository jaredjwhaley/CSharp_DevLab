using System;
using System.Collections.Generic;
using System.Text;

namespace C231_TemperatureMonitor
{
    public class Room
    {

        public Temperature Temperature { get; set; }
        public double CubicFootage { get; set; }
        public double InsulationFactor { get; set; }
        public IList<TemperatureMonitor> StandaloneTemperatureMonitors { get; set; } = new List<TemperatureMonitor>();
        public AirConditioner? AirConditioner { get; set; }
        public Thermostat? Thermostat { get; set; }
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

        // Measured in lbs/ft³ at sea level
        public double AirDensity { get { return 101325 / (287.058 * this.Temperature.DegreesKelvin) * 0.062428; } }

        // Mass of the air in the room, in pounds.
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
