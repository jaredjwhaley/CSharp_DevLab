using System;
using System.Collections.Generic;
using System.Text;

namespace C231_TemperatureMonitor
{
    public class Room
    {
        public double CubicFootage { get; set; }
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
        public Room(
            double cubicFootage,
            AirConditioner? airConditioner = null,
            Thermostat? thermostat = null,
            IList<TemperatureMonitor>? standaloneTemperatureMonitors = null)
        {
            CubicFootage = cubicFootage;
            AirConditioner = airConditioner;
            Thermostat = thermostat;
            StandaloneTemperatureMonitors = standaloneTemperatureMonitors
                ?? new List<TemperatureMonitor>();
        }
    }
}
