using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSimulator.Workers
{
	public interface IWorker : IDisposable
	{
		void Start();
		void Stop();
	}
}
