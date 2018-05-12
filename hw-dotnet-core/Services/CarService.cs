using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkingSimulator.Entities;

namespace hwdotnetcore.Services
{
	public interface ICarService
	{
		Task<IList<Car>> GetAll();

		Task<Car> GetById(int id);

		Task<bool> Remove(int id);

		Task Add(Car car);
	}

	public class CarService : ICarService
	{
		private Parking _parking;

		public CarService(Parking parking)
		{
			_parking = parking;
		}

		public async Task<IList<Car>> GetAll()
		{
			return await Task.Run(() => _parking.Cars);
		}

		public async Task<Car> GetById(int id)
		{
			var car = Task.Run(() => _parking.Cars.FirstOrDefault(x => x.Id == id));

			return await car;
		}

		public async Task<bool> Remove(int id)
		{
			return await Task.Run(() => _parking.RemoveCar(id));
		}

		public async Task Add(Car car)
		{
			var newId = 1;
			if (_parking.Cars.Count > 0)
			{
				newId = _parking.Cars.Max((x) => x.Id) + 1;
			}

			car.Id = newId;
			await Task.Run(() => _parking.AddCar(car));
		}
	}
}
