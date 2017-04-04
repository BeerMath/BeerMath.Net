using System;

namespace BeerMath
{
    public class Ibu
    {
        public decimal Value { get; private set; }

        // private constructor so consumers cannot create
        private Ibu() { }

        public static Ibu FromDecimal(decimal raw)
        {
            return new Ibu() { Value = raw };
        }
    }
}