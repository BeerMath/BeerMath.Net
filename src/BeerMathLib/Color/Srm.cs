namespace BeerMath
{
    using System;

    /// <summary>
    /// Standard Reference Method
    /// </summary>
    public class Srm : BeerValue
    {
        public Srm(decimal srm)
        {
            Value = srm;
        }

        /// <summary>estimate the SRM value of an MCU measurement</summary>
        public static Srm EstimateMorey(Mcu mcu)
        {
            var srm = new Srm((decimal)(MoreySrmFactor * Math.Pow((double)mcu.Value, MoreySrmExponent)));

            if(srm.Value <= 50m)
            {
                return srm;
            }
            throw new InaccurateResultException($"Morey's equations only work up to SRM 50; tried to store {srm.Value}.");
        }

        // Morey's constants
        // http://www.brewwiki.com/index.php/Estimating_Color
        private const double MoreySrmFactor = 1.4922;
        private const double MoreySrmExponent = 0.6859;
    }
}
