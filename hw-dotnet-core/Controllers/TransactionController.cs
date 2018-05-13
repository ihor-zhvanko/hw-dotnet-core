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
	public class TransactionController : Controller
	{
		private ITransactionService _transactionService;

		public TransactionController(ITransactionService transactionService)
		{
			_transactionService = transactionService;
		}

		/// <summary>
		/// Get all transactions from begining of times
		/// </summary>
		[HttpGet]
		public async Task<IList<Transaction>> Get()
		{
			return await _transactionService.GetAll();
		}

		/// <summary>
		/// Get last minute transactions
		/// </summary>
		[HttpGet("last")]
		public async Task<IList<Transaction>> Get(int? carId)
		{
			return await _transactionService.GetForLastMinute(carId);
		}

		/// <summary>
		/// Top up a balance of car
		/// </summary>
		/// <response code="200">Successfully top up balance</response>
		/// <response code="400">Amount of money should be greater than 0</response>
		/// <response code="404">Car with such id was not found</response>
		[HttpPut("balance/topup")]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task Put(int carId, [FromBody] double amount)
		{
			await _transactionService.TopUpBalance(carId, amount);
		}
	}
}
