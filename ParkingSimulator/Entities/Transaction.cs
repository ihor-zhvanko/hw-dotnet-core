using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSimulator.Entities
{
	public class Transaction
	{
		public Guid Id { get; set; }
		public DateTime Timestamp { get; set; }
		public int CarId { get; set; }
		public double Debited { get; set; }
	}
}
