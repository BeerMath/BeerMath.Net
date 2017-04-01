using BeerMath;
using System;
using Xunit;

namespace Tests
{
	public class EvaporationTest
	{

		[Fact]
		public void NormalCase ()
		{
			decimal wort = 6m;
			decimal boil = 60m;

			decimal result = Evaporation.CalculateLoss(wort, boil);

			Assert.True(result >= 0.599m);
			Assert.True(result <= 0.61m);
		}

		[Fact]
		public void CustomCase ()
		{
			decimal wort = 6m;
			decimal boil = 60m;
			decimal rate = 0.2m;

			decimal result = Evaporation.CalculateLoss(wort, boil, rate);

			Assert.True(result >= 1.199m);
			Assert.True(result <= 1.21m);
		}

		[Fact]
		public void RateCase ()
		{
			decimal pre = 5m;
			decimal post = 4m;

			decimal result = Evaporation.CalculateRate(pre, post);

			Assert.True(result >= 0.249m);
			Assert.True(result <= 0.26m);
		}
	}
}
