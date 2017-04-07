namespace BeerMath
{
    public class Ibu
    {
        public decimal Value { get; private set; }

        // private constructor so consumers cannot create
        private Ibu() { }

        public Ibu(decimal raw)
        {
            Value = raw;
        }
    }
}