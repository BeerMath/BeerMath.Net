namespace BeerMath
{
    /// <summary>
    /// Malt Color Units
    /// </summary>
    public class Mcu
    {
        /// <summary>the color in MCUs</summary>
        public decimal Value { get; private set; }

        public Mcu(decimal mcu)
        {
            Value = mcu;
        }

        /// <summary>get the MCU value of a malt addition</summary>
        public static Mcu FromGrainBill(Pound grain, Lovibond degrees, Gallon wort)
        {
            return new Mcu((grain.Value * degrees.Value) / wort.Value);
        }

        /// <summary>get the MCU value of a sum of MCU values</summary>
        public static Mcu operator +(Mcu mcu1, Mcu mcu2)
        {
            return new Mcu(mcu1.Value + mcu2.Value);
        }
    }
}
