using System;

namespace BeerMath
{
	/// <summary>
	///   The various beer color calculations known to BeerMath
	/// </summary>
	public enum BeerColorType { Mcu, Srm, Ebc }

	/// <summary>
	/// Represents the color of a wort or beer
	/// </summary>
	public sealed class BeerColor
	{
		private Decimal _Value;
		private BeerColorType _BCT;

		// some constants we'll use to convert between the colors
		private const double SrmFactor = 1.4922;
		private const double SrmExponent = 0.6859;
		private const decimal EcuFactor = 1.97m;

		/// <summary>
		/// Returns a beer color of 0 MCU
		/// </summary>
		public BeerColor ()
		{
			_Value = 0;
			_BCT = BeerColorType.Mcu;
		}
		/// <summary>
		/// Returns a beer color object with a particular color in a particular system
		/// </summary>
		/// <param name="Color">
		/// A <see cref="System.Decimal"/> magnitude of color
		/// </param>
		/// <param name="bct">
		/// A <see cref="BeerColorType"/>
		/// </param>
		public BeerColor (decimal Color, BeerColorType bct)
		{
			_Value = Color;
			_BCT = bct;
		}

		/// <summary>
		/// This beer color in SRM, converted if necessary
		/// </summary>
		public decimal Srm
		{
			get { return _GetSrm(); }
		}
		/// <summary>
		/// This beer color in MCU, converted if necessary
		/// </summary>
		public decimal Mcu
		{
			get { return _GetMcu(); }
		}
		/// <summary>
		/// This beer color in EBC, converted if necessary
		/// </summary>
		public decimal Ebc
		{
			get { return _GetEbc(); }
		}

		/// <summary>
		/// Implicit conversion to decimal
		/// </summary>
		/// <param name="b">
		/// A <see cref="BeerColor"/>
		/// </param>
		/// <returns>
		/// A <see cref="Decimal"/>
		/// </returns>
		public static implicit operator Decimal(BeerColor b)
		{
			return b._Value;
		}

		public override string ToString ()
		{
			return string.Format("{0} {1}", _Value, _BCT);
		}

		#region Conversions between color formulations
		private decimal _GetEbc()
		{
			if(BeerColorType.Ebc == _BCT)
				return _Value;
			if(BeerColorType.Srm == _BCT || BeerColorType.Mcu == _BCT)
				return EcuFactor * _GetSrm();

			throw new NotSupportedException();
		}

		private decimal _GetSrm()
		{
			if(BeerColorType.Ebc == _BCT)
				return _Value / EcuFactor;
			if(BeerColorType.Srm == _BCT)
				return _Value;
			if(BeerColorType.Mcu == _BCT)
				return (decimal)(SrmFactor * System.Math.Pow((double)_Value, SrmExponent));

			throw new NotSupportedException();
		}

		private decimal _GetMcu()
		{
			if(BeerColorType.Ebc == _BCT || BeerColorType.Srm == _BCT)
			{
				/*
				 * more math than I've done since college!
				 *
				 * Algebraic conversion on MCU->SRM conversion yields:
				 *   MCU = root((SRM/SrmFactor), SrmExponent)
				 * Applying logarithm rule yields:
				 *   log(MCU) = log(SRM/SrmFactor) / SrmExponent
				 * Finally, to get MCU back from log(MCU), raise the correct base to the other side:
				 *   MCU = base ^ (log(SRM/SrmFactor) / SrmExponent)
				*/
				return (decimal)Math.Pow(Math.E, (Math.Log((double)_GetSrm() / SrmFactor) / SrmExponent));
			}
			if(BeerColorType.Mcu == _BCT)
				return _Value;

			throw new NotSupportedException();
		}
		#endregion
	}
}
