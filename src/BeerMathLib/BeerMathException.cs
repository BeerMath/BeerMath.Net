using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerMath
{
	/// <summary>
	/// Exception thrown when some kind of error happens inside the BeerMath library
	/// </summary>
    public sealed class BeerMathException : Exception
    {
		public BeerMathException() : base() { }
		public BeerMathException(string message) : base(message) { }
		public BeerMathException(string message, Exception innerException) : base(message, innerException) { }
		//public BeerMathException(System.Runtime.Serialization.SerializationInfo info,
		//                         System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
