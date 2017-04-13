using BeerMath;
using Xunit;

namespace Tests
{
    public class BaseClassTest
    {
        [Fact]
        public void Base()
        {
            Assert.IsType<Gallon>(new Gallon(1m));
            Assert.IsAssignableFrom<BeerValue>(new Gallon(1m));

            Assert.Equal(new Gallon(1m).GetHashCode(), 1m.GetHashCode());

            Assert.Equal(new Gallon(1m), new Gallon(1m));
            Assert.NotEqual(new Gallon(1m), new Gallon(2m));

            Assert.NotEqual<BeerValue>(new Gallon(1m), new Ounce(1m));
        }
    }
}
