using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerMath.Deprecated
{
	/// <summary>
	/// Helper class for dealing with common malt calculations
	/// </summary>
	[Obsolete]
    public sealed class Malt
	{
		/// <summary>
		///  Caculates color in MCU (Malt Color Units)
		/// </summary>
		/// <param name="GrainLbs">
		/// A <see cref="System.Decimal"/> representing pounds of grain
		/// </param>
		/// <param name="DegreesLovibond">
		/// A <see cref="System.Decimal"/> representing degrees Lovibond of the grain
		/// </param>
		/// <param name="VolumeGallons">
		/// A <see cref="System.Decimal"/> representing the volume of wort made with this grain charge
		/// </param>
		/// <returns>
		/// A <see cref="BeerColor"/>
		/// </returns>
		[Obsolete]
        public static BeerColor CalculateMcu(decimal GrainLbs, decimal DegreesLovibond, decimal VolumeGallons)
        {
            return new BeerColor((GrainLbs * DegreesLovibond) / VolumeGallons, BeerColorType.Mcu);
        }

		/// <summary>
		///  Calculates color using SRM (Standard Reference Method)
		/// </summary>
		/// <param name="GrainLbs">
		/// A <see cref="System.Decimal"/> representing pounds of grain
		/// </param>
		/// <param name="DegreesLovibond">
		/// A <see cref="System.Decimal"/> representing degrees Lovibond of the grain
		/// </param>
		/// <param name="VolumeGallons">
		/// A <see cref="System.Decimal"/> representing the volume of wort made with this grain charge
		/// </param>
		/// <returns>
		/// A <see cref="BeerColor"/>
		/// </returns>
		[Obsolete]
	    public static BeerColor CalculateSrm(decimal GrainLbs, decimal DegreesLovibond, decimal VolumeGallons)
        {
			BeerColor Mcu = new BeerColor((GrainLbs * DegreesLovibond) / VolumeGallons, BeerColorType.Mcu);
			return new BeerColor(Mcu.Srm, BeerColorType.Srm);
        }

		/// <summary>
		///  Calculates color using EBC (European Brewing Convention)
		/// </summary>
		/// <param name="GrainLbs">
		/// A <see cref="System.Decimal"/> representing pounds of grain
		/// </param>
		/// <param name="DegreesLovibond">
		/// A <see cref="System.Decimal"/> representing degrees Lovibond of the grain
		/// </param>
		/// <param name="VolumeGallons">
		/// A <see cref="System.Decimal"/> representing the volume of wort made with this grain charge
		/// </param>
		/// <returns>
		/// A <see cref="BeerColor"/>
		/// </returns>
		[Obsolete]
		public static BeerColor CalculateEbc(decimal GrainLbs, decimal DegreesLovibond, decimal VolumeGallons)
		{
			BeerColor Mcu = new BeerColor((GrainLbs * DegreesLovibond) / VolumeGallons, BeerColorType.Mcu);
			return new BeerColor(Mcu.Ebc, BeerColorType.Ebc);
		}

	}
}
