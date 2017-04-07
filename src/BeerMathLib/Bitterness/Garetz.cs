using System;

namespace BeerMath
{
    /// <summary>
    /// Constants related to Mark Garetz's IBU methods.
    /// http://www.realbeer.com/hops/FAQ.html#units
    /// </summary>
    public static class Garetz
    {
        public const decimal GravityAdjustment = 1.050m;
        public const decimal GravityFactorDivisor = 0.2m;
        public const decimal HoppingRateDivisor = 260.0m;
        public const decimal ElevationDivisor = 550.0m;
        public const decimal ElevationMultiplier = 0.02m;
        public const decimal MetricConversionFactor = 0.749m;

        /// <summary>
        /// Calculates the IBU a sample of hops in the batch by the Garetz method.
        /// This is intended to be an iterative method. You must guess at the final result,
        /// and rerun the process, each time adjusting the value downward.
        /// </summary>
        /// <param name="AlphaAcidRating">
        /// A <see cref="System.Decimal"/> representing the alpha acid rating of the hops. Represented like 6.0 not 0.060.
        /// </param>
        /// <param name="Oz">
        /// A <see cref="System.Decimal"/> representing the mass in ounces of the hops.
        /// </param>
        /// <param name="FinalVolume">
        /// A <see cref="System.Decimal"/> representing the final volume in gallons of the batch.
        /// </param>
        /// <param name="BoilVolume">
        /// A <see cref="System.Decimal"/> representing the boil volume of the batch.
        /// </param>
        /// <param name="WortGravity">
        /// A <see cref="SpecificGravity"/> representing the gravity of the wort.
        /// </param>
        /// <param name="BoilTimeMinutes">
        /// A <see cref="System.Decimal"/> representing the time the sample of hops is allowed to boil in the wort.
        /// </param>
        /// <param name="DesiredIbu">
        /// A <see cref="System.Decimal"/> representing the IBU desired.
        /// </param>
        /// <param name="ElevationFeet">
        /// A <see cref="System.Decimal"/> representing the elevation in feet the batch was brewed at.
        /// </param>
        public static Ibu CalculateIbus(decimal AlphaAcidRating, decimal Oz, decimal FinalVolume,
            decimal BoilVolume, SpecificGravity WortGravity, decimal BoilTimeMinutes, decimal DesiredIbu, decimal ElevationFeet)
        {
            if (BoilVolume == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(BoilVolume)} cannot be 0.");
            }

            if (FinalVolume == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(FinalVolume)} cannot be 0.");
            }

            // Concentration factor of the batch.
            decimal ConcentrationFactor = FinalVolume / BoilVolume;

            decimal BoilGravity = (ConcentrationFactor * (WortGravity.Value - 1)) + 1;
            decimal GravityFactor = ((BoilGravity - Garetz.GravityAdjustment) / Garetz.GravityFactorDivisor) + 1;
            decimal HoppingRateFactor = ((ConcentrationFactor * DesiredIbu) / Garetz.HoppingRateDivisor) + 1;
            decimal TemperatureFactor = ((ElevationFeet / Garetz.ElevationDivisor) * Garetz.ElevationMultiplier) + 1;
            decimal CombinedAdjustments = GravityFactor * HoppingRateFactor * TemperatureFactor;
            decimal Utilization = Garetz.Utilization(BoilTimeMinutes);

            return Ibu.FromDecimal(
                (Utilization * AlphaAcidRating * Oz * MetricConversionFactor)
                / (FinalVolume * CombinedAdjustments));
        }

        /// <summary>
        /// Gets the utilization used in the Garetz method.
        /// </summary>
        /// <returns>Utilization percentage.</returns>
        private static decimal Utilization(decimal BoilMinutes)
        {
            if (BoilMinutes < 0)
                throw new ArgumentOutOfRangeException("Boil time cannot be negative");

            if (BoilMinutes >= 0 && BoilMinutes <= 10)
                return 0;
            else if (BoilMinutes >= 11 && BoilMinutes <= 15)
                return 2;
            else if (BoilMinutes >= 16 && BoilMinutes <= 20)
                return 5;
            else if (BoilMinutes >= 21 && BoilMinutes <= 25)
                return 8;
            else if (BoilMinutes >= 26 && BoilMinutes <= 30)
                return 11;
            else if (BoilMinutes >= 31 && BoilMinutes <= 35)
                return 14;
            else if (BoilMinutes >= 36 && BoilMinutes <= 40)
                return 16;
            else if (BoilMinutes >= 41 && BoilMinutes <= 45)
                return 18;
            else if (BoilMinutes >= 46 && BoilMinutes <= 50)
                return 19;
            else if (BoilMinutes >= 51 && BoilMinutes <= 60)
                return 20;
            else if (BoilMinutes >= 61 && BoilMinutes <= 70)
                return 21;
            else if (BoilMinutes >= 71 && BoilMinutes <= 80)
                return 22;
            else if (BoilMinutes >= 81 && BoilMinutes <= 90)
                return 23;

            throw new ArgumentOutOfRangeException("Boil times greater than 90 minutes are not supported");
        }
    }
}