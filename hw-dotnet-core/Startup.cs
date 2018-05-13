using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hwdotnetcore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ParkingSimulator.Entities;
using hwdotnetcore.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Routing;
using System.Reflection;
using System.IO;

namespace hw_dotnet_core
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(Parking.Instance);

			services.AddScoped<ICarService, CarService>();
			services.AddScoped<IParkingService, ParkingService>();
			services.AddScoped<ITransactionService, TransactionService>();

			services.AddMvc();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Title = "Parking simulator",
					Version = "v1",
					Contact = new Contact
					{
						Name = "Ihor Zhvanko",
						Email = "igzhva@gmail.com",
						Url = "https://ihor-zhvanko.github.io/homepage"
					},
					Description = "Simple project based on .NET Core Web API." +
								  "Server simulates Parking."
				});

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);

			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseErrorHandlingMiddleware();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parking simulator V1");
				c.RoutePrefix = string.Empty;

			});

			app.UseMvc();
		}
	}
}
