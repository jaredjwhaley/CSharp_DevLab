namespace C231_TemperatureMonitor
{
    internal class Program
    {
        
        public class TemperatureEventArgs : EventArgs
        {
            public double Temperature { get; set; }
            public TemperatureEventArgs(double temperature)
            {
                Temperature = temperature;
            }
        }

        public class TemperatureMonitor
        {
            private double _temperature;
            public double Temperature {
                get { return _temperature; }
                set { if (_temperature != value)
                    {
                        _temperature = value;
                        OnTemperatureChanged(new TemperatureEventArgs(_temperature));
                    }
                }
            }

            public TemperatureMonitor(double initialTemperature)
            {
                _temperature = initialTemperature;
            }

            public event EventHandler<TemperatureEventArgs> TemperatureChanged;
            protected void OnTemperatureChanged(TemperatureEventArgs e)
            {
                TemperatureChanged?.Invoke(this, e);
            }
        }

        public class AirConditioner
        {
            public double MaxTemperature { get; set; }
            public double MinTemperature { get; set; }
            public double Power { get; set; }

            public AirConditioner(double minTemperature = 65.0, double maxTemperature = 69.0, double power = 1)
            {
                MinTemperature = minTemperature;
                MaxTemperature = maxTemperature;
                Power = power;
            }

            public void HandleTemperatureChanged(object sender, TemperatureEventArgs e)
            {
                if (e.Temperature > MaxTemperature)
                {
                    Console.WriteLine($"Temperature is {e.Temperature}°F. Turning on AC at power level {Power}.");
                }
                else if (e.Temperature < MinTemperature)
                {
                    Console.WriteLine($"Temperature is {e.Temperature}°F. Turning on heater at power level {Power}.");
                }
                else
                {
                    Console.WriteLine($"Temperature is {e.Temperature}°F. Temperature is within the comfortable range.");
                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}