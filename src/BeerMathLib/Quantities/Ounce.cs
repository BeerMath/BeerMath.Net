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
    }
}
