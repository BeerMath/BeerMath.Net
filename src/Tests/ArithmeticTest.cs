using BeerMath;
using BeerMath.Convenient;
using System;
using Xunit;

namespace Tests
{
    public class ArithmeticTest
    {
        [Fact]
        public void Addition()
        {
            // add gallons
            Assert.IsType<Gallon>(1.gals() + 1.gals());
            Assert.Equal(1.gals() + 2.gals(), 3.gals());

            // add ounces
            Assert.IsType<Ounce>(1.oz() + 1.oz());
            Assert.Equal(1.oz() + 2.oz(), 3.oz());

            // add pounds
            Assert.IsType<Pound>(1.lbs() + 1.lbs());
            Assert.Equal(1.lbs() + 2.lbs(), 3.lbs());
        }

        [Fact]
        public void MixedAddition()
        {
            // mix ounces and pounds
            Assert.IsType<Pound>(1.lbs() + 1.oz());
            Assert.Equal(1.lbs() + 8.oz(), 1.5m.lbs());

            // implicit conversion to pounds
            Assert.IsType<Pound>(1.oz() + 1.lbs());
            Assert.Equal(1.oz() + 1.lbs(), 17.oz());

            // explicit conversion to ounces
            Assert.IsType<Ounce>(1.oz() + (Ounce)1.lbs());
        }

        [Fact]
        public void Subtraction()
        {
            // subtract gallons
            Assert.IsType<Gallon>(2.gals() - 1.gals());
            Assert.Equal(2.gals() - 1.gals(), 1.gals());
            Assert.Equal(1.gals() - 1.gals(), 0.gals());

            // subtract ounces
            Assert.IsType<Ounce>(10.oz() - 1.oz());
            Assert.Equal(10.oz() - 2.oz(), 8.oz());
            Assert.Equal(10.oz() - 10.oz(), 0.oz());

            // subtract pounds
            Assert.IsType<Pound>(3.lbs() + 2.lbs());
            Assert.Equal(3.lbs() - 2.lbs(), 1.lbs());
            Assert.Equal(2.lbs() - 2.lbs(), 0.lbs());
        }

        [Fact]
        public void NoNegatives()
        {
            Assert.Throws<OverflowException>(() => 1.gals() - 2.gals());
            Assert.Throws<OverflowException>(() => 1.oz() - 2.oz());
            Assert.Throws<OverflowException>(() => 1.lbs() - 2.lbs());
        }
    }
}
