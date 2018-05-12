using System;
using System.IO;
using System.Linq;
using ParkingSimulator.Common;
using ParkingSimulator.Entities;

namespace ParkingSimulator.Workers
{

	public class TransactionWorker : BaseWorker, IWorker, IDisposable
	{
		private Parking _parking;
		private string _fileName;

		public TransactionWorker()
		{
			Timeout = Settings.DumpTimeout;
			_parking = ParkingSimulator.Instance;
			_fileName = Settings.TransactionFilename;
		}

		protected override void Main()
		{
			var transactions = _parking.LastMinuteTransactions
				.Select(x => $"[{x.Timestamp}] |{x.Id}| From car with id = {x.CarId} was debited {x.Debited}");
			File.WriteAllLines(_fileName, transactions);
		}
	}
}
