namespace BeerMath
{
    /// <summary>
    /// European Brewery Convention color
    /// </summary>
    public class Ebc
    {
        /// <summary>the color in EBC</summary>
        public decimal Value { get; private set; }

        public Ebc(decimal ebc)
        {
            Value = ebc;
        }

        /// <summary>estimate the EBC value of an SRM color</summary>
        public static Ebc FromSrm(Srm srm)
        {
            return new Ebc(srm.Value * ToEbcConversionFactor);
        }

        public Srm ToSrm
        {
            get => new Srm(this.Value * ToSrmConversionFactor);
        }

        // Conversion constant
        // https://en.wikipedia.org/wiki/Standard_Reference_Method#EBC
        private const decimal ToEbcConversionFactor = 1.97m;
        private const decimal ToSrmConversionFactor = 0.508m;
    }
}
