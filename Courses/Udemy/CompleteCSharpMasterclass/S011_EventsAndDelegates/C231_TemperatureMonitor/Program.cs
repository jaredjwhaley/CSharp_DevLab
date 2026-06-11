using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace C231_TemperatureMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // HVAC approximation formula:
            //   BTU/hr = (Volume in cub ft) x (Indoor/Outdoor Difference in °F) x (Air Changes per Hour(???)) * 0.018
            // Simplified HVAC approximation formula:
            //   °F/hr = (BTU/hr) / ((Volume in cub ft) * 0.133)

            Temperature outdoorTemperature = Temperature.FromFahrenheit(91);
            Room room = new Room(outdoorTemperature, 4400, 0.06);
            Thermostat thermostat = new Thermostat(Temperature.FromFahrenheit(65), Temperature.FromFahrenheit(69));
            room.Thermostat = thermostat;
            thermostat.AirConditioners[0].BtuHr = 12000;
            thermostat.TemperatureMonitor.Temperature = room.Temperature;

            while (true)
            {
                double deltaTimeInMinutes = 1;
                // Simulate temperature change based on outdoor temperature, insulation, and AC effect.
                // NOTE: This is a very simplified model and does not reflect real-world physics.
                room.Temperature = Temperature.FromFahrenheit(
                    room.Temperature.DegreesFahrenheit
                    + ((room.InsulationFactor * room.CubicFootage
                        * (outdoorTemperature.DegreesFahrenheit - room.Temperature.DegreesFahrenheit))
                        - (thermostat.AirConditioners[0].IsOn ? thermostat.AirConditioners[0].BtuHr : 0)) / (60 * room.AirMass * 0.24)
                );
                // Detect Temperature change and update the thermostat's temperature monitor.
                room.Thermostat?.TemperatureMonitor.Temperature = room.Temperature;
                if (Console.KeyAvailable) break;
                Thread.Sleep(1000);
            }
        }
    }
}