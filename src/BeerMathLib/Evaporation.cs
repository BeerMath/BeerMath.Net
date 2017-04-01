using System;

namespace BeerMath
{

	public class Evaporation
	{
		public const decimal EvaporationRate = 0.1m;

		/// <summary>
		/// Amount of wort lost to evaporation, using a standard rate
		/// </summary>
		/// <param name="WortGallons">
		/// A <see cref="System.Decimal"/>
		/// </param>
		/// <param name="BoiltimeMinutes">
		/// A <see cref="System.Decimal"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/>
		/// </returns>
		public static decimal CalculateLoss (decimal WortGallons, decimal BoiltimeMinutes)
		{
			return CalculateLoss(WortGallons, BoiltimeMinutes, EvaporationRate);
		}

		/// <summary>
		/// Amount of wort lost to evaporation, using a custom rate
		/// </summary>
		/// <param name="WortGallons">
		/// A <see cref="System.Decimal"/>
		/// </param>
		/// <param name="BoiltimeMinutes">
		/// A <see cref="System.Decimal"/>
		/// </param>
		/// <param name="Rate">
		/// A <see cref="System.Decimal"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/>
		/// </returns>
		public static decimal CalculateLoss (decimal WortGallons, decimal BoiltimeMinutes, decimal Rate)
		{
			//Evaporation Loss = (Preboil Volume * ((Evaporation Rate / 60) x Total Boil Time) /100)
			return WortGallons * ((Rate / 60) * BoiltimeMinutes);
		}

		/// <summary>
		/// Calculates rate of evaporation for a system
		/// </summary>
		/// <param name="StartVolume">
		/// A <see cref="System.Decimal"/> which represents the quantity of liquid prior to the boil
		/// </param>
		/// <param name="EndVolume">
		/// A <see cref="System.Decimal"/> which represents the quantity of liquid after the boil
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/>
		/// </returns>
		public static decimal CalculateRate (decimal StartVolume, decimal EndVolume)
		{
			return (StartVolume / EndVolume) / StartVolume;
		}
	}
}
