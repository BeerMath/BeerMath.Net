using System;

namespace BeerMath
{
	/// <summary>
	/// Represents the alcohol percentage types BeerMath knows about
	/// </summary>
	public enum AlcoholStrengthType { Abv, Abw }

	/// <summary>
	/// Represents a measurement of alcohol strength of a wort
	/// </summary>
	public abstract class AlcoholStrength
	{
		abstract public decimal Value { get; }
		abstract public AlcoholStrengthType Type { get; }
		/// <summary>
		/// Convert an alcohol strength type to decimal
		/// </summary>
		/// <param name="g">
		/// A <see cref="AlcoholStrength"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/>
		/// </returns>
		public static implicit operator decimal(AlcoholStrength g)
		{
			return g.Value;
		}
		public override string ToString ()
		{
			return string.Format("{0} {1}", Value, Type);
		}
	}
}
