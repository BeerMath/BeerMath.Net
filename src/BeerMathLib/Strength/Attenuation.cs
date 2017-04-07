using System;

namespace BeerMath
{
    public class Attenuation
    {
        public decimal Value { get; private set; }
        public AttenuationType Type { get; private set; }

        public enum AttenuationType
        {
            Apparent = 0,
            Real = 1,
        }

        private const decimal RealFactorMagicNumber = 0.81m;

        private Attenuation() { }

        public static Attenuation FromRaw(decimal rawAttenuation, AttenuationType rawType)
        {
            return new Attenuation() {
                Value = rawAttenuation,
                Type = rawType,
            };
        }

        /// <summary>
        /// Attenuation is a measure of how much of the sugar was fermented by the yeast.  Apparent attenuation is the unadjusted
        /// percent of sugars fermented by the yeast.  For beer brewing, apparent attenuation is much more commonly used than real
        /// attenuation.
        /// </summary>
        /// <param name="OriginalGravity">
        /// A <see cref="SpecificGravity"/>
        /// </param>
        /// <param name="FinalGravity">
        /// A <see cref="SpecificGravity"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Decimal"/>
        /// </returns>
        public static Attenuation Apparent(SpecificGravity OriginalGravity, SpecificGravity FinalGravity)
        {
            //Apparent Attenuation % = ((OG-1)-(FG-1)) / (OG-1) x 100
            return new Attenuation() {
                Value = ((OriginalGravity.Value - 1) - (FinalGravity.Value - 1))
                    / (OriginalGravity.Value - 1) * 100,
                Type = AttenuationType.Apparent,
            };
        }

        /// <summary>
        /// The real attenuation is how much sugars were really fermented by the yeast.  Because alcohol is lighter in specific
        /// gravity than water, an adjustment must be made for the alcohol content when assessing the actual percentages of sugar
        /// fermented.  The real attenuation will always be a lower number than the apparent attenuation.
        /// </summary>
        /// <param name="OriginalGravity">
        /// A <see cref="SpecificGravity"/>
        /// </param>
        /// <param name="FinalGravity">
        /// A <see cref="SpecificGravity"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Decimal"/>
        /// </returns>
        public static Attenuation Real(SpecificGravity OriginalGravity, SpecificGravity FinalGravity)
        {
            //Real Attenuation = Apparent Attenuation * 0.81
            var attenuation = Attenuation.Apparent(OriginalGravity, FinalGravity);
            attenuation.Value = attenuation.Value * Attenuation.RealFactorMagicNumber;
            attenuation.Type = AttenuationType.Real;

            return attenuation;
        }
    }
}
