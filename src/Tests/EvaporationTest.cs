using BeerMath;
using System;
using Xunit;

namespace Tests
{
    public class EvaporationTest
    {

        [Fact]
        public void Standard ()
        {
            Gallon wort = new Gallon(6m);
            TimeSpan boil = new TimeSpan(0, 60, 0);

            var result = Evaporation.CalculateLoss(wort, boil);

            Assert.True(result.Value >= 0.599m);
            Assert.True(result.Value <= 0.61m);
        }

        [Fact]
        public void Custom ()
        {
            Gallon wort = new Gallon(6m);
            TimeSpan boil = new TimeSpan(0, 60, 0);
            decimal rate = 0.2m;

            var result = Evaporation.CalculateLoss(wort, boil, rate);

            Assert.True(result.Value >= 1.199m);
            Assert.True(result.Value <= 1.21m);
        }

        [Fact]
        public void RateCase ()
        {
            Gallon pre = new Gallon(5m);
            Gallon post = new Gallon(4m);

            var result = Evaporation.CalculateRate(pre, post);

            Assert.True(result >= 0.249m);
            Assert.True(result <= 0.26m);
        }
    }
}
