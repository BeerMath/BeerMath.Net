using System;

namespace BeerMath
{

    /// <summary>
    /// Alcohol by volume
    /// </summary>
    public sealed class Abv : BeerValue
    {
        public Abv(decimal abv)
        {
            this.Value = abv;
        }

        public static Abv FromOgFg(SpecificGravity originalGravity, SpecificGravity finalGravity)
        {
            return new Abv((originalGravity.Value - finalGravity.Value) * abvFactor(originalGravity.Value - finalGravity.Value));
        }

        private static decimal abvFactor(decimal gravityDifference)
        {
            /*
            Grav diff           Factor
            0.0000 - 0.0069     125
            0.0070 – 0.0104     126
            0.0105 – 0.0172     127
            0.0173 – 0.0261     128
            0.0262 – 0.0360     129
            0.0361 – 0.0465     130
            0.0466 – 0.0571     131
            0.0572 – 0.0679     132
            0.0680 – 0.0788     133
            0.0789 – 0.0897     134
            0.0898 – 0.1007      135

            source: http://www.hmrc.gov.uk/manuals/beerpolmanual/BEERPOL12030.htm
             */
            if(gravityDifference < 0)
                throw new ArgumentOutOfRangeException("Gravity difference cannot be negative");

            if(gravityDifference <= 0.0069m)
                return 125m;
            if(gravityDifference <= 0.0104m)
                return 126m;
            if(gravityDifference <= 0.0172m)
                return 127m;
            if(gravityDifference <= 0.0261m)
                return 128m;
            if(gravityDifference <= 0.0360m)
                return 129m;
            if(gravityDifference <= 0.0465m)
                return 130m;
            if(gravityDifference <= 0.0571m)
                return 131m;
            if(gravityDifference <= 0.0679m)
                return 132m;
            if(gravityDifference <= 0.0788m)
                return 133m;
            if(gravityDifference <= 0.0897m)
                return 134m;
            if(gravityDifference <= 0.1007m)
                return 135m;

            throw new ArgumentOutOfRangeException("Gravity differences greater than 0.1007 are not supported");
        }
    }
}
