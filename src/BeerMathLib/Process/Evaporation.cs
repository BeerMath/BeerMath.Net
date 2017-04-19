namespace BeerMath
{
    using System;

    public class Evaporation
    {
        private const decimal StandardRate = 0.1m;

        /// <summary>
        /// Amount of wort lost to evaporation, using a standard rate
        /// </summary>
        public static Gallon CalculateLoss (Gallon wort, TimeSpan boilTime)
        {
            return CalculateLoss(wort, boilTime, Evaporation.StandardRate);
        }

        /// <summary>
        /// Amount of wort lost to evaporation, using a custom rate
        /// </summary>
        public static Gallon CalculateLoss (Gallon wort, TimeSpan boilTime, decimal rate)
        {
            //Evaporation Loss = (Preboil Volume * ((Evaporation Rate / 60) x Total Boil Time) /100)
            return new Gallon(wort.Value * ((rate / 60.0m) * (decimal)boilTime.TotalMinutes));
        }

        /// <summary>
        /// Calculates rate of evaporation for a system
        /// </summary>
        public static decimal CalculateRate (Gallon startVolume, Gallon endVolume)
        {
            return (startVolume.Value / endVolume.Value) / startVolume.Value;
        }
    }
}
