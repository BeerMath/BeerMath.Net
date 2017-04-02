using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerMath
{
	/// <summary>
	/// Exception thrown when some kind of error happens inside the BeerMath library
	/// </summary>
    public class BeerMathException : Exception
    {
		public BeerMathException() : base() { }
		public BeerMathException(string message) : base(message) { }
		public BeerMathException(string message, Exception innerException) : base(message, innerException) { }
    }

	/// <summary>
	/// When a calculation is known to be inaccurate, throw an exception
	/// instead of giving a bad value.
	/// </summary>
	public sealed class InaccurateResultException : BeerMathException
	{
		public InaccurateResultException(string message) : base(message) { }
	}
}
