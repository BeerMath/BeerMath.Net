namespace BeerMath
{
    public class Ibu : BeerValue
    {
        // private constructor so consumers cannot create
        private Ibu() { }

        public Ibu(decimal raw)
        {
            Value = raw;
        }
    }
}