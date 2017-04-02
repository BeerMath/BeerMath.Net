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
        #region Gravity Constants
        public const decimal RealExtractFinalGravityRatio        = 0.8192m;
        public const decimal RealExtractOriginalGravityRatio    = 0.1808m;
        #endregion

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
        /// The <see cref="Gravity"/> contribution of the grain.
        /// </returns>
        public static Gravity CalculateOriginalGravity(decimal GrainLbs, decimal ExtractPpg, decimal ExtractEfficiency, decimal Volume)
        {
            if (Volume == 0m)
            {
                throw new BeerMathException("volume cannot be 0.");
            }
            return new Gravity((GrainLbs * ExtractPpg * ExtractEfficiency) / Volume);
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
        /// The final <see cref="Gravity"/> contribution of the grain.
        /// </returns>
        public static Gravity CalculateFinalGravity(decimal GrainLbs, decimal ExtractPPG, decimal ExtractEfficiency,
            decimal Volume, decimal ApparentAttenuation)
        {
            return CalculateFinalGravity(CalculateOriginalGravity(GrainLbs, ExtractPPG, ExtractEfficiency, Volume),
                ApparentAttenuation);
        }

        /// <summary>
        /// Calculates the final gravity of a fermentable.
        /// </summary>
        /// <param name="OriginalGravity">
        /// The original <see cref="Gravity"/> contribution of the grain.
        /// </param>
        /// <param name="ApparentAttenuation">
        /// A <see cref="System.Decimal"/> representing the apparent attenuation.
        /// </param>
        /// <returns>
        /// The final <see cref="Gravity"/> contribution of the grain.
        /// </returns>
        public static Gravity CalculateFinalGravity(Gravity OriginalGravity, decimal ApparentAttenuation)
        {
            return new Gravity(OriginalGravity.Points * (1.0m - ApparentAttenuation));
        }

        /// <summary>
        /// Calculates the Real Extract Gravity value for the grain.
        /// </summary>
        /// <param name="OriginalGravity">
        /// The original <see cref="Gravity"/> contribution of the grain.
        /// </param>
        /// <param name="FinalGravity">
        /// The final <see cref="Gravity"/> contribution of the grain.
        /// </param>
        /// <returns>
        /// The <see cref="Gravity"/> Real Extract value.
        /// </returns>
        public static Gravity CalculateRealExtract(Gravity OriginalGravity, Gravity FinalGravity)
        {
            decimal realExtractPlato = (RealExtractFinalGravityRatio * FinalGravity.Plato) + (RealExtractOriginalGravityRatio * OriginalGravity.Plato);
            decimal realExtractPointsValue = Gravity.ConvertPlatoToPoints(realExtractPlato);
            return new Gravity(realExtractPointsValue);
        }
    }
}
