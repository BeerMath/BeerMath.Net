namespace BeerMath
{
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
    }
}
