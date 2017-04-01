using BeerMath;
using System;
using Xunit;

namespace Tests
{
	public class GravityTest
	{
		[Fact]
		public void OriginalGravityTest()
		{
			decimal grainLbs = 9.3125m; // 9 lbs 5 oz
			decimal extractPPG = 37m;
			decimal extractEfficiency = 0.75m;
			decimal volume = 5m;

			Gravity result = Malt.CalculateOriginalGravity(grainLbs, extractPPG, extractEfficiency, volume);

			Assert.IsType<Gravity>(result);
			Assert.True(result.Points <= 52m);
			Assert.True(result.Points >= 51m);
		}

		[Fact]
		public void FinalGravityTest()
		{
			decimal grainLbs = 9.3125m; // 9 lbs 5 oz
			decimal extractPPG = 37m;
			decimal extractEfficiency = 0.75m;
			decimal volume = 5m;
			decimal apparentAttenuation = 0.79m;

			Gravity result = Malt.CalculateFinalGravity(grainLbs, extractPPG, extractEfficiency, volume, apparentAttenuation);

			Assert.IsType<Gravity>(result);
			Assert.True(result.Points <= 11m);
			Assert.True(result.Points >= 10m);
		}

		[Fact]
		public void ConvertPlatoToValueTest()
		{
			decimal plato = 10m;
			decimal result = Gravity.ConvertPlatoToValue(plato);
			Assert.True(result <= 1.041m);
			Assert.True(result >= 1.040m);
		}

		[Fact]
		public void ConvertPlatoToContributionValueTest()
		{
			decimal plato = 10m;
			decimal result = Gravity.ConvertPlatoToPoints(plato);
			Assert.True(result <= 40.1m);
			Assert.True(result >= 40m);
		}

		[Fact]
		public void RealExtractTest()
		{
			Gravity originalGravity = new Gravity(70m);
			Gravity finalGravity = new Gravity(15m);

			Gravity result = Malt.CalculateRealExtract(originalGravity, finalGravity);

			Assert.True(result.Plato <= 6.22m);
			Assert.True(result.Plato >= 6.21m);
		}
	}
}
