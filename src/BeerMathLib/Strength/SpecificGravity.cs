using System;

namespace BeerMath
{
    /// <summary>
    /// Represents the gravity
    /// </summary>
    public class SpecificGravity
    {
        /// <summary>
        /// Gets the Value of the Gravity. Like 1.040.
        /// </summary>
       public decimal Value { get; private set; }

        private SpecificGravity() { }

        /// <summary>
        /// Sets a gravity value by ratio to pure water (like 1.040)
        /// </summary>
        /// <param name="gravity">
        /// A <see cref="System.Decimal"/> representing the specific gravity
        /// </param>
        public static SpecificGravity FromGravity(decimal gravity)
        {
            return new SpecificGravity() {
                Value = gravity,
            };
        }

        /// <summary>
        /// Get a gravity value from points
        /// </summary>
        /// <param name="points">
        /// A <see cref="System.Decimal"/> representing the points value (40 instead of 1.040) of the Gravity.
        /// </param>
        public static SpecificGravity FromPoints(decimal points)
        {
            return new SpecificGravity() {
                Value = (points / 1000m) + 1,
            };
        }

        /// <summary>
        /// Get a <see cref="SpecificGravity"/> from a Plato measurement.
        /// </summary>
        /// <param name="plato">
        /// A <see cref="System.Decimal"/> representing the Plato value.
        /// </param>
        public static SpecificGravity FromPlato(decimal plato)
        {
            return new SpecificGravity()
            {
                Value = (plato / (258.6m - ((plato / 258.5m) * 227.1m))) + 1
            };
        }

        /// <summary>
        /// Calculates the gravity contribution of a fermentable.
        /// </summary>
        /// <param name="GrainLbs">
        /// A <see cref="System.Decimal"/> representing the pounds of grain.
        /// </param>
        /// <param name="ExtractPpg">
        /// A <see cref="System.Decimal"/> representing the extract PPG rating for the grain.
        /// </param>
        /// <param name="ExtractEfficiency">
        /// A <see cref="System.Decimal"/> representing the estimated extract efficiency.
        /// </param>
        /// <param name="Volume">
        /// A <see cref="BeerMath.Gallon"/> representing the total volume of the batch.
        /// </param>
        /// <returns>
        /// The <see cref="SpecificGravity"/> contribution of the grain.
        /// </returns>
        public static SpecificGravity OriginalGravityOfFermentable(decimal GrainLbs, decimal ExtractPpg, decimal ExtractEfficiency, Gallon Volume)
        {
            if (Volume.Value == 0m)
            {
                throw new ArgumentOutOfRangeException("volume cannot be 0.");
            }
            return SpecificGravity.FromPoints((GrainLbs * ExtractPpg * ExtractEfficiency) / Volume.Value);
        }

        /// <summary>
        /// Calculates the final gravity of a fermentable.
        /// </summary>
        /// <param name="OriginalGravity">
        /// The original <see cref="SpecificGravity"/> contribution of the grain.
        /// </param>
        /// <param name="ApparentAttenuation">
        /// A <see cref="System.Decimal"/> representing the apparent attenuation.
        /// </param>
        /// <returns>
        /// The final <see cref="SpecificGravity"/> contribution of the grain.
        /// </returns>
        public static SpecificGravity FinalGravityOfFermentable(SpecificGravity OriginalGravity, decimal ApparentAttenuation)
        {
            return SpecificGravity.FromPoints(OriginalGravity.Points * (1.0m - ApparentAttenuation));
        }

        /// <summary>
        /// Calculates the final gravity of a fermentable.
        /// </summary>
        /// <param name="GrainLbs">
        /// A <see cref="System.Decimal"/> representing the pounds of grain.
        /// </param>
        /// <param name="ExtractPpg">
        /// A <see cref="System.Decimal"/> representing the extract PPG rating for the grain.
        /// </param>
        /// <param name="ExtractEfficiency">
        /// A <see cref="System.Decimal"/> representing the estimated extract efficiency.
        /// </param>
        /// <param name="Volume">
        /// A <see cref="BeerMath.Gallon"/> representing the total volume of the batch in gallons.
        /// </param>
        /// <param name="ApparentAttenuation">
        /// A <see cref="System.Decimal"/> representing the apparent attenuation.
        /// </param>
        /// <returns>
        /// The final <see cref="SpecificGravity"/> contribution of the grain.
        /// </returns>
        public static SpecificGravity FinalGravityOfFermentable(decimal GrainLbs, decimal ExtractPPG, decimal ExtractEfficiency,
            Gallon Volume, decimal ApparentAttenuation)
        {
            return FinalGravityOfFermentable(OriginalGravityOfFermentable(GrainLbs, ExtractPPG, ExtractEfficiency, Volume),
                ApparentAttenuation);
        }

        /// <summary>
        /// Calculates the Real Extract Gravity value for the grain.
        /// </summary>
        /// <param name="OriginalGravity">
        /// The original <see cref="SpecificGravity"/> contribution of the grain.
        /// </param>
        /// <param name="FinalGravity">
        /// The final <see cref="SpecificGravity"/> contribution of the grain.
        /// </param>
        /// <returns>
        /// The <see cref="SpecificGravity"/> Real Extract value.
        /// </returns>
        public static SpecificGravity FromRealExtract(SpecificGravity OriginalGravity, SpecificGravity FinalGravity)
        {
            return SpecificGravity.FromPlato(
                (RealExtractFinalGravityRatio * FinalGravity.Plato)
                + (RealExtractOriginalGravityRatio * OriginalGravity.Plato));
        }

        private const decimal RealExtractFinalGravityRatio        = 0.8192m;
        private const decimal RealExtractOriginalGravityRatio    = 0.1808m;

        /// <summary>
        /// Gets the Points of the Gravity as a whole number. Like 40.
        /// </summary>
        public decimal Points
        {
            get
            {
                return (Value - 1m) * 1000m;
            }
        }

        /// <summary>
        /// Gets the Plato of the Gravity.
        /// Calculated during construction by this method http://hbd.org/ensmingr/ (Equation 1).
        /// </summary>
        public decimal Plato
        {
            get
            {
                return (-463.37m) + (668.72m * Value) - (205.35m * (Value * Value));
            }
        }

        public bool IsZero()
        {
            return Value == 0m;
        }

        /// <summary>
        /// Implicit conversion to decimal based on the Points.
        /// </summary>
        /// <param name="gravity">
        /// A <see cref="SpecificGravity"/>.
        /// </param>
        /// <returns>
        /// A <see cref="System.Decimal"/>
        /// </returns>
        [Obsolete]
        public static implicit operator decimal(SpecificGravity gravity)
        {
            return gravity.Points;
        }
    }
}
