using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ParkingSimulator.Workers;

namespace hw_dotnet_core
{
	public class Program
	{
		public static void Main(string[] args)
		{
			StartWorkers();
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();

		public static void StartWorkers()
		{
			var parkingWorker = new ParkingWorker();
			parkingWorker.Start();

			// Do I need this ?
			// var transactionWorker = new TransactionWorker();
			// transactionWorker.Start();
		}
	}
}
