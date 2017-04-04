using System;

namespace BeerMath
{
    public sealed class Hops
    {
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
