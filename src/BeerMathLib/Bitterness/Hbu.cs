namespace BeerMath
{
    /// <summary>
    /// Homebrew Bittering Units
    /// </summary>
    public class Hbu
    {
        public decimal Value { get; private set; }

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