using BeerMath;
using System;
using Xunit;

namespace Tests
{
	public class ColorTest
	{

		[Fact]
		public void McuCase ()
		{
			decimal grain = 10m;
			decimal degrees = 20m;
			decimal gallons = 5m;

			decimal result = Malt.CalculateMcu(grain, degrees, gallons);

			Assert.True(result >= 40m);
			Assert.True(result <= 40.01m);
		}

		[Fact]
		public void SrmCase ()
		{
			decimal grain = 10m;
			decimal degrees = 20m;
			decimal gallons = 5m;

			decimal result = Malt.CalculateSrm(grain, degrees, gallons);

			Assert.True(result >= 18.73m);
			Assert.True(result <= 18.74m);
		}

		[Fact]
		public void EbcCase ()
		{
			decimal grain = 10m;
			decimal degrees = 20m;
			decimal gallons = 5m;

			decimal result = Malt.CalculateEbc(grain, degrees, gallons);

			Assert.True(result >= 36.91m);
			Assert.True(result <= 36.92m);
		}
	}
}
