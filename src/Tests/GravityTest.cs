using BeerMath;
using System;
using Xunit;

namespace Tests
{
    public class GravityTest
    {
        [Fact]
        public void OriginalGravityTest()
        {
            decimal grainLbs = 9.3125m; // 9 lbs 5 oz
            decimal extractPPG = 37m;
            decimal extractEfficiency = 0.75m;
            Gallon volume = new Gallon(5m);

            var result = SpecificGravity.OriginalGravityOfFermentable(grainLbs, extractPPG, extractEfficiency, volume);

            Assert.True(result.Points <= 52m);
            Assert.True(result.Points >= 51m);
        }

        [Fact]
        public void FinalGravityTest()
        {
            decimal grainLbs = 9.3125m; // 9 lbs 5 oz
            decimal extractPPG = 37m;
            decimal extractEfficiency = 0.75m;
            Gallon volume = new Gallon(5m);
            Attenuation apparentAttenuation = Attenuation.FromRaw(0.79m, Attenuation.AttenuationType.Apparent);

            var result = SpecificGravity.FinalGravityOfFermentable(grainLbs, extractPPG, extractEfficiency, volume, apparentAttenuation);

            Assert.True(result.Points <= 11m);
            Assert.True(result.Points >= 10m);
        }

        [Fact]
        public void FromPlato()
        {
            decimal plato = 10m;
            var result = SpecificGravity.FromPlato(plato);
            Assert.True(result.Value <= 1.041m);
            Assert.True(result.Value >= 1.040m);
            Assert.True(result.Points <= 40.1m);
            Assert.True(result.Points >= 40m);
        }

        [Fact]
        public void RealExtractTest()
        {
            SpecificGravity originalGravity = SpecificGravity.FromPoints(70m);
            SpecificGravity finalGravity = SpecificGravity.FromPoints(15m);

            SpecificGravity result = SpecificGravity.FromRealExtract(originalGravity, finalGravity);

            Assert.True(result.Plato <= 6.22m);
            Assert.True(result.Plato >= 6.21m);
        }
    }
}
