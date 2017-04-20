namespace BeerMath
{
    /// <summary>
    /// Homebrew Bittering Units
    /// </summary>
    public class Hbu : BeerValue
    {
        public Hbu(decimal hbus)
        {
            Value = hbus;
        }

        public Hbu(AlphaAcid rating, Ounce hops)
        {
            Value = rating.Value * hops.Value;
        }
    }
}