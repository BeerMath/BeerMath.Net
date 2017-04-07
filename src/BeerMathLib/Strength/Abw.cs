namespace BeerMath
{

    /// <summary>
    /// Alcohol by weight
    /// </summary>
    public sealed class Abw
    {
        public decimal Value { get; private set; }

        private Abw () { }

        public Abw(decimal raw)
        {
            Value = raw;
        }

        public static Abw FromOgFg (SpecificGravity OriginalGravity, SpecificGravity FinalGravity)
        {
            return new Abw
            {
                Value = (AbwMagicNumber * Abv.FromOgFg(OriginalGravity, FinalGravity).Value) / FinalGravity.Value,
            };
        }

        private const decimal AbwMagicNumber = 0.79m;
    }
}
