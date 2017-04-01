using System;

namespace BeerMath
{

	/// <summary>
	/// Alcohol by volume
	/// </summary>
	public sealed class Abv : AlcoholStrength
	{
		private decimal _Value;

		public Abv ()
		{
			_Value = 0;
		}

		public Abv(decimal Value)
		{
			_Value = Value;
		}

		public override decimal Value
		{
			get { return _Value; }
		}

		public override AlcoholStrengthType Type
		{
			get { return AlcoholStrengthType.Abv; }
		}

	}
}
