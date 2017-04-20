using System;

namespace BeerMath
{
    public sealed class Balance
    {
        /// <summary>
        /// Constants related to the calculation of the balance ratio.
        /// http://beercolor.netfirms.com/balance.html
        /// </summary>
        private const decimal FinalGravityRatio = 0.82m;
        private const decimal OriginalGravityRatio = 0.18m;
        private const decimal IbuRatio = 0.8m;

        /// <summary>
        /// Calculates the balance (BU:GU) or bittering units to gravity units of the batch.
        /// </summary>
        /// <param name="finalGravity">
        /// A <see cref="SpecificGravity"/> representing the final gravity of the batch.
        /// This should be a value in whole numbers, like 40 instead of 1.040.
        /// </param>
        /// <param name="originalGravity">
        /// A <see cref="SpecificGravity"/> representing the original gravity of the batch.
        /// This should be a value in whole numbers, like 40 instead of 1.040.
        /// </param>
        /// <param name="bitterness">
        /// <see cref="Ibu"/>s of the batch.
        /// </param>
        /// <returns>
        /// A <see cref="System.Decimal"/> BU:GU ratio value.
        /// </returns>
        public static decimal CalculateBalanceRatio(
            SpecificGravity finalGravity,
            SpecificGravity originalGravity,
            Ibu bitterness)
        {
            if (finalGravity.IsZero() && originalGravity.IsZero())
            {
                throw new ArgumentException("finalGravity and originalGravity must not be 0.");
            }
            decimal realTerminalExtract = (Balance.FinalGravityRatio * finalGravity.Points)
                + (Balance.OriginalGravityRatio * originalGravity.Points);

            return (bitterness.Value * Balance.IbuRatio) / realTerminalExtract;
        }
    }
}
