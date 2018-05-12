using System;
using System.Collections.Generic;
using ParkingSimulator.Entities;

namespace ParkingSimulator.Common
{
	public static class Settings
	{

		public static int Timeout => 3;
		public static int DumpTimeout => 12; // 1-minute
		public static string TransactionFilename => "transaction.log";
		public static IReadOnlyDictionary<CarType, double> Dictionary => new Dictionary<CarType, double>
		{
			[CarType.Truck] = 5,
			[CarType.Passenger] = 3,
			[CarType.Bus] = 2,
			[CarType.Motorcycle] = 1
		};
		public static int ParkingSpace => 3;
		public static double Fine => 1.3; // 30%
	}

}
