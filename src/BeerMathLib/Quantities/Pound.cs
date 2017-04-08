namespace BeerMath
{
    public class Pound
    {
        public decimal Value { get; private set; }

        public Pound(decimal pound = 0m)
        {
            Value = pound;
        }
    }
}
