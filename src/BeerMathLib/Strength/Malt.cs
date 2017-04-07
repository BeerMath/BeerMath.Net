using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerMath
{
    /// <summary>
    /// Helper class for dealing with common malt calculations
    /// </summary>
    public sealed class Malt
    {
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
        /// A <see cref="System.Decimal"/> representing the total volume of the batch in gallons.
        /// </param>
        /// <returns>
        /// The <see cref="SpecificGravity"/> contribution of the grain.
        /// </returns>
        public static SpecificGravity CalculateOriginalGravity(decimal GrainLbs, decimal ExtractPpg, decimal ExtractEfficiency, decimal Volume)
        {
            if (Volume == 0m)
            {
                throw new BeerMathException("volume cannot be 0.");
            }
            return SpecificGravity.FromPoints((GrainLbs * ExtractPpg * ExtractEfficiency) / Volume);
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
        /// A <see cref="System.Decimal"/> representing the total volume of the batch in gallons.
        /// </param>
        /// <param name="ApparentAttenuation">
        /// A <see cref="System.Decimal"/> representing the apparent attenuation.
        /// </param>
        /// <returns>
        /// The final <see cref="SpecificGravity"/> contribution of the grain.
        /// </returns>
        public static SpecificGravity CalculateFinalGravity(decimal GrainLbs, decimal ExtractPPG, decimal ExtractEfficiency,
            decimal Volume, decimal ApparentAttenuation)
        {
            return CalculateFinalGravity(CalculateOriginalGravity(GrainLbs, ExtractPPG, ExtractEfficiency, Volume),
                ApparentAttenuation);
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
        public static SpecificGravity CalculateFinalGravity(SpecificGravity OriginalGravity, decimal ApparentAttenuation)
        {
            return SpecificGravity.FromPoints(OriginalGravity.Points * (1.0m - ApparentAttenuation));
        }

    }
}
