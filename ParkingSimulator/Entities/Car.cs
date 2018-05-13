using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSimulator.Entities
{
	public enum CarType
	{
		Passenger,
		Truck,
		Bus,
		Motorcycle
	}

	public class Car
	{
		public int Id { get; set; }
		public double Balance { get; set; }
		public CarType Type { get; set; }
	}
}
