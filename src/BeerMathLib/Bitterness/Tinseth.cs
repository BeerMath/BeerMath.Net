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

        public static Ibu CalculateIbus(AlphaAcid rating, Ounce Hops, TimeSpan boil,
            SpecificGravity Gravity, Gallon Wort)
        {
            // IBUs = (Boil Time Factor * Bigness Factor) * (mg/l of added alpha acids)
            return new Ibu(
                BoilTimeFactor(boil)
                * BignessFactor(Gravity)
                * MgAlphaAcids(rating, Hops, Wort)
            );
        }

        private static decimal MgAlphaAcids (AlphaAcid rating, Ounce Hops, Gallon FinalVolume)
        {
            // mg/l of added alpha acids = (decimal AA rating * oz's hops * 7490) / (volume of finished beer in gallons)
            return (rating.Value * Hops.Value * Tinseth.NonmetricMagicNumber) / FinalVolume.Value;
        }


        private static decimal BignessFactor (SpecificGravity Gravity)
        {
            // Bigness factor = 1.65 * 0.000125^(wort gravity - 1)
            return (decimal)(Tinseth.BignessCoefficient
                * Math.Pow(Tinseth.BignessBase, (double)(Gravity.Value - 1)));
        }


        private static decimal BoilTimeFactor (TimeSpan boil)
        {
            // Boil Time factor =1 - e^(-0.04 * time in min's) / ( 4.15)
            return (decimal)((1 - Math.Pow(Math.E, Tinseth.BoiltimeShape * boil.TotalMinutes))
                / Tinseth.BoiltimeMaximumUtilization);
        }
    }
}