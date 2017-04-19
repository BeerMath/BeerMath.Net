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

        public Calorie(SpecificGravity OriginalGravity, SpecificGravity FinalGravity)
        {
            Abw abw = Abw.FromOgFg(OriginalGravity, FinalGravity);
            SpecificGravity realExtract = SpecificGravity.FromRealExtract(OriginalGravity, FinalGravity);

            Value = ((Calorie.AbwMultiplier * abw.Value)
                + (Calorie.AbwRealExtractSum * (realExtract.Plato - Calorie.RealExtractSubtraction)))
                * FinalGravity.Value * Calorie.FinalGravityMultiplier;
        }
    }
}
