using System;

namespace BeerMath
{

    /// <summary>
    /// Alcohol by weight
    /// </summary>
    public sealed class Abw
    {
        public decimal Value { get; private set; }

        private Abw () { }

        public static Abw FromDecimal(decimal raw)
        {
            return new Abw() {
                Value = raw,
            };
        }

        public static Abw FromOgFg (Gravity OriginalGravity, Gravity FinalGravity)
        {
            return new Abw
            {
                Value = (AbwMagicNumber * Abv.FromOgFg(OriginalGravity, FinalGravity).Value) / FinalGravity.Value,
            };
        }

        private const decimal AbwMagicNumber = 0.79m;
    }
}
