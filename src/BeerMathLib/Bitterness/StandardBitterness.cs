using System;

namespace BeerMath
{
    public static class StandardBitterness
    {
        private const decimal MagicNumber = 7.25m;

        public static Ibu CalculateIbus(AlphaAcid rating, Ounce Hops, TimeSpan boil)
        {
            return new Ibu(
                (rating.Value * Hops.Value * StandardUtilization(boil))
                / StandardBitterness.MagicNumber
            );
        }

        private static decimal StandardUtilization (TimeSpan boil)
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
            var minutes = boil.TotalMinutes;

            if(minutes < 0)
                throw new ArgumentOutOfRangeException("Boil time cannot be negative");

            if(minutes <= 5)
                return 5m;
            if(minutes <= 10)
                return 6m;
            if(minutes <= 15)
                return 8m;
            if(minutes <= 20)
                return 10.1m;
            if(minutes <= 25)
                return 12.1m;
            if(minutes <= 30)
                return 15.3m;
            if(minutes <= 35)
                return 18.8m;
            if(minutes <= 40)
                return 22.8m;
            if(minutes <= 45)
                return 26.9m;
            if(minutes <= 50)
                return 28.1m;
            if(minutes <= 60)
                return 30m;

            throw new ArgumentOutOfRangeException("Boil times greater than 60 minutes are not supported");
        }
    }
}