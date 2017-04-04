using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerMath
{
    /// <summary>
    /// Malt Color Units
    /// </summary>
    public class Mcu
    {
        /// <summary>the color in MCUs</summary>
        public decimal Value { get; private set; }

        /// <summary>get the MCU value of a malt addition</summary>
        public static Mcu FromGrainBill(decimal Lbs, decimal Lovibond, decimal Gallons)
        {
            return new Mcu()
            {
                Value = (Lbs * Lovibond) / Gallons,
            };
        }

        /// <summary>get the MCU value of a sum of MCU values</summary>
        public static Mcu operator +(Mcu mcu1, Mcu mcu2)
        {
            return new Mcu()
            {
                Value = mcu1.Value + mcu2.Value,
            };
        }

        // private constructor so no one can create this directly
        private Mcu() {}
    }
}
