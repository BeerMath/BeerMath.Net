using BeerMath;
using System;
using Xunit;

using System.Diagnostics;

namespace Tests
{
    public class FlavorTest
    {
        [Fact]
        public void BalanceRatio()
        {
            decimal result = Balance.CalculateBalanceRatio(SpecificGravity.FromPoints(10m), SpecificGravity.FromPoints(40m), Ibu.FromDecimal(40m));

            Assert.True(result <= 2.09m);
            Assert.True(result >= 2.07m);
        }
    }
}
