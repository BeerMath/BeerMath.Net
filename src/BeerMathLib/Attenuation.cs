using System;

namespace BeerMath
{


	public class Attenuation
	{
		private const decimal RealFactorMagicNumber = 0.81m;
		/// <summary>
		/// Attenuation is a measure of how much of the sugar was fermented by the yeast.  Apparent attenuation is the unadjusted
		/// percent of sugars fermented by the yeast.  For beer brewing, apparent attenuation is much more commonly used than real
		/// attenuation.
		/// </summary>
		/// <param name="OriginalGravity">
		/// A <see cref="Gravity"/>
		/// </param>
		/// <param name="FinalGravity">
		/// A <see cref="Gravity"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/>
		/// </returns>
		public static decimal CalculateApparent(Gravity OriginalGravity, Gravity FinalGravity)
		{
			//Apparent Attenuation % = ((OG-1)-(FG-1)) / (OG-1) x 100
			return ((OriginalGravity.Value-1)-(FinalGravity.Value-1)) / (OriginalGravity.Value-1)*100;
		}

		/// <summary>
		/// The real attenuation is how much sugars were really fermented by the yeast.  Because alcohol is lighter in specific
		/// gravity than water, an adjustment must be made for the alcohol content when assessing the actual percentages of sugar
		/// fermented.  The real attenuation will always be a lower number than the apparent attenuation.
		/// </summary>
		/// <param name="OriginalGravity">
		/// A <see cref="Gravity"/>
		/// </param>
		/// <param name="FinalGravity">
		/// A <see cref="Gravity"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/>
		/// </returns>
		public static decimal CalculateReal(Gravity OriginalGravity, Gravity FinalGravity)
		{
			//Real Attenuation = Apparent Attenuation * 0.81
			return CalculateApparent(OriginalGravity, FinalGravity) * RealFactorMagicNumber;
		}
	}
}
