using BeerMath;
using System;
using Xunit;

namespace Tests
{
    public class HopsTest
    {
        [Fact]
        public void IbuFromStandard ()
        {
            decimal alpha = 6.0m;
            decimal ozs = 1.0m;
            decimal minutes = 60m;

            var result = StandardBitterness.CalculateIbus(alpha, ozs, minutes);

            Assert.True(result.Value >= 24.82m);
            Assert.True(result.Value <= 24.83m);
        }

        [Fact]
        public void IbuFromTinseth ()
        {
            decimal alpha = 6.0m;
            decimal ozs = 1.0m;
            decimal minutes = 60m;
            SpecificGravity gravity = SpecificGravity.FromPoints(50m);
            Gallon gallons = new Gallon(5m);

            var result = Tinseth.CalculateIbus(alpha, ozs, minutes, gravity, gallons);

            Assert.True(result.Value >= 20.73m);
            Assert.True(result.Value <= 20.74m);
        }

        [Fact]
        public void IbuFromRager()
        {
            decimal alpha = 6.0m;
            decimal ozs = 1.0m;
            decimal minutes = 60m;
            SpecificGravity gravity = SpecificGravity.FromPoints(50m);
            Gallon gallons = new Gallon(5m);

            var result = Rager.CalculateIbus(alpha, ozs, gallons, gravity, minutes);

            Assert.True(result.Value >= 27.59m);
            Assert.True(result.Value <= 27.60m);
        }

        [Fact]
        public void IbuFromGaretz()
        {
            decimal alpha = 5.5m;
            decimal ozs = 1.0m;
            decimal minutes = 60m;
            SpecificGravity gravity = SpecificGravity.FromPoints(50m);
            Gallon finalVolume = new Gallon(5m);
            Gallon boilVolume = new Gallon(6.0m);
            Ibu desired = new Ibu(20m);
            decimal elevation = 550m;

            var result = Garetz.CalculateIbus(alpha, ozs, finalVolume, boilVolume, gravity, minutes, desired, elevation);

            Assert.True(result.Value <= 15.9m);
            Assert.True(result.Value >= 15.8m);
        }

        [Fact]
        public void HbuTest()
        {
            decimal alpha = 6.0m;
            decimal hopsOz = 1.0m;
            var result = Hbu.FromHopsBill(alpha, hopsOz);

            Assert.True(result.Value == 6.0m);
        }
    }
}
