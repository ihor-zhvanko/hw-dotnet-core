using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSimulator.Exceptions
{
	public class ParkingUnknownCarException : Exception
	{
		public ParkingUnknownCarException(int carId) :
			base($"Unknow car with such id: {carId}")
		{ }
	}
}
