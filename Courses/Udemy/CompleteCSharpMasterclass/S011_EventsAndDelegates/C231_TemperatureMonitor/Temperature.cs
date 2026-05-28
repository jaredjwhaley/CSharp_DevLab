namespace C231_TemperatureMonitor
{
    /// <summary>
    /// Represents an immutable temperature value stored internally in Kelvin and convertible to Celsius or Fahrenheit.
    /// </summary>
    /// <remarks>Stored as a Kelvin-based value. Create instances with FromCelsius, FromFahrenheit, or
    /// FromKelvin. Supports equality, comparison operators, and formatted string output.</remarks>
    public readonly struct Temperature : IComparable<Temperature>, IEquatable<Temperature>
    {
        // ----------------------------------------------------------------------------------------
        // Enums
        // ----------------------------------------------------------------------------------------
        /// <summary>
        /// Units of temperature measurement.
        /// </summary>
        /// <remarks>Specifies Celsius, Fahrenheit, or Kelvin for conversions and display
        /// formatting.</remarks>
        public enum UnitTypes
        {
            Celsius,
            Fahrenheit,
            Kelvin
        }

        // ----------------------------------------------------------------------------------------
        // Fields and Properties
        // ----------------------------------------------------------------------------------------

        // Backing field for the temperature in Kelvin.
        //   - All conversions will be based on this value.
        private readonly double _degreesKelvin;

        /// <summary>
        /// Gets the temperature in Kelvin.
        /// </summary>
        public double DegreesKelvin => _degreesKelvin;

        /// <summary>
        /// Gets the temperature in Celsius.
        /// </summary>
        public double DegreesCelsius => KelvinToCelsius(_degreesKelvin);

        /// <summary>
        /// Gets the temperature in Fahrenheit.
        /// </summary>
        public double DegreesFahrenheit => KelvinToFahrenheit(_degreesKelvin);

        // ----------------------------------------------------------------------------------------
        // Constructors
        // ----------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new Temperature instance by converting the supplied value to an internal Kelvin
        /// representation.
        /// </summary>
        /// <remarks>The value is converted to and stored as Kelvin. Supported unit types: Celsius,
        /// Fahrenheit, and Kelvin.</remarks>
        /// <param name="degrees">Temperature magnitude expressed in the scale specified by unitType.</param>
        /// <param name="unitType">Scale of the supplied degrees; defaults to Kelvin.</param>
        public Temperature(
            double degrees,
            Temperature.UnitTypes unitType = Temperature.UnitTypes.Kelvin)
        {
            // Convert the input degrees to Kelvin based on the specified unit type.
            _degreesKelvin = unitType switch
            {
                Temperature.UnitTypes.Celsius => CelsiusToKelvin(degrees),
                Temperature.UnitTypes.Fahrenheit => FahrenheitToKelvin(degrees),
                _ => degrees
            };
        }

        // ----------------------------------------------------------------------------------------
        // Factory Methods
        // ----------------------------------------------------------------------------------------
        //   - NOTE: Factory methods provide alternative ways to create instances of Temperature
        //     with specific units

        public static Temperature FromCelsius(double degrees)
        {
            return new Temperature(degrees, Temperature.UnitTypes.Celsius);
        }

        public static Temperature FromFahrenheit(double degrees)
        {
            return new Temperature(degrees, Temperature.UnitTypes.Fahrenheit);
        }

        public static Temperature FromKelvin(double degrees)
        {
            return new Temperature(degrees, Temperature.UnitTypes.Kelvin);
        }

        // ----------------------------------------------------------------------------------------
        // Conversion Methods
        // ----------------------------------------------------------------------------------------
        public static double KelvinToCelsius(double value)
        {
            return value - 273.15;
        }

        public static double FahrenheitToCelsius(double value)
        {
            return (value - 32) * 5 / 9;
        }

        public static double CelsiusToKelvin(double value)
        {
            return value + 273.15;
        }

        public static double CelsiusToFahrenheit(double value)
        {
            return value * 9 / 5 + 32;
        }

        public static double FahrenheitToKelvin(double value)
        {
            return CelsiusToKelvin(FahrenheitToCelsius(value));
        }

        public static double KelvinToFahrenheit(double value)
        {
            return CelsiusToFahrenheit(KelvinToCelsius(value));
        }

        // ----------------------------------------------------------------------------------------
        // Equality & Comparison Methods
        // ----------------------------------------------------------------------------------------

        // --- Equality ---
        public bool Equals(Temperature other)
        {
            return _degreesKelvin.Equals(other._degreesKelvin);
        }

        public override bool Equals(object? obj)
        {
            return obj is Temperature other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _degreesKelvin.GetHashCode();
        }

        public static bool operator ==(Temperature left, Temperature right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            return !left.Equals(right);
        }

        // --- Comparison ---
        public int CompareTo(Temperature other)
        {
            return _degreesKelvin.CompareTo(other._degreesKelvin);
        }
        public static bool operator <(Temperature left, Temperature right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Temperature left, Temperature right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Temperature left, Temperature right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Temperature left, Temperature right)
        {
            return left.CompareTo(right) >= 0;
        }

        // ----------------------------------------------------------------------------------------
        // Formatting Methods
        // ----------------------------------------------------------------------------------------

        public override string ToString()
        {
            // NOTE: "F0" formats the number to have no decimal places
            return $"{this.DegreesFahrenheit:F0}°F";
        }
    }
}