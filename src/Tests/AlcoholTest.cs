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
            SpecificGravity OG = SpecificGravity.FromPoints(56m);
            SpecificGravity FG = SpecificGravity.FromPoints(10m);

            var result = Abv.FromOgFg(OG, FG);

            Assert.True(result.Value >= 5.98m);
            Assert.True(result.Value <= 5.99m);
        }

        [Fact]
        public void AbwCase ()
        {
            SpecificGravity OG = SpecificGravity.FromPoints(56m);
            SpecificGravity FG = SpecificGravity.FromPoints(10m);

            var result = Abw.FromOgFg(OG, FG);

            Assert.True(result.Value >= 4.67m);
            Assert.True(result.Value <= 4.68m);
        }

        [Fact]
        public void CalorieTest()
        {
            SpecificGravity originalGravity = SpecificGravity.FromPoints(70m);
            SpecificGravity finalGravity = SpecificGravity.FromPoints(15m);

            var result = Calorie.FromOgFg(originalGravity, finalGravity);

            Assert.True(result.Value <= 228m);
            Assert.True(result.Value >= 227.5m);
        }
    }
}
