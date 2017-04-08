namespace BeerMath
{
    /// <summary>
    /// Homebrew Bittering Units
    /// </summary>
    public class Hbu
    {
        public decimal Value { get; private set; }

        public static Hbu FromHopsBill(AlphaAcid Rating, Ounce Hops)
        {
            return new Hbu()
            {
                Value = Rating.Value * Hops.Value,
            };
        }

        private Hbu() { }
    }
}