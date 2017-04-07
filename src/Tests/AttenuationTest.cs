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
            SpecificGravity OG = SpecificGravity.FromPoints(56m);
            SpecificGravity FG = SpecificGravity.FromPoints(10m);

            var result = Attenuation.Apparent(OG, FG);

            Assert.True(result.Value >= 82.14m);
            Assert.True(result.Value <= 82.15m);
            Assert.True(result.Type == Attenuation.AttenuationType.Apparent);
        }

        [Fact]
        public void RealCase ()
        {
            SpecificGravity OG = SpecificGravity.FromPoints(56m);
            SpecificGravity FG = SpecificGravity.FromPoints(10m);

            var result = Attenuation.Real(OG, FG);

            Assert.True(result.Value >= 66.53m);
            Assert.True(result.Value <= 66.54m);
            Assert.True(result.Type == Attenuation.AttenuationType.Real);
        }
    }
}
