namespace BeerMath
{
    public class Attenuation : BeerValue
    {
        public AttenuationType Type { get; private set; }

        public enum AttenuationType
        {
            Apparent = 0,
            Real = 1,
        }

        private const decimal RealFactorMagicNumber = 0.81m;

        public Attenuation(decimal attenuation, AttenuationType type)
        {
            Value = attenuation;
            Type = type;
        }

        /// <summary>
        /// Attenuation is a measure of how much of the sugar was fermented by the yeast.  Apparent attenuation is the unadjusted
        /// percent of sugars fermented by the yeast.  For beer brewing, apparent attenuation is much more commonly used than real
        /// attenuation, so it's the default.
        ///
        /// The real attenuation is how much sugars were really fermented by the yeast.  Because alcohol is lighter in specific
        /// gravity than water, an adjustment must be made for the alcohol content when assessing the actual percentages of sugar
        /// fermented.  The real attenuation will always be a lower number than the apparent attenuation.
        /// </summary>
        /// <param name="originalGravity">
        /// A <see cref="SpecificGravity"/>
        /// </param>
        /// <param name="finalGravity">
        /// A <see cref="SpecificGravity"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Decimal"/>
        /// </returns>
        public Attenuation(
            SpecificGravity originalGravity,
            SpecificGravity finalGravity,
            AttenuationType type = AttenuationType.Apparent)
        {
            // Apparent Attenuation % = ((OG-1)-(FG-1)) / (OG-1) x 100
            Value = ((originalGravity.Value - 1) - (finalGravity.Value - 1))
                / (originalGravity.Value - 1) * 100;
            Type = AttenuationType.Apparent;

            if (type == AttenuationType.Real)
            {
                // Real Attenuation = Apparent Attenuation * 0.81
                Value = Value * BeerMath.Attenuation.RealFactorMagicNumber;
                Type = AttenuationType.Real;
            }
        }
    }
}
