namespace BeerMath
{
    public class Ounce
    {
        public decimal Value { get; private set; }

        public Ounce(decimal ounce = 0m)
        {
            Value = ounce;
        }
    }
}
