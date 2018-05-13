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
	public class TransactionController : Controller
	{
		private ITransactionService _transactionService;

		public TransactionController(ITransactionService transactionService)
		{
			_transactionService = transactionService;
		}

		[HttpGet]
		public async Task<IList<Transaction>> Get()
		{
			return await _transactionService.GetAll();
		}

		[HttpGet("last")]
		public async Task<IList<Transaction>> Get(int? carId)
		{
			return await _transactionService.GetForLastMinute(carId);
		}

		[HttpPut("balance/topup")]
		public async Task Put(int carId, [FromBody] int balance)
		{
			await _transactionService.TopUpBalance(carId, balance);
		}
	}
}
