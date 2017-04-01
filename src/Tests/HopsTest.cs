using BeerMath;
using System;
using Xunit;

using System.Diagnostics;

namespace Tests
{
	public class HopsTest
	{

		[Fact]
		public void IbuCase ()
		{
			decimal alpha = 6.0m;
			decimal ozs = 1.0m;
			decimal minutes = 60m;

			Bitterness result = Hops.CalculateIbus(alpha, ozs, minutes);

			Assert.IsAssignableFrom<BitternessType>(result.Type);
			Assert.True(result.Type == BitternessType.Ibu);
			Assert.True(result.Value >= 24.82m);
			Assert.True(result.Value <= 24.83m);
		}

		[Fact]
		public void IbuTinsethCase ()
		{
			decimal alpha = 6.0m;
			decimal ozs = 1.0m;
			decimal minutes = 60m;
			Gravity gravity = new Gravity(50m);
			decimal gallons = 5m;

			Bitterness result = Hops.CalculateIbusTinseth(alpha, ozs, minutes, gravity, gallons);

			Assert.IsAssignableFrom<BitternessType>(result.Type);
			Assert.True(result.Type == BitternessType.Ibu);
			Assert.True(result.Value >= 20.73m);
			Assert.True(result.Value <= 20.74m);
		}

		[Fact]
		public void IbuRagerCase()
		{
			decimal alpha = 6.0m;
			decimal ozs = 1.0m;
			decimal minutes = 60m;
			Gravity gravity = new Gravity(50m);
			decimal gallons = 5m;

			Bitterness result = Hops.CalculateIbusRager(alpha, ozs, gallons, gravity, minutes);

			Assert.IsAssignableFrom<BitternessType>(result.Type);
			Assert.True(result.Type == BitternessType.Ibu);
			Assert.True(result.Value >= 27.59m);
			Assert.True(result.Value <= 27.60m);
		}

		[Fact]
		public void IbuGaretzCase()
		{
			decimal alpha = 5.5m;
			decimal ozs = 1.0m;
			decimal minutes = 60m;
			Gravity gravity = new Gravity(50m);
			decimal finalVolume = 5m;
			decimal boilVolume = 6.0m;
			decimal desiredIBU = 20m;
			decimal elevation = 550m;

			Bitterness result = Hops.CalculateIbusGaretz(alpha, ozs, finalVolume, boilVolume, gravity, minutes, desiredIBU, elevation);

			Assert.IsAssignableFrom<BitternessType>(result.Type);
			Assert.True(result.Type == BitternessType.Ibu);
			Assert.True(result.Value <= 15.9m);
			Assert.True(result.Value >= 15.8m);
		}

		[Fact]
		public void BeerBalanceTest()
		{
			decimal result = Hops.CalculateBalanceRatio(new Gravity(10m), new Gravity(40m), new Bitterness(40m, BitternessType.Ibu));

			Assert.True(result <= 2.09m);
			Assert.True(result >= 2.07m);
		}

		[Fact]
		public void HbuTest()
		{
			decimal alpha = 6.0m;
			decimal hopsOz = 1.0m;
			Bitterness result = Hops.CalculateHbus(alpha, hopsOz);

			Assert.IsAssignableFrom<BitternessType>(result.Type);
			Assert.True(result.Type == BitternessType.Hbu);
			Assert.True(result.Value == 6.0m);
		}
	}
}
