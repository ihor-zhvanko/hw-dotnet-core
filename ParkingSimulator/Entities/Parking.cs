using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using ParkingSimulator.Common;
using ParkingSimulator.Exceptions;

namespace ParkingSimulator.Entities
{
	public sealed class Parking
	{
		private static readonly Lazy<Parking> _lazyInstance = new Lazy<Parking>(() => new Parking(), true);

		public static Parking Instance => _lazyInstance.Value;

		private IReadOnlyDictionary<CarType, double> _carTypePrice;
		private int _maxParkingSpace;
		private double _fine;

		private Parking()
		{
			_carTypePrice = Settings.Dictionary;
			_maxParkingSpace = Settings.ParkingSpace;//Exceptions ?
			_fine = Settings.Fine; //Exceptions ?

			Cars = new List<Car>(_maxParkingSpace);
			Transactions = new List<Transaction>();
		}

		// Intialize?

		public IList<Car> Cars { get; }

		public IList<Transaction> Transactions { get; }

		public IList<Transaction> LastMinuteTransactions
		{
			get
			{
				var oneMinute = new TimeSpan(0, 1, 0);
				return Transactions
					.Where(x => x.Timestamp >= DateTime.Now.Subtract(oneMinute))
					.ToList();
			}
		}

		public double Balance { get; private set; }

		public double LastMinuteIncome => LastMinuteTransactions.Sum(x => x.Debited);

		public int FreeSpace => _maxParkingSpace - Cars.Count;

		public int MaxCapacity => _maxParkingSpace;

		public bool CarExists(int id)
		{
			var car = Cars.FirstOrDefault(x => x.Id == id);
			return car != null;
		}

		public void AddCar(Car newCar)
		{
			if (newCar == null)
			{
				throw new ArgumentNullException();
			}

			var currentSpace = Cars.Count;
			if (currentSpace == _maxParkingSpace)
			{
				throw new ParkingExceededMaxSpaceException();
			}

			if (CarExists(newCar.Id))
			{
				throw new ArgumentException("Car already exists");
			}

			lock (Cars)
			{
				Cars.Add(newCar);
			}
		}

		public bool RemoveCar(int id)
		{
			lock (Cars)
			{
				var car = Cars.FirstOrDefault(x => x.Id == id);
				if (car == null)
				{
					throw new ParkingUnknownCarException(id);
				}

				if (car.Balance < 0)
				{
					return false;
				}

				Cars.Remove(car);
				return true;
			}
		}

		private void PushTransaction(int carId, double debited)
		{
			lock (Transactions)
			{
				var newTransaction = new Transaction
				{
					Id = Guid.NewGuid(),
					Timestamp = DateTime.Now,
					CarId = carId,
					Debited = debited
				};

				Transactions.Add(newTransaction);
			}
		}

		public void TopUpBalance(int carId, double fee)
		{
			if (fee <= 0)
			{
				throw new ArgumentException("Fee should be greater than 0");
			}

			lock (Cars)
			{
				var car = Cars.FirstOrDefault(x => x.Id == carId);
				if (car == null)
				{
					throw new ParkingUnknownCarException(carId);
				}

				car.Balance += fee;
			}
		}

		public void DebitParkingCost()
		{
			lock (Cars)
			{
				foreach (var car in Cars)
				{
					var price = _carTypePrice[car.Type];
					if (car.Balance < price)
					{
						price = _fine * price;
					}

					car.Balance -= price;
					Balance += price;

					PushTransaction(car.Id, price);
				}

			}
		}
	}
}
