using System;

namespace BeerMath
{
    /// <summary>
    /// Constants related to Jackie Rager's IBU methods.
    /// http://www.realbeer.com/hops/FAQ.html#units
    /// </summary>
    public static class Rager
    {
        private static class Gravity {
            public const decimal AdjustmentMinimum = 1.050m;
            public const decimal ConstantDivisor = 0.2m;
        }

        private static class Utilization {
            public const double BoilTimeAdjustment = 31.32;
            public const double BoilTimeDivisor = 18.27;
            public const decimal BoilTimeMultiplier = 13.86m;
            public const decimal BoilTimeAdditive = 18.11m;
        }

        private const decimal MetricConversionFactor = 7462m;

        public static Ibu CalculateIbus(AlphaAcid rating, Ounce hops, Gallon boilVolume,
            SpecificGravity wortGravity, TimeSpan boilTime)
        {
            decimal gravityAdjustment = 0;

            // According to Rager, if the gravity of the wort exceeds 1.050, there needs to be a gravity adjustment in the equation.
            if (wortGravity.Value > Rager.Gravity.AdjustmentMinimum)
            {
                gravityAdjustment = Rager.AdjustGravity(wortGravity);
            }

            // Alpha acid utilization.
            decimal utilization = Rager.CalculateUtilization(boilTime);

            // Convert utilization and alpha acid to percentage
            utilization = utilization / 100m;
            decimal percentage = rating.Value / 100m;

            return new Ibu(
                (hops.Value * utilization * percentage * Rager.MetricConversionFactor)
                / (boilVolume.Value * (1 + gravityAdjustment))
            );
        }

        internal static decimal AdjustGravity(SpecificGravity wortGravity)
        {
            return (wortGravity.Value - Rager.Gravity.AdjustmentMinimum)
                / Rager.Gravity.ConstantDivisor;
        }

        internal static decimal CalculateUtilization(TimeSpan boilTime)
        {
            var adjustedBoilTime =
                (decimal)Math.Tanh(
                    (double)((boilTime.TotalMinutes - Rager.Utilization.BoilTimeAdjustment)
                    / Rager.Utilization.BoilTimeDivisor)
                    );
            return Rager.Utilization.BoilTimeAdditive +
                (Rager.Utilization.BoilTimeMultiplier *
                adjustedBoilTime);
        }
    }
}