namespace BeerMath
{
    public class AlphaAcid
    {
        public decimal Value { get; private set; }

        // private constructor so consumers cannot create
        private AlphaAcid() { }

        /// <summary>
        /// Creates an alpha acid from a percent (6.0, not .060)
        /// </summary>
        public static AlphaAcid FromPercent(decimal raw)
        {
            return new AlphaAcid() {
                Value = raw,
            };
        }
    }
}