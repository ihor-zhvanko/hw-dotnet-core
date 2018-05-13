using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
		}
	}
}
