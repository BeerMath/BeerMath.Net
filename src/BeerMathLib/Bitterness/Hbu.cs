namespace BeerMath
{
    /// <summary>
    /// Homebrew Bittering Units
    /// </summary>
    public class Hbu
    {
        public decimal Value { get; private set; }

        public static Hbu FromHopsBill(AlphaAcid Rating, decimal Oz)
        {
            return new Hbu()
            {
                Value = Rating.Value * Oz,
            };
        }

        private Hbu() { }
    }
}