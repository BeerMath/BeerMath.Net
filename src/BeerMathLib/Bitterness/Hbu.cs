namespace BeerMath
{
    /// <summary>
    /// Homebrew Bittering Units
    /// </summary>
    public class Hbu : BeerValue
    {
        public Hbu(decimal hbu)
        {
            Value = hbu;
        }

        public Hbu(AlphaAcid Rating, Ounce Hops)
        {
            Value = Rating.Value * Hops.Value;
        }
    }
}