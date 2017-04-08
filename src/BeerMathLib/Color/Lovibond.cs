namespace BeerMath
{
    /// <summary>
    /// degrees Lovibond
    /// </summary>
    public class Lovibond
    {
        /// <summary>the color in Lovibond</summary>
        public decimal Value { get; private set; }

        /// <summary>directly create a Lovibond value</summary>
        public Lovibond(decimal degrees)
        {
            Value = degrees;
        }
    }
}
