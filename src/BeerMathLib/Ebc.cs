using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerMath
{
	/// <summary>
	/// European Brewery Convention color
	/// </summary>
    public class Ebc
	{
        /// <summary>the color in EBC</summary>
        public decimal Value { get; private set; }

        /// <summary>estimate the EBC value of an SRM color</summary>
        public static Ebc FromSrm(Srm srm)
        {
            return new Ebc()
            {
                Value = srm.Value * ToEbcConversionFactor,
            };
        }

        public Srm ToSrm
        {
            get {
                return Srm.FromDecimal(this.Value * ToSrmConversionFactor);
            }
        }

        // private constructor so no one can create this directly
        private Ebc() {}

        // Conversion constant
        // https://en.wikipedia.org/wiki/Standard_Reference_Method#EBC
		private const decimal ToEbcConversionFactor = 1.97m;
		private const decimal ToSrmConversionFactor = 0.508m;
    }
}
