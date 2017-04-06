using System;

namespace BeerMath
{
    public sealed class Calorie
    {
        private const decimal AbwMultiplier = 6.9m;
        private const decimal AbwRealExtractSum = 4.0m;
        private const decimal RealExtractSubtraction = 0.1m;
        private const decimal FinalGravityMultiplier = 3.55m;

         public decimal Value { get; private set; }

        private Calorie () { }

        public static Calorie FromOgFg(Gravity OriginalGravity, Gravity FinalGravity)
        {
            Abw abw = Abw.FromOgFg(OriginalGravity, FinalGravity);
            Gravity realExtract = Malt.CalculateRealExtract(OriginalGravity, FinalGravity);
            return new Calorie() {
                Value = ((Calorie.AbwMultiplier * abw.Value)
                    + (Calorie.AbwRealExtractSum * (realExtract.Plato - Calorie.RealExtractSubtraction)))
                    * FinalGravity.Value * Calorie.FinalGravityMultiplier
                };
        }
    }
}
