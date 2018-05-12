using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSimulator.Exceptions
{
	public class ParkingExceededMaxSpaceException : Exception
	{
		public ParkingExceededMaxSpaceException() :
			base("Exceeded max space of parking")
		{ }
	}
}
