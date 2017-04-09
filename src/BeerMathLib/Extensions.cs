namespace BeerMath.Convenient
{
    using BeerMath;

    public static class Extensions
    {
        // ---------------------------------------
        // quantities
        public static Ounce oz(this decimal value) { return new Ounce(value); }

        public static Ounce oz(this int value) { return new Ounce((decimal)value); }

        public static Ounce oz(this double value) { return new Ounce((decimal)value); }

        public static Pound lbs(this decimal value) { return new Pound(value); }

        public static Pound lbs(this int value) { return new Pound((decimal)value); }

        public static Pound lbs(this double value) { return new Pound((decimal)value); }

        public static Gallon gals(this decimal value) { return new Gallon(value); }

        public static Gallon gals(this int value) { return new Gallon((decimal)value); }

        public static Gallon gals(this double value) { return new Gallon((decimal)value); }

        // ---------------------------------------
        // bitterness
        public static Ibu ibus(this decimal value) { return new Ibu(value); }

        public static Ibu ibus(this int value) { return new Ibu((decimal)value); }

        public static Ibu ibus(this double value) { return new Ibu((decimal)value); }

        public static Hbu hbus(this decimal value) { return new Hbu(value); }

        public static Hbu hbus(this int value) { return new Hbu((decimal)value); }

        public static Hbu hbus(this double value) { return new Hbu((decimal)value); }

        public static AlphaAcid aaus(this decimal value) { return AlphaAcid.FromPercent(value); }

        public static AlphaAcid aaus(this int value) { return AlphaAcid.FromPercent((decimal)value); }

        public static AlphaAcid aaus(this double value) { return AlphaAcid.FromPercent((decimal)value); }

        // ---------------------------------------
        // color
        public static Ebc ebc(this decimal value) { return new Ebc(value); }

        public static Ebc ebc(this int value) { return new Ebc((decimal)value); }

        public static Ebc ebc(this double value) { return new Ebc((decimal)value); }

        public static Lovibond lov(this decimal value) { return new Lovibond(value); }

        public static Lovibond lov(this int value) { return new Lovibond((decimal)value); }

        public static Lovibond lov(this double value) { return new Lovibond((decimal)value); }

        public static Mcu mcus(this decimal value) { return new Mcu(value); }

        public static Mcu mcus(this int value) { return new Mcu((decimal)value); }

        public static Mcu mcus(this double value) { return new Mcu((decimal)value); }

        public static Srm srm(this decimal value) { return new Srm(value); }

        public static Srm srm(this int value) { return new Srm((decimal)value); }

        public static Srm srm(this double value) { return new Srm((decimal)value); }

        // ---------------------------------------
        // strength
        public static Abv abv(this decimal value) { return new Abv(value); }

        public static Abv abv(this int value) { return new Abv((decimal)value); }

        public static Abv abv(this double value) { return new Abv((decimal)value); }

        public static Abw abw(this decimal value) { return new Abw(value); }

        public static Abw abw(this int value) { return new Abw((decimal)value); }

        public static Abw abw(this double value) { return new Abw((decimal)value); }

        public static SpecificGravity grav(this decimal value) { return SpecificGravity.FromGravity(value); }

        public static SpecificGravity grav(this int value) { return SpecificGravity.FromGravity((decimal)value); }

        public static SpecificGravity grav(this double value) { return SpecificGravity.FromGravity((decimal)value); }

        public static SpecificGravity points(this decimal value) { return SpecificGravity.FromPoints(value); }

        public static SpecificGravity points(this int value) { return SpecificGravity.FromPoints((decimal)value); }

        public static SpecificGravity points(this double value) { return SpecificGravity.FromPoints((decimal)value); }

        public static SpecificGravity plato(this decimal value) { return SpecificGravity.FromPlato(value); }

        public static SpecificGravity plato(this int value) { return SpecificGravity.FromPlato((decimal)value); }

        public static SpecificGravity plato(this double value) { return SpecificGravity.FromPlato((decimal)value); }
    }
}
