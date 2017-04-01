using BeerMath;
using System;
using Xunit;

namespace Tests
{
	public class AttenuationTest
	{

		[Fact]
		public void ApparentCase ()
		{
			Gravity OG = new Gravity(56m);
			Gravity FG = new Gravity(10m);

			decimal result = Attenuation.CalculateApparent(OG, FG);

			Assert.True(result >= 82.14m);
			Assert.True(result <= 82.15m);
		}

		[Fact]
		public void RealCase ()
		{
			Gravity OG = new Gravity(56m);
			Gravity FG = new Gravity(10m);

			decimal result = Attenuation.CalculateReal(OG, FG);

			Assert.True(result >= 66.53m);
			Assert.True(result <= 66.54m);
		}
	}
}
