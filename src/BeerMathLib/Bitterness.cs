using System;

namespace BeerMath
{

	/// <summary>
	/// The various bitterness calculations known to BeerMath
	/// </summary>
	public enum BitternessType
	{
		Ibu,
		Hbu
	}

	/// <summary>
	/// Represents the bitterness of a wort or beer
	/// </summary>
	public sealed class Bitterness
	{

		private decimal _Value;
		private BitternessType _Type;

		/// <summary>
		/// Returns a bitterness of 0 IBU
		/// </summary>
		public Bitterness ()
		{
			_Value = 0;
			_Type = BitternessType.Ibu;
		}

		/// <summary>
		/// Creates a bitterness object with a particular value in a particular system
		/// </summary>
		/// <param name="Value">
		/// A <see cref="System.Decimal"/> magnitude of bitterness
		/// </param>
		/// <param name="Type">
		/// A <see cref="BitternessType"/>
		/// </param>
		public Bitterness (decimal Value, BitternessType Type)
		{
			_Value = Value;
			_Type = Type;
		}

		/// <summary>
		/// Gets the bitterness value in IBUs (International Bitterness Units)
		/// </summary>
		public decimal Value
		{
			get
			{
				return _Value;
			}
		}

		/// <summary>
		/// Gets the bitterness type.
		/// </summary>
		public BitternessType Type
		{
			get
			{
				return _Type;
			}
		}

		/// <summary>
		/// Implicit conversion to decimal
		/// </summary>
		/// <param name="b">
		/// A <see cref="Bitterness"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/>
		/// </returns>
		public static implicit operator decimal(Bitterness b)
		{
			return b._Value;
		}

		public override string ToString ()
		{
			return string.Format("{0} {1}", _Value, _Type);
		}

	}
}
