using System;

namespace BeerMath
{
    /// <summary>
    /// Constants related to Jackie Rager's IBU methods.
    /// http://www.realbeer.com/hops/FAQ.html#units
    /// </summary>
    public static class Rager
    {
        internal static class Gravity {
            public const decimal AdjustmentMinimum = 1.050m;
            public const decimal ConstantDivisor = 0.2m;
        }

        internal static class Utilization {
            public const decimal BoilTimeAdjustment = 31.32m;
            public const decimal BoilTimeDivisor = 18.27m;
            public const decimal BoilTimeMultiplier = 13.86m;
            public const decimal BoilTimeAdditive = 18.11m;
        }

        public const decimal MetricConversionFactor = 7462m;

        public static Ibu CalculateIbus(decimal AlphaAcidRating, decimal Oz, decimal Volume,
            BeerMath.Gravity WortGravity, decimal BoilMinutes)
        {
            decimal GravityAdjustment = 0;

            // According to Rager, if the gravity of the wort exceeds 1.050, there needs to be a gravity adjustment in the equation.
            if (WortGravity.Value > Rager.Gravity.AdjustmentMinimum)
            {
                GravityAdjustment = Rager.AdjustGravity(WortGravity);
            }

            // Alpha acid utilization.
            decimal Utilization = Rager.CalculateUtilization(BoilMinutes);

            // Convert utilization and alpha acid to percentage
            Utilization = Utilization / 100m;
            AlphaAcidRating = AlphaAcidRating / 100m;

            return Ibu.FromDecimal(
                (Oz * Utilization * AlphaAcidRating * Rager.MetricConversionFactor)
                / (Volume * (1 + GravityAdjustment))
            );
        }

        internal static decimal AdjustGravity(BeerMath.Gravity WortGravity)
        {
            return (WortGravity.Value - Rager.Gravity.AdjustmentMinimum)
                / Rager.Gravity.ConstantDivisor;
        }

        internal static decimal CalculateUtilization(decimal BoilTimeMinutes)
        {
            var adjustedBoilTime =
                (decimal)Math.Tanh(
                    (double)((BoilTimeMinutes - Rager.Utilization.BoilTimeAdjustment)
                    / Rager.Utilization.BoilTimeDivisor)
                    );
            return Rager.Utilization.BoilTimeAdditive +
                (Rager.Utilization.BoilTimeMultiplier *
                adjustedBoilTime);
        }
    }
}