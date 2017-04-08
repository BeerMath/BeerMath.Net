namespace BeerMath
{
    using System;

    public class Pound
    {
        public decimal Value { get; private set; }

        public Pound(decimal pound = 0m)
        {
            if (pound < 0m)
            {
                throw new ArgumentOutOfRangeException("negative quantities not allowed");
            }

            Value = pound;
        }

        public Pound(uint pound, uint ounce)
        {
            Value = (decimal)pound + (decimal)ounce / 16m;
        }

        public Pound(Ounce ounce)
        {
            if (ounce.Value < 0m)
            {
                throw new ArgumentOutOfRangeException("negative quantities not allowed");
            }

            Value = ounce.Value / 16m;
        }
    }
}
