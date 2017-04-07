namespace BeerMath
{
    /// <summary>
    /// Homebrew Bittering Units
    /// </summary>
    public class Hbu
    {
        public decimal Value { get; private set; }

        public static Hbu FromHopsBill(decimal AlphaAcidRating, decimal Oz)
        {
            return new Hbu()
            {
                Value = AlphaAcidRating * Oz,
            };
        }

        private Hbu() { }
    }
}