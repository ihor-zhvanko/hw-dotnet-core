using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hwdotnetcore.Services;
using ParkingSimulator.Entities;
using System.Net;

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


		/// <summary>
		/// Get all cars in parking
		/// </summary>
		[HttpGet]
		public async Task<IList<Car>> Get()
		{
			return await _carService.GetAll();
		}

		/// <summary>
		/// Get car by id
		/// </summary>
		/// <response code="404">Car with such id was not found</response>
		/// <response code="200">Success car return</response>  
		[HttpGet("{id}")]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<Car> Get(int id)
		{
			return await _carService.GetById(id);
		}

		/// <summary>
		/// Add new car
		/// </summary>
		/// <response code="200">Successfully added car</response>  
		[HttpPost]
		public async Task Post([FromBody]Car car)
		{
			await _carService.Add(car);
		}

		/// <summary>
		/// Delete car from parking
		/// </summary>
		/// <response code="200">Successfully deleted car</response>
		/// <response code="403">Unable to delete car. Details in responce</response>
		/// <response code="404">Car with such id was not found</response>
		[HttpDelete("{id}")]
		[ProducesResponseType((int)HttpStatusCode.Forbidden)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task Delete(int id)
		{
			await _carService.Remove(id);
		}
	}
}
