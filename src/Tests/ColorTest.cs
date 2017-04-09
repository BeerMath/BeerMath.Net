using BeerMath;
using Xunit;

namespace Tests
{
    public class ColorTest
    {

        [Fact]
        public void McuFromGrain ()
        {
            Pound lbs = new Pound(10m);
            Lovibond degrees = new Lovibond(20m);
            Gallon gallons = new Gallon(5m);

            var result = Mcu.FromGrainBill(lbs, degrees, gallons);

            Assert.True(result.Value >= 40m);
            Assert.True(result.Value <= 40.01m);
        }

        [Fact]
        public void McuFromSum ()
        {
            Pound lbs = new Pound(10m);
            Lovibond degrees = new Lovibond(20m);
            Gallon gallons = new Gallon(5m);

            var color1 = Mcu.FromGrainBill(lbs, degrees, gallons);
            var color2 = Mcu.FromGrainBill(lbs, degrees, gallons);
            var sumColor = color1 + color2;

            Assert.True(sumColor.Value >= 80m);
            Assert.True(sumColor.Value <= 80.02m);
        }

        [Fact]
        public void SrmFromMcu ()
        {
            Pound lbs = new Pound(10m);
            Lovibond degrees = new Lovibond(20m);
            Gallon gallons = new Gallon(5m);

            var mcu = Mcu.FromGrainBill(lbs, degrees, gallons);
            var result = Srm.EstimateMorey(mcu);

            Assert.True(result.Value >= 18.73m);
            Assert.True(result.Value <= 18.74m);
        }

        [Fact]
        public void SrmExceedingLimit ()
        {
            Pound lbs = new Pound(10m);
            Lovibond degrees = new Lovibond(200m);
            Gallon gallons = new Gallon(5m);

            var mcu = Mcu.FromGrainBill(lbs, degrees, gallons);

            Assert.Throws<InaccurateResultException>(() => Srm.EstimateMorey(mcu));
        }

        [Fact]
        public void EbcFromSrm ()
        {
            Pound lbs = new Pound(10m);
            Lovibond degrees = new Lovibond(20m);
            Gallon gallons = new Gallon(5m);

            var mcu = Mcu.FromGrainBill(lbs, degrees, gallons);
            var srm = Srm.EstimateMorey(mcu);
            var result = Ebc.FromSrm(srm);

            Assert.True(result.Value >= 36.91m);
            Assert.True(result.Value <= 36.92m);
        }
    }
}
