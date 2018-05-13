using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingSimulator.Entities;

namespace hwdotnetcore.Services
{
	public interface ITransactionService
	{
		Task<IList<Transaction>> GetAll();
		Task<IList<Transaction>> GetForLastMinute(int? carId);
		Task TopUpBalance(int carId, int amount);
	}

	public class TransactionService : ITransactionService
	{
		private readonly Parking _parking;

		public TransactionService(Parking parking)
		{
			_parking = parking;
		}

		public async Task<IList<Transaction>> GetAll()
		{
			return await Task.Run(() => _parking.Transactions);
		}

		public async Task<IList<Transaction>> GetForLastMinute(int? carId)
		{
			IEnumerable<Transaction> transactions = _parking.LastMinuteTransactions;
			if (carId != null)
			{
				transactions = transactions.Where(x => x.CarId == carId);
			}

			return await Task.Run(() => transactions.ToList());
		}

		public async Task TopUpBalance(int carId, int amount)
		{
			await Task.Run(() => _parking.TopUpBalance(carId, amount));
		}
	}
}
