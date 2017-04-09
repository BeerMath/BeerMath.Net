namespace Tests
{
    using BeerMath;
    using System;
    using Xunit;

    public class WeightTest
    {
        [Fact]
        public void PoundCreate()
        {
            {
                Pound pound = new Pound(10);
                Assert.True(pound.Value == 10m);
            }

            {
                Pound pound = new Pound(10, 5);
                Assert.True(pound.Value == 10.3125m);
            }

            {
                Pound pound = new Pound(0, 16);
                Assert.True(pound.Value == 1m);
            }

            {
                Pound pound = new Pound(0, 17);
                Assert.True(pound.Value == 1.0625m);
            }

            {
                Ounce ounce = new Ounce(12);
                Pound pound = new Pound(ounce);
                Assert.True(pound.Value == 0.75m);
            }
        }

        [Fact]
        public void OunceCreate()
        {
            {
                Ounce ounce = new Ounce(10);
                Assert.True(ounce.Value == 10m);
            }

            {
                Ounce ounce = new Ounce(10, 5);
                Assert.True(ounce.Value == 165m);
            }

            {
                Ounce ounce = new Ounce(0, 16);
                Assert.True(ounce.Value == 16m);
            }

            {
                Ounce ounce = new Ounce(0, 17);
                Assert.True(ounce.Value == 17m);
            }

            {
                Pound pound = new Pound(1);
                Ounce ounce = new Ounce(pound);
                Assert.True(ounce.Value == 16m);
            }
        }

        [Fact]
        public void OutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Ounce(-1m));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Pound(-1m));
        }
    }
}
