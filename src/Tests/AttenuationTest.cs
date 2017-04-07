using BeerMath;
using System;
using Xunit;

namespace Tests
{
    public class AttenuationTest
    {

        [Fact]
        public void ApparentCase ()
        {
            Gravity OG = new Gravity(56m);
            Gravity FG = new Gravity(10m);

            var result = Attenuation.Apparent(OG, FG);

            Assert.True(result.Value >= 82.14m);
            Assert.True(result.Value <= 82.15m);
            Assert.True(result.Type == Attenuation.AttenuationType.Apparent);
        }

        [Fact]
        public void RealCase ()
        {
            Gravity OG = new Gravity(56m);
            Gravity FG = new Gravity(10m);

            var result = Attenuation.Real(OG, FG);

            Assert.True(result.Value >= 66.53m);
            Assert.True(result.Value <= 66.54m);
            Assert.True(result.Type == Attenuation.AttenuationType.Real);
        }
    }
}
