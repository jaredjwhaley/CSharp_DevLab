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


            Console.WriteLine("Hello, World!");
        }
    }
}