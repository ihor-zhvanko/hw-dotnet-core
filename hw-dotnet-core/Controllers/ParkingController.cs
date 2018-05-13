using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hwdotnetcore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hwdotnetcore.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ParkingController : Controller
	{
		private IParkingService _parkingService;

		public ParkingController(IParkingService parkingService)
		{
			_parkingService = parkingService;
		}

		/// <summary>
		/// Get free spaces quantity
		/// </summary>
		/// <returns>{ "free": uint }</returns>
		[HttpGet("free")]
		public async Task<object> GetFree()
		{
			var free = await _parkingService.GetFreeSpaces();

			return new
			{
				free = free
			};
		}

		/// <summary>
		/// Get not free spaces quantity
		/// </summary>
		/// <returns>{ "notfree": uint }</returns>
		[HttpGet("notfree")]
		public async Task<object> GetNotFree()
		{
			var notfree = await _parkingService.GetNotFreeSpaces();

			return new
			{
				notfree = notfree
			};
		}

		/// <summary>
		/// Get income of parking from begining of times
		/// </summary>
		/// <returns>{ "income": double }</returns>
		[HttpGet("income")]
		public async Task<object> GetIncome()
		{
			var income = await _parkingService.GetIncome();

			return new
			{
				income = income
			};

		}
	}
}
