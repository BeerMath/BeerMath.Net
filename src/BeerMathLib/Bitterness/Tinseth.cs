using System;

namespace BeerMath
{
    /// <summary>
    /// Constants related to Glenn Tinseth's IBU methods
    /// http://realbeer.com/hops/research.html
    /// </summary>
    public static class Tinseth
    {
        public const decimal BignessCoefficient = 1.65m;
        public const decimal BignessBase = 0.000125m;
        public const decimal BoiltimeShape = -0.04m;
        public const decimal BoiltimeMaximumUtilization = 4.15m;
        public const decimal NonmetricMagicNumber = 74.9m;

        public static Ibu CalculateIbus(decimal AlphaAcid, decimal Ozs, decimal BoilMinutes, SpecificGravity Gravity, Gallon Wort)
        {
            // IBUs = (Boil Time Factor * Bigness Factor) * (mg/l of added alpha acids)
            return Ibu.FromDecimal(
                BoilTimeFactor(BoilMinutes)
                * BignessFactor(Gravity)
                * MgAlphaAcids(AlphaAcid, Ozs, Wort)
            );
        }

        private static decimal MgAlphaAcids (decimal AlphaAcid, decimal Ozs, Gallon FinalVolume)
        {
            // mg/l of added alpha acids = (decimal AA rating * oz's hops * 7490) / (volume of finished beer in gallons)
            return (AlphaAcid * Ozs * Tinseth.NonmetricMagicNumber) / FinalVolume.Value;
        }


        private static decimal BignessFactor (SpecificGravity Gravity)
        {
            // Bigness factor = 1.65 * 0.000125^(wort gravity - 1)
            return (decimal)((double)Tinseth.BignessCoefficient * Math.Pow((double)Tinseth.BignessBase, (double)(Gravity.Value - 1)));
        }


        private static decimal BoilTimeFactor (decimal BoilMinutes)
        {
            // Boil Time factor =1 - e^(-0.04 * time in min's) / ( 4.15)
            return (decimal)((1 - Math.Pow(Math.E, (double)(Tinseth.BoiltimeShape * BoilMinutes))) / (double)Tinseth.BoiltimeMaximumUtilization);
        }
    }
}