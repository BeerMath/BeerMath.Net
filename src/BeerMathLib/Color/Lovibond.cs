namespace BeerMath
{
    /// <summary>
    /// degrees Lovibond
    /// </summary>
    public class Lovibond : BeerValue
    {
        /// <summary>directly create a Lovibond value</summary>
        public Lovibond(decimal degrees)
        {
            Value = degrees;
        }
    }
}
