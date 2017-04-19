using System;

namespace BeerMath
{
    /// <summary>
    /// Constants related to Glenn Tinseth's IBU methods
    /// http://realbeer.com/hops/research.html
    /// </summary>
    public static class Tinseth
    {
        private const double BignessCoefficient = 1.65;
        private const double BignessBase = 0.000125;
        private const double BoiltimeShape = -0.04;
        private const double BoiltimeMaximumUtilization = 4.15;
        private const decimal NonmetricMagicNumber = 74.9m;

        public static Ibu CalculateIbus(AlphaAcid rating, Ounce hops, TimeSpan boilTime,
            SpecificGravity gravity, Gallon wort)
        {
            // IBUs = (Boil Time Factor * Bigness Factor) * (mg/l of added alpha acids)
            return new Ibu(
                BoilTimeFactor(boilTime)
                * BignessFactor(gravity)
                * MgAlphaAcids(rating, hops, wort)
            );
        }

        private static decimal MgAlphaAcids (AlphaAcid rating, Ounce hops, Gallon finalVolume)
        {
            // mg/l of added alpha acids = (decimal AA rating * oz's hops * 7490) / (volume of finished beer in gallons)
            return (rating.Value * hops.Value * Tinseth.NonmetricMagicNumber) / finalVolume.Value;
        }


        private static decimal BignessFactor (SpecificGravity gravity)
        {
            // Bigness factor = 1.65 * 0.000125^(wort gravity - 1)
            return (decimal)(Tinseth.BignessCoefficient
                * Math.Pow(Tinseth.BignessBase, (double)(gravity.Value - 1)));
        }


        private static decimal BoilTimeFactor (TimeSpan boilTime)
        {
            // Boil Time factor =1 - e^(-0.04 * time in min's) / ( 4.15)
            return (decimal)((1 - Math.Pow(Math.E, Tinseth.BoiltimeShape * boilTime.TotalMinutes))
                / Tinseth.BoiltimeMaximumUtilization);
        }
    }
}