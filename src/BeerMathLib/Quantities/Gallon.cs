namespace BeerMath
{
    public class Gallon
    {
        public decimal Value { get; private set; }

        public Gallon(decimal gallon = 0m)
        {
            Value = gallon;
        }
    }
}
