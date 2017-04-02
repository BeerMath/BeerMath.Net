using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerMath
{
	/// <summary>
	/// Standard Reference Method
	/// </summary>
    public class Srm
	{
        /// <summary>the color in SRM</summary>
        public decimal Value { get; private set; }

        /// <summary>estimate the SRM value of an MCU measurement</summary>
        public static Srm EstimateMorey(Mcu mcu)
        {
            var srm = new Srm()
            {
                Value = (decimal)(MoreySrmFactor * Math.Pow((double)mcu.Value, MoreySrmExponent)),
            };
            if(srm.Value <= 50m)
            {
                return srm;
            }

            throw new InaccurateResultException($"Morey's equations only work up to SRM 50; this color was estimated at ${srm.Value}.");
        }

        // private constructor so no one can create this directly
        private Srm() {}

        // Morey's constants
        // http://www.brewwiki.com/index.php/Estimating_Color
		private const double MoreySrmFactor = 1.4922;
		private const double MoreySrmExponent = 0.6859;
    }
}
