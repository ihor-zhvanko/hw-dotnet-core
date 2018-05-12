using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ParkingSimulator.Entities;
using ParkingSimulator.Common;

namespace ParkingSimulator.Workers
{
	public sealed class ParkingWorker : BaseWorker, IWorker, IDisposable
	{
		private Parking _parking;

		public ParkingWorker()
		{
			Timeout = Settings.Timeout;
			_parking = Parking.Instance;
		}

		protected override void Main()
		{
			_parking.DebitParkingCost();
		}
	}
}
