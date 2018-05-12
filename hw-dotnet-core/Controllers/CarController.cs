using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hwdotnetcore.Services;
using ParkingSimulator.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hwdotnetcore.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class CarController : Controller
	{
		private ICarService _carService;

		public CarController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet]
		public async Task<IList<Car>> Get()
		{
			return await _carService.GetAll();
		}

		[HttpGet("{id}")]
		public async Task<Car> Get(int id)
		{
			return await _carService.GetById(id);
		}

		[HttpPost]
		public async Task Post([FromBody]Car car)
		{
			await _carService.Add(car);
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _carService.Remove(id);
		}
	}
}
