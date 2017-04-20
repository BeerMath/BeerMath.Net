namespace BeerMath
{
    public class AlphaAcid : BeerValue
    {
        /// <summary>
        /// Creates an alpha acid from a percent (6.0, not .060)
        /// </summary>
        public AlphaAcid(decimal aaus)
        {
            Value = aaus;
        }
    }
}