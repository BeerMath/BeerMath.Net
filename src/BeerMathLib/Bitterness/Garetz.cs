using System;

namespace BeerMath
{
    /// <summary>
    /// Constants related to Mark Garetz's IBU methods.
    /// http://www.realbeer.com/hops/FAQ.html#units
    /// </summary>
    public static class Garetz
    {
        private const decimal GravityAdjustment = 1.050m;
        private const decimal GravityFactorDivisor = 0.2m;
        private const decimal HoppingRateDivisor = 260.0m;
        private const decimal ElevationDivisor = 550.0m;
        private const decimal ElevationMultiplier = 0.02m;
        private const decimal MetricConversionFactor = 0.749m;

        /// <summary>
        /// Calculates the IBU a sample of hops in the batch by the Garetz method.
        /// This is intended to be an iterative method. You must guess at the final result,
        /// and rerun the process, each time adjusting the value downward.
        /// </summary>
        /// <param name="rating">
        /// A <see cref="BeerMath.AlphaAcid"/> representing the alpha acid rating of the hops.
        /// </param>
        /// <param name="hops">
        /// A <see cref="BeerMath.Ounce"/> representing the mass in ounces of the hops.
        /// </param>
        /// <param name="finalVolume">
        /// A <see cref="BeerMath.Gallon"/> representing the final volume of the batch.
        /// </param>
        /// <param name="boilVolume">
        /// A <see cref="BeerMath.Gallon"/> representing the boil volume of the batch.
        /// </param>
        /// <param name="wortGravity">
        /// A <see cref="SpecificGravity"/> representing the gravity of the wort.
        /// </param>
        /// <param name="boil">
        /// A <see cref="System.TimeSpan"/> representing the time the sample of hops is allowed to boil in the wort.
        /// </param>
        /// <param name="DesiredIbu">
        /// A <see cref="BeerMath.Ibu"/> representing the IBU desired.
        /// </param>
        /// <param name="elevationFeet">
        /// A <see cref="System.Decimal"/> representing the elevation in feet the batch was brewed at.
        /// </param>
        public static Ibu CalculateIbus(AlphaAcid rating, Ounce hops, Gallon finalVolume,
            Gallon boilVolume, SpecificGravity wortGravity, TimeSpan boil, Ibu desiredIbus,
            decimal elevationFeet)
        {
            if (boilVolume.Value == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(boilVolume)} cannot be 0.");
            }

            if (finalVolume.Value == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(finalVolume)} cannot be 0.");
            }

            // Concentration factor of the batch.
            decimal concentrationFactor = finalVolume.Value / boilVolume.Value;

            decimal boilGravity = (concentrationFactor * (wortGravity.Value - 1)) + 1;
            decimal gravityFactor = ((boilGravity - Garetz.GravityAdjustment) / Garetz.GravityFactorDivisor) + 1;
            decimal hoppingRateFactor = ((concentrationFactor * desiredIbus.Value) / Garetz.HoppingRateDivisor) + 1;
            decimal temperatureFactor = ((elevationFeet / Garetz.ElevationDivisor) * Garetz.ElevationMultiplier) + 1;
            decimal combinedAdjustments = gravityFactor * hoppingRateFactor * temperatureFactor;
            decimal utilization = Garetz.Utilization((decimal)boil.TotalMinutes);

            return new Ibu(
                (utilization * rating.Value * hops.Value * MetricConversionFactor)
                / (finalVolume.Value * combinedAdjustments));
        }

        /// <summary>
        /// Gets the utilization used in the Garetz method.
        /// </summary>
        /// <returns>Utilization percentage.</returns>
        private static decimal Utilization(decimal boilMinutes)
        {
            if (boilMinutes < 0)
                throw new ArgumentOutOfRangeException("Boil time cannot be negative");

            if (boilMinutes >= 0 && boilMinutes <= 10)
                return 0;
            else if (boilMinutes >= 11 && boilMinutes <= 15)
                return 2;
            else if (boilMinutes >= 16 && boilMinutes <= 20)
                return 5;
            else if (boilMinutes >= 21 && boilMinutes <= 25)
                return 8;
            else if (boilMinutes >= 26 && boilMinutes <= 30)
                return 11;
            else if (boilMinutes >= 31 && boilMinutes <= 35)
                return 14;
            else if (boilMinutes >= 36 && boilMinutes <= 40)
                return 16;
            else if (boilMinutes >= 41 && boilMinutes <= 45)
                return 18;
            else if (boilMinutes >= 46 && boilMinutes <= 50)
                return 19;
            else if (boilMinutes >= 51 && boilMinutes <= 60)
                return 20;
            else if (boilMinutes >= 61 && boilMinutes <= 70)
                return 21;
            else if (boilMinutes >= 71 && boilMinutes <= 80)
                return 22;
            else if (boilMinutes >= 81 && boilMinutes <= 90)
                return 23;

            throw new ArgumentOutOfRangeException("Boil times greater than 90 minutes are not supported");
        }
    }
}