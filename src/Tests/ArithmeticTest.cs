using BeerMath;
using BeerMath.Convenient;
using Xunit;

namespace Tests
{
    public class ArithmeticTest
    {
        [Fact]
        public void Addition()
        {
            Assert.IsType<Gallon>(1.gals() + 1.gals());
            Assert.Equal(1.gals() + 2.gals(), 3.gals());

            Assert.IsType<Ounce>(1.oz() + 1.oz());
            Assert.Equal(1.oz() + 2.oz(), 3.oz());
            Assert.IsType<Ounce>(1.oz() + 1.lbs());
            Assert.Equal(1.oz() + 1.lbs(), 17.oz());

            Assert.IsType<Pound>(1.lbs() + 1.lbs());
            Assert.Equal(1.lbs() + 2.lbs(), 3.lbs());
            Assert.IsType<Pound>(1.lbs() + 1.oz());
            Assert.Equal(1.lbs() + 8.oz(), 1.5m.lbs());
        }
    }
}
