using BeerMath;
using System;
using Xunit;

namespace Tests
{
    public class AlcoholTest
    {
        [Fact]
        public void AbvCase ()
        {
            Gravity OG = new Gravity(56m);
            Gravity FG = new Gravity(10m);

            var result = Abv.FromOgFg(OG, FG);

            Assert.True(result.Value >= 5.98m);
            Assert.True(result.Value <= 5.99m);
        }

        [Fact]
        public void AbwCase ()
        {
            Gravity OG = new Gravity(56m);
            Gravity FG = new Gravity(10m);

            var result = Abw.FromOgFg(OG, FG);

            Assert.True(result.Value >= 4.67m);
            Assert.True(result.Value <= 4.68m);
        }

        [Fact]
        public void CalorieTest()
        {
            Gravity originalGravity = new Gravity(70m);
            Gravity finalGravity = new Gravity(15m);

            var result = Calorie.FromOgFg(originalGravity, finalGravity);

            Assert.True(result.Value <= 228m);
            Assert.True(result.Value >= 227.5m);
        }
    }
}
