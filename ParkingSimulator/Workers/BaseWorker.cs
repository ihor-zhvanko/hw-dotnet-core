using ParkingSimulator.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingSimulator.Workers
{
	public abstract class BaseWorker : IWorker
	{
		private Thread _workerThread;
		private volatile bool _work;
		public int Timeout { get; protected set; }

		public BaseWorker()
		{
			Timeout = 1; //1 second. Default value
			_work = false;
		}

		public void Start()
		{
			_work = true;
			_workerThread = new Thread(() =>
			{
				while (_work)
				{

					Main();
					//this simple trick won't block main process when it wants to exit
					//await Task.Delay(_work ? Timeout * 1000 : 0);
					Thread.Sleep(_work ? Timeout * 1000 : 0);
				}
			});

			_workerThread.Start();
		}

		protected abstract void Main();

		public void Stop()
		{
			_work = false;
		}

		public void Dispose()
		{
			Stop();
		}
	}
}
