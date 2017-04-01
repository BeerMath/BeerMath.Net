using System;

namespace BeerMath
{

	/// <summary>
	/// Alcohol by weight
	/// </summary>
	public sealed class Abw : AlcoholStrength
	{
		private decimal _Value;

		public Abw ()
		{
			_Value = 0;
		}

		public Abw(decimal Value)
		{
			_Value = Value;
		}

		public override decimal Value
		{
			get { return _Value; }
		}

		public override AlcoholStrengthType Type
		{
			get { return AlcoholStrengthType.Abw; }
		}

	}
}
