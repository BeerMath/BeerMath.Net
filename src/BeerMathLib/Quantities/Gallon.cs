namespace BeerMath
{
    using System;

    public class Gallon : BeerValue
    {
        public Gallon(decimal gallons = 0m)
        {
            Value = gallons;
        }

        public static Gallon operator +(Gallon gallon1, Gallon gallon2)
        {
            return new Gallon(gallon1.Value + gallon2.Value);
        }

        public static Gallon operator -(Gallon gallon1, Gallon gallon2)
        {
            var result = gallon1.Value - gallon2.Value;
            if (result < 0m)
            {
                throw new OverflowException($"{nameof(Gallon)} may not be negative");
            }
            return new Gallon(result);
        }
    }
}
