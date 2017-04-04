using System;

namespace BeerMath
{
    public class Ibu
    {
        public decimal Value { get; private set; }

        public static Ibu FromStandard(decimal AlphaAcid, decimal HopsOzs, decimal BoilMinutes)
        {
            return new Ibu()
            {
                Value = (AlphaAcid * HopsOzs * StandardUtilization(BoilMinutes)) / IbuMagicNumber,
            };
        }

        public static Ibu FromTinseth(decimal AlphaAcid, decimal Ozs, decimal BoilMinutes, Gravity Gravity, decimal Gallons)
        {
            // IBUs = (Boil Time Factor * Bigness Factor) * (mg/l of added alpha acids)
            return new Ibu()
            {
                Value = BoilTimeFactor(BoilMinutes)
                      * BignessFactor(Gravity)
                      * MgAlphaAcids(AlphaAcid, Ozs, Gallons),
            };
        }

        // TODO: move this logic to Rager.cs
        public static Ibu FromRager(decimal AlphaAcidRating, decimal Oz, decimal Volume,
            Gravity WortGravity, decimal BoilMinutes)
        {
            decimal GravityAdjustment = 0;

            // According to Rager, if the gravity of the wort exceeds 1.050, there needs to be a gravity adjustment in the equation.
            if (WortGravity.Value > Rager.Gravity.AdjustmentMinimum)
            {
                GravityAdjustment = Rager.AdjustGravity(WortGravity);
            }

            // Alpha acid utilization.
            decimal Utilization = Rager.CalculateUtilization(BoilMinutes);

            // Convert utilization and alpha acid to percentage
            Utilization = Utilization / 100m;
            AlphaAcidRating = AlphaAcidRating / 100m;

            return new Ibu() {
                Value = (Oz * Utilization * AlphaAcidRating * Rager.MetricConversionFactor)
                        / (Volume * (1 + GravityAdjustment)),
            };
        }

        // private constructor so consumers cannot create
        private Ibu() { }

        private static decimal StandardUtilization (decimal BoilMinutes)
        {
            /*
             * Percent Utilization Chart:
                00-05 minutes 5.0%
                06-10 minutes 6.0%
                11-15 minutes 8.0%
                16-20 minutes 10.1%
                21-25 minutes 12.1%
                26-30 minutes 15.3%
                31-35 minutes 18.8%
                34-40 minutes 22.8%
                41-45 minutes 26.9%
                46-50 minutes 28.1%
                51-60 minutes 30.0%
            */
            if(BoilMinutes < 0)
                throw new ArgumentOutOfRangeException("Boil time cannot be negative");

            if(BoilMinutes <= 5)
                return 5m;
            if(BoilMinutes <= 10)
                return 6m;
            if(BoilMinutes <= 15)
                return 8m;
            if(BoilMinutes <= 20)
                return 10.1m;
            if(BoilMinutes <= 25)
                return 12.1m;
            if(BoilMinutes <= 30)
                return 15.3m;
            if(BoilMinutes <= 35)
                return 18.8m;
            if(BoilMinutes <= 40)
                return 22.8m;
            if(BoilMinutes <= 45)
                return 26.9m;
            if(BoilMinutes <= 50)
                return 28.1m;
            if(BoilMinutes <= 60)
                return 30m;

            throw new ArgumentOutOfRangeException("Boil times greater than 60 minutes are not supported");
        }

        private static decimal MgAlphaAcids (decimal AlphaAcid, decimal Ozs, decimal Gallons)
        {
            // mg/l of added alpha acids = (decimal AA rating * oz's hops * 7490) / (volume of finished beer in gallons)
            return (AlphaAcid * Ozs * Tinseth.NonmetricMagicNumber) / Gallons;
        }


        private static decimal BignessFactor (Gravity Gravity)
        {
            // Bigness factor = 1.65 * 0.000125^(wort gravity - 1)
            return (decimal)((double)Tinseth.BignessCoefficient * Math.Pow((double)Tinseth.BignessBase, (double)(Gravity.Value - 1)));
        }


        private static decimal BoilTimeFactor (decimal BoilMinutes)
        {
            // Boil Time factor =1 - e^(-0.04 * time in min's) / ( 4.15)
            return (decimal)((1 - Math.Pow(Math.E, (double)(Tinseth.BoiltimeShape * BoilMinutes))) / (double)Tinseth.BoiltimeMaximumUtilization);
        }

        private const decimal IbuMagicNumber = 7.25m;
    }
}