namespace BeerMath
{
    public sealed class Calorie : BeerValue
    {
        private const decimal AbwMultiplier = 6.9m;
        private const decimal AbwRealExtractSum = 4.0m;
        private const decimal RealExtractSubtraction = 0.1m;
        private const decimal FinalGravityMultiplier = 3.55m;

        public Calorie(decimal calories)
        {
            Value = calories;
        }

        public Calorie(SpecificGravity originalGravity, SpecificGravity finalGravity)
        {
            Abw abw = Abw.FromOgFg(originalGravity, finalGravity);
            SpecificGravity realExtract = SpecificGravity.FromRealExtract(originalGravity, finalGravity);

            Value = ((Calorie.AbwMultiplier * abw.Value)
                + (Calorie.AbwRealExtractSum * (realExtract.Plato - Calorie.RealExtractSubtraction)))
                * finalGravity.Value * Calorie.FinalGravityMultiplier;
        }
    }
}
