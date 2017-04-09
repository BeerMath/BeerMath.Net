using BeerMath;
using BeerMath.Convenient;
using Xunit;

namespace Tests
{
    public class ConvenienceTest
    {
        [Fact]
        public void QuantityConvenienceMethods()
        {
            Assert.IsType<Ounce>(1.oz());
            Assert.IsType<Ounce>(1.0.oz());
            Assert.IsType<Ounce>(1m.oz());

            Assert.IsType<Pound>(1.lbs());
            Assert.IsType<Pound>(1.0.lbs());
            Assert.IsType<Pound>(1m.lbs());

            Assert.IsType<Gallon>(1.gals());
            Assert.IsType<Gallon>(1.0.gals());
            Assert.IsType<Gallon>(1m.gals());
        }

        [Fact]
        public void BitternessConvenienceMethods()
        {
            Assert.IsType<Ibu>(1.ibus());
            Assert.IsType<Ibu>(1.0.ibus());
            Assert.IsType<Ibu>(1m.ibus());

            Assert.IsType<Hbu>(1.hbus());
            Assert.IsType<Hbu>(1.0.hbus());
            Assert.IsType<Hbu>(1m.hbus());

            Assert.IsType<AlphaAcid>(1.aaus());
            Assert.IsType<AlphaAcid>(1.0.aaus());
            Assert.IsType<AlphaAcid>(1m.aaus());
        }

        [Fact]
        public void ColorConvenienceMethods()
        {
            Assert.IsType<Ebc>(1.ebc());
            Assert.IsType<Ebc>(1.0.ebc());
            Assert.IsType<Ebc>(1m.ebc());

            Assert.IsType<Srm>(1.srm());
            Assert.IsType<Srm>(1.0.srm());
            Assert.IsType<Srm>(1m.srm());

            Assert.IsType<Mcu>(1.mcus());
            Assert.IsType<Mcu>(1.0.mcus());
            Assert.IsType<Mcu>(1m.mcus());

            Assert.IsType<Lovibond>(1.lov());
            Assert.IsType<Lovibond>(1.0.lov());
            Assert.IsType<Lovibond>(1m.lov());
        }

        [Fact]
        public void StrengthConvenienceMethods()
        {
            Assert.IsType<Abv>(1.abv());
            Assert.IsType<Abv>(1.0.abv());
            Assert.IsType<Abv>(1m.abv());

            Assert.IsType<Abw>(1.abw());
            Assert.IsType<Abw>(1.0.abw());
            Assert.IsType<Abw>(1m.abw());

            Assert.IsType<SpecificGravity>(1.grav());
            Assert.IsType<SpecificGravity>(1.0.grav());
            Assert.IsType<SpecificGravity>(1m.grav());

            Assert.IsType<SpecificGravity>(1.points());
            Assert.IsType<SpecificGravity>(1.0.points());
            Assert.IsType<SpecificGravity>(1m.points());

            Assert.IsType<SpecificGravity>(1.plato());
            Assert.IsType<SpecificGravity>(1.0.plato());
            Assert.IsType<SpecificGravity>(1m.plato());
        }
    }
}
