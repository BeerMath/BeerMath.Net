using System;

namespace BeerMath
{
    public sealed class Hops
    {


        /// <summary>
        /// Constants related to Mark Garetz's IBU methods.
        /// http://www.realbeer.com/hops/FAQ.html#units
        /// </summary>
        #region Garetz constants
        public const decimal GaretzGravityAdjustment            = 1.050m;
        public const decimal GaretzGravityFactorDivisor            = 0.2m;
        public const decimal GaretzHoppingRateDivisor            = 260.0m;
        public const decimal GaretzElevationDivisor                = 550.0m;
        public const decimal GaretzElevationMultiplier            = 0.02m;
        public const decimal GaretzMetricConversionFactor        = 0.749m;
        #endregion

        /// <summary>
        /// Constants related to the calculation of the balance ratio.
        /// http://beercolor.netfirms.com/balance.html
        /// </summary>
        #region Beer balance constants
        public const decimal BalanceFinalGravityRatio            = 0.82m;
        public const decimal BalanceOriginalGravityRatio        = 0.18m;
        public const decimal BalanceIBURatio                    = 0.8m;
        #endregion

        /// <summary>
        /// Calculates the IBU a sample of hops in the batch by the Garetz method.
        /// This is intended to be an iterative method. You must guess at the final result,
        /// and rerun the process, each time adjusting the value downward.
        /// </summary>
        /// <param name="AlphaAcidRating">
        /// A <see cref="System.Decimal"/> representing the alpha acid rating of the hops. Represented like 6.0 not 0.060.
        /// </param>
        /// <param name="HopsOz">
        /// A <see cref="System.Decimal"/> representing the mass in ounces of the hops.
        /// </param>
        /// <param name="FinalVolume">
        /// A <see cref="System.Decimal"/> representing the final volume in gallons of the batch.
        /// </param>
        /// <param name="BoilVolume">
        /// A <see cref="System.Decimal"/> representing the boil volume of the batch.
        /// </param>
        /// <param name="WortGravity">
        /// A <see cref="Gravity"/> representing the gravity of the wort.
        /// </param>
        /// <param name="BoilTimeMinutes">
        /// A <see cref="System.Decimal"/> representing the time the sample of hops is allowed to boil in the wort.
        /// </param>
        /// <param name="DesiredIBU">
        /// A <see cref="System.Decimal"/> representing the IBU desired.
        /// </param>
        /// <param name="ElevationFeet">
        /// A <see cref="System.Decimal"/> representing the elevation in feet the batch was brewed at.
        /// </param>
        /// <returns>
        /// A <see cref="Bitterness"/>
        /// </returns>
        public static Bitterness CalculateIbusGaretz(decimal AlphaAcidRating, decimal HopsOz, decimal FinalVolume,
            decimal BoilVolume, Gravity WortGravity, decimal BoilTimeMinutes, decimal DesiredIBU, decimal ElevationFeet)
        {
            if (BoilVolume == 0)
            {
                throw new BeerMathException("BoilVolume cannot be 0.");
            }

            if (FinalVolume == 0)
            {
                throw new BeerMathException("FinalVolume cannot be 0.");
            }

            // Concentration factor of the batch.
            decimal ConcentrationFactor = FinalVolume / BoilVolume;

            decimal BoilGravity = (ConcentrationFactor * (WortGravity.Value - 1)) + 1;
            decimal GravityFactor = ((BoilGravity - GaretzGravityAdjustment) / GaretzGravityFactorDivisor) + 1;
            decimal HoppingRateFactor = ((ConcentrationFactor * DesiredIBU) / GaretzHoppingRateDivisor) + 1;
            decimal TemperatureFactor = ((ElevationFeet / GaretzElevationDivisor) * GaretzElevationMultiplier) + 1;
            decimal CombinedAdjustments = GravityFactor * HoppingRateFactor * TemperatureFactor;
            decimal Utilization = _GaretzUtilization(BoilTimeMinutes);

            return new Bitterness((Utilization * AlphaAcidRating * HopsOz * GaretzMetricConversionFactor)
                                    / (FinalVolume * CombinedAdjustments),
                        BitternessType.Ibu);
        }

        /// <summary>
        /// Gets the utilization used in the garetz method.
        /// </summary>
        /// <param name="BoilTimeMinutes">
        /// A <see cref="System.Decimal"/> representing the time the sample of hops is allowed to boil in the wort.
        /// </param>
        /// <returns>The Garetz utilization percentage.</returns>
        private static decimal _GaretzUtilization(decimal BoilTimeMinutes)
        {
            if (BoilTimeMinutes < 0)
                throw new BeerMathException("Boil time cannot be negative");

            if (BoilTimeMinutes >= 0 && BoilTimeMinutes <= 10)
                return 0;
            else if (BoilTimeMinutes >= 11 && BoilTimeMinutes <= 15)
                return 2;
            else if (BoilTimeMinutes >= 16 && BoilTimeMinutes <= 20)
                return 5;
            else if (BoilTimeMinutes >= 21 && BoilTimeMinutes <= 25)
                return 8;
            else if (BoilTimeMinutes >= 26 && BoilTimeMinutes <= 30)
                return 11;
            else if (BoilTimeMinutes >= 31 && BoilTimeMinutes <= 35)
                return 14;
            else if (BoilTimeMinutes >= 36 && BoilTimeMinutes <= 40)
                return 16;
            else if (BoilTimeMinutes >= 41 && BoilTimeMinutes <= 45)
                return 18;
            else if (BoilTimeMinutes >= 46 && BoilTimeMinutes <= 50)
                return 19;
            else if (BoilTimeMinutes >= 51 && BoilTimeMinutes <= 60)
                return 20;
            else if (BoilTimeMinutes >= 61 && BoilTimeMinutes <= 70)
                return 21;
            else if (BoilTimeMinutes >= 71 && BoilTimeMinutes <= 80)
                return 22;
            else if (BoilTimeMinutes >= 81 && BoilTimeMinutes <= 90)
                return 23;

            throw new BeerMathException("Boil times greater than 90 minutes are not supported in this version");
        }

        /// <summary>
        /// Calculates the balance (BU:GU) or bittering units to gravity units of the batch.
        /// </summary>
        /// <param name="FinalGravity">
        /// A <see cref="Gravity"/> representing the final gravity of the batch.
        /// This should be a value in whole numbers, like 40 instead of 1.040.
        /// </param>
        /// <param name="OriginalGravity">
        /// A <see cref="Gravity"/> representing the original gravity of the batch.
        /// This should be a value in whole numbers, like 40 instead of 1.040.
        /// </param>
        /// <param name="Ibu">
        /// A <see cref="Bitterness"/> representing the IBU of the batch.
        /// </param>
        /// <returns>
        /// A <see cref="System.Decimal"/> BU:GU ratio value.
        /// </returns>
        public static decimal CalculateBalanceRatio(Gravity FinalGravity, Gravity OriginalGravity, Bitterness Ibu)
        {
            if (FinalGravity == Gravity.Zero && OriginalGravity == Gravity.Zero)
            {
                throw new BeerMathException("finalGravity and originalGravity must not be 0.");
            }
            decimal realTerminalExtract = (BalanceFinalGravityRatio * FinalGravity.Points) + (BalanceOriginalGravityRatio * OriginalGravity.Points);

            return (Ibu * BalanceIBURatio) / realTerminalExtract;
        }
    }
}
