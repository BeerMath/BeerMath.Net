using System;

namespace BeerMath
{
	/// <summary>
	/// Represents the gravity
	/// </summary>
	public sealed class Gravity
	{
		private decimal _Points;
		private decimal _Value;
		private decimal _Plato;

		#region Singleton for Zero Value.

		private Gravity()
		{
			_Value = 0m;
			_Points = 0m;
			_Plato = GetPlato();
		}

		private static Gravity _Zero = new Gravity();
		/// <summary>
		/// A static Gravity value of 0.
		/// </summary>
		public static Gravity Zero
		{
			get
			{
				return _Zero;
			}
		}

		#endregion

		/// <summary>
		/// A constructor for a new Gravity.
		/// </summary>
		/// <param name="Points">
		/// A <see cref="System.Decimal"/> representing the points value (40 instead of 1.040) of the Gravity.
		/// </param>
		public Gravity(decimal Points)
		{
			_Points = Points;
			_Value = (_Points / 1000m) + 1;
			_Plato = GetPlato();
		}

		private decimal GetPlato()
		{
			return (-463.37m) + (668.72m * _Value) - (205.35m * (_Value * _Value));
		}

		/// <summary>
		/// Helper method for converting Plato to a Points value.
		/// </summary>
		/// <param name="Plato">
		/// A <see cref="System.Decimal"/> representing the Plato value.
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/> representing the Points.
		/// </returns>
		public static decimal ConvertPlatoToPoints(decimal Plato)
		{
			return (ConvertPlatoToValue(Plato) - 1) * 1000;
		}

		/// <summary>
		/// Helper method for converting Plato to a <see cref="Gravity"/> Value.
		/// </summary>
		/// <param name="Plato">
		/// A <see cref="System.Decimal"/> representing the Plato value.
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/> representing the Value.
		/// </returns>
		public static decimal ConvertPlatoToValue(decimal Plato)
		{
			return (Plato / (258.6m - ((Plato / 258.5m) * 227.1m))) + 1;
		}

		/// <summary>
		/// Gets the Points of the Gravity as a whole number. Like 40.
		/// </summary>
		public decimal Points
		{
			get
			{
				return _Points;
			}
		}

		/// <summary>
		/// Gets the Value of the Gravity. Like 1.040.
		/// </summary>
		public decimal Value
		{
			get
			{
				return _Value;
			}
		}

		/// <summary>
		/// Gets the Plato of the Gravity.
		/// Calculated during construction by this method http://hbd.org/ensmingr/ (Equation 1).
		/// </summary>
		public decimal Plato
		{
			get
			{
				return _Plato;
			}
		}

		/// <summary>
		/// Implicit conversion to decimal based on the Points.
		/// </summary>
		/// <param name="gravity">
		/// A <see cref="Gravity"/>.
		/// </param>
		/// <returns>
		/// A <see cref="System.Decimal"/>
		/// </returns>
		public static implicit operator decimal(Gravity gravity)
		{
			return gravity._Points;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", _Points, _Value);
		}
	}
}
