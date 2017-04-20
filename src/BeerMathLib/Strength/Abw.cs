namespace BeerMath
{

    /// <summary>
    /// Alcohol by weight
    /// </summary>
    public sealed class Abw : BeerValue
    {
        public Abw(decimal raw)
        {
            Value = raw;
        }

        public static Abw FromOgFg (SpecificGravity originalGravity, SpecificGravity finalGravity)
        {
            return new Abw((AbwMagicNumber * Abv.FromOgFg(originalGravity, finalGravity).Value) / finalGravity.Value);
        }

        private const decimal AbwMagicNumber = 0.79m;
    }
}
