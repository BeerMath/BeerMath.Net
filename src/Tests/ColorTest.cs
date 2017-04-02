using BeerMath;
using System;
using Xunit;

namespace Tests
{
	public class ColorTest
	{

		[Fact]
		public void McuFromGrain ()
		{
			decimal lbs = 10m;
			decimal degrees = 20m;
			decimal gallons = 5m;

			var result = Mcu.FromGrainBill(lbs, degrees, gallons);

			Assert.True(result.Value >= 40m);
			Assert.True(result.Value <= 40.01m);
		}

		[Fact]
		public void McuFromSum ()
		{
			decimal lbs = 10m;
			decimal degrees = 20m;
			decimal gallons = 5m;

			var color1 = Mcu.FromGrainBill(lbs, degrees, gallons);
			var color2 = Mcu.FromGrainBill(lbs, degrees, gallons);
			var sumColor = color1 + color2;

			Assert.True(sumColor.Value >= 80m);
			Assert.True(sumColor.Value <= 80.02m);
		}

		[Fact]
		public void SrmFromMcu ()
		{
			decimal lbs = 10m;
			decimal degrees = 20m;
			decimal gallons = 5m;

			var mcu = Mcu.FromGrainBill(lbs, degrees, gallons);
			var result = Srm.EstimateMorey(mcu);

			Assert.True(result.Value >= 18.73m);
			Assert.True(result.Value <= 18.74m);
		}

		[Fact]
		public void SrmExceedingLimit ()
		{
			decimal lbs = 10m;
			decimal degrees = 200m;
			decimal gallons = 5m;

			var mcu = Mcu.FromGrainBill(lbs, degrees, gallons);

			Assert.Throws<InaccurateResultException>(() => Srm.EstimateMorey(mcu));
		}

		[Fact]
		public void EbcFromSrm ()
		{
			decimal lbs = 10m;
			decimal degrees = 20m;
			decimal gallons = 5m;

			var mcu = Mcu.FromGrainBill(lbs, degrees, gallons);
			var srm = Srm.EstimateMorey(mcu);
			var result = Ebc.FromSrm(srm);

			Assert.True(result.Value >= 36.91m);
			Assert.True(result.Value <= 36.92m);
		}
	}
}
