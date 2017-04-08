using System;

namespace BeerMath
{
    public sealed class Balance
    {
        /// <summary>
        /// Constants related to the calculation of the balance ratio.
        /// http://beercolor.netfirms.com/balance.html
        /// </summary>
        public const decimal FinalGravityRatio = 0.82m;
        public const decimal OriginalGravityRatio = 0.18m;
        public const decimal IbuRatio = 0.8m;

        /// <summary>
        /// Calculates the balance (BU:GU) or bittering units to gravity units of the batch.
        /// </summary>
        /// <param name="FinalGravity">
        /// A <see cref="SpecificGravity"/> representing the final gravity of the batch.
        /// This should be a value in whole numbers, like 40 instead of 1.040.
        /// </param>
        /// <param name="OriginalGravity">
        /// A <see cref="SpecificGravity"/> representing the original gravity of the batch.
        /// This should be a value in whole numbers, like 40 instead of 1.040.
        /// </param>
        /// <param name="Bitterness">
        /// <see cref="Ibu"/>s of the batch.
        /// </param>
        /// <returns>
        /// A <see cref="System.Decimal"/> BU:GU ratio value.
        /// </returns>
        public static decimal CalculateBalanceRatio(SpecificGravity FinalGravity,
            SpecificGravity OriginalGravity, Ibu Bitterness)
        {
            if (FinalGravity.IsZero() && OriginalGravity.IsZero())
            {
                throw new ArgumentException("finalGravity and originalGravity must not be 0.");
            }
            decimal realTerminalExtract = (Balance.FinalGravityRatio * FinalGravity.Points)
                + (Balance.OriginalGravityRatio * OriginalGravity.Points);

            return (Bitterness.Value * Balance.IbuRatio) / realTerminalExtract;
        }
    }
}
