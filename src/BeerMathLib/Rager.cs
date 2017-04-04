using System;

namespace BeerMath
{
    /// <summary>
    /// Constants related to Jackie Rager's IBU methods.
    /// http://www.realbeer.com/hops/FAQ.html#units
    /// </summary>
    internal static class Rager
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