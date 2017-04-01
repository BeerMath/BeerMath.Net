using BeerMath;
using System;
using Xunit;

namespace Tests
{
	public class AlcoholTest
	{
		[Fact]
		public void AbvCase ()
		{
			Gravity OG = new Gravity(56m);
			Gravity FG = new Gravity(10m);

			decimal result = Alcohol.CalculateAbv(OG, FG);

			Assert.True(result >= 5.98m);
			Assert.True(result <= 5.99m);
		}

		[Fact]
		public void AbwCase ()
		{
			Gravity OG = new Gravity(56m);
			Gravity FG = new Gravity(10m);

			decimal result = Alcohol.CalculateAbw(OG, FG);

			Assert.True(result >= 4.67m);
			Assert.True(result <= 4.68m);
		}

		[Fact]
		public void CalorieTest()
		{
			Gravity originalGravity = new Gravity(70m);
			Gravity finalGravity = new Gravity(15m);

			decimal result = Alcohol.CalculateCalories(originalGravity, finalGravity);

			Assert.True(result <= 228m);
			Assert.True(result >= 227.5m);
		}
	}
}
