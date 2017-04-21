using BeerMath;
using BeerMath.Fluent;
using System;
using Xunit;

namespace Tests
{
    public class FluentBitternessTest
    {
        [Fact]
        public void Standard()
        {
            AlphaAcid alpha = new AlphaAcid(6.0m);
            Ounce ozs = new Ounce(1.0m);
            TimeSpan minutes = new TimeSpan(0, 60, 0);

            var result1 = StandardBitterness.CalculateIbus(alpha, ozs, minutes);
            var result2 = BitternessCalculator
            .Standard
            .AlphaAcid(alpha)
            .Amount(ozs)
            .BoilTime(minutes)
            .Calculate();

            Assert.True(result1.Value == result2.Value);
        }

        [Fact]
        public void StandardThrow()
        {
            AlphaAcid alpha = new AlphaAcid(6.0m);
            Ounce ozs = new Ounce(1.0m);
            TimeSpan minutes = new TimeSpan(0, 60, 0);

            var partial1 = BitternessCalculator
            .Standard
            .Amount(ozs)
            .BoilTime(minutes);

            Assert.Throws<ArgumentNullException>(() => partial1.Calculate());

            var partial2 = BitternessCalculator
            .Standard
            .AlphaAcid(alpha)
            .Amount(ozs);

            Assert.Throws<ArgumentNullException>(() => partial2.Calculate());
        }

        [Fact]
        public void Garetz()
        {
            AlphaAcid alpha = new AlphaAcid(5.5m);
            Ounce ozs = new Ounce(1.0m);
            TimeSpan minutes = new TimeSpan(0, 60, 0);
            SpecificGravity gravity = SpecificGravity.FromPoints(50m);
            Gallon finalVolume = new Gallon(5m);
            Gallon boilVolume = new Gallon(6.0m);
            Ibu desired = new Ibu(20m);
            decimal elevation = 550m;

            var result1 = BeerMath.Garetz.CalculateIbus(alpha, ozs, finalVolume, boilVolume, gravity, minutes, desired, elevation);
            var result2 = BitternessCalculator
            .Garetz
            .AlphaAcid(alpha)
            .Amount(ozs)
            .FinalVolume(finalVolume)
            .BoilVolume(boilVolume)
            .WortGravity(gravity)
            .BoilTime(minutes)
            .DesiredIbus(desired)
            .Elevation(elevation)
            .Calculate();

            Assert.True(result1.Value == result2.Value);
        }

        [Fact]
        public void Rager()
        {
            AlphaAcid alpha = new AlphaAcid(6.0m);
            Ounce ozs = new Ounce(1.0m);
            TimeSpan minutes = new TimeSpan(0, 60, 0);
            SpecificGravity gravity = SpecificGravity.FromPoints(50m);
            Gallon gallons = new Gallon(5m);

            var result1 = BeerMath.Rager.CalculateIbus(alpha, ozs, gallons, gravity, minutes);
            var result2 = BitternessCalculator
            .Rager
            .AlphaAcid(alpha)
            .Amount(ozs)
            .BoilVolume(gallons)
            .WortGravity(gravity)
            .BoilTime(minutes)
            .Calculate();

            Assert.True(result1.Value == result2.Value);
        }

        [Fact]
        public void Tinseth ()
        {
            AlphaAcid alpha = new AlphaAcid(6.0m);
            Ounce ozs = new Ounce(1.0m);
            TimeSpan minutes = new TimeSpan(0, 60, 0);
            SpecificGravity gravity = SpecificGravity.FromPoints(50m);
            Gallon gallons = new Gallon(5m);

            var result1 = BeerMath.Tinseth.CalculateIbus(alpha, ozs, gallons, gravity, minutes);
            var result2 = BitternessCalculator
            .Tinseth
            .AlphaAcid(alpha)
            .Amount(ozs)
            .BoilVolume(gallons)
            .WortGravity(gravity)
            .BoilTime(minutes)
            .Calculate();

            Assert.True(result1.Value == result2.Value);
        }
    }
}
