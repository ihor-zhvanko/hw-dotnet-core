using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hwdotnetcore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hwdotnetcore.Controllers
{
	[Route("api/[controller]")]
	public class ParkingController : Controller
	{
		private IParkingService _parkingService;

		public ParkingController(IParkingService parkingService)
		{
			_parkingService = parkingService;
		}

		[HttpGet("free")]
		public async Task<object> GetFree()
		{
			var free = await _parkingService.GetFreeSpaces();

			return new
			{
				free = free
			};
		}

		[HttpGet("notfree")]
		public async Task<object> GetNotFree()
		{
			var notfree = await _parkingService.GetNotFreeSpaces();

			return new
			{
				notfree = notfree
			};
		}

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
