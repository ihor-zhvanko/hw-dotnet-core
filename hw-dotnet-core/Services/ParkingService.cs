using System;
using System.Threading.Tasks;
using ParkingSimulator.Entities;

namespace hwdotnetcore.Services
{
	public interface IParkingService
	{
		Task<int> GetFreeSpaces();
		Task<int> GetNotFreeSpaces();
		Task<double> GetIncome();
	}

	public class ParkingService : IParkingService
	{
		private Parking _parking;

		public ParkingService(Parking parking)
		{
			_parking = parking;
		}

		public async Task<int> GetFreeSpaces()
		{
			return await Task.Run(() => _parking.FreeSpace);
		}

		public async Task<double> GetIncome()
		{
			return await Task.Run(() => _parking.Balance);
		}

		public async Task<int> GetNotFreeSpaces()
		{
			return await Task.Run(() => _parking.Cars.Count);
		}
	}
}
