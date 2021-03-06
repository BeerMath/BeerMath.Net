namespace BeerMath
{
    using System;

    public class Ounce : BeerValue
    {
        public Ounce(decimal ounce = 0m)
        {
            if (ounce < 0m)
            {
                throw new ArgumentOutOfRangeException("negative quantities not allowed");
            }

            Value = ounce;
        }

        public Ounce(uint pound, uint ounce)
        {
            Value = pound * 16m + ounce;
        }

        public Ounce(Pound pound)
        {
            if (pound.Value < 0m)
            {
                throw new ArgumentOutOfRangeException("negative quantities not allowed");
            }

            Value = pound.Value * 16m;
        }

        public static explicit operator Ounce(Pound pound)
        {
            return new Ounce(pound);
        }

        public static Ounce operator +(Ounce ounce1, Ounce ounce2)
        {
            return new Ounce(ounce1.Value + ounce2.Value);
        }

        public static Ounce operator -(Ounce Ounce1, Ounce Ounce2)
        {
            var result = Ounce1.Value - Ounce2.Value;
            if (result < 0m)
            {
                throw new OverflowException($"{nameof(Ounce)} may not be negative");
            }
            return new Ounce(result);
        }
    }
}
