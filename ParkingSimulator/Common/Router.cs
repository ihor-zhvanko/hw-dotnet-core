sing System;
using System.Collections.Generic;
using ParkingSimulator.UI;

namespace ParkingSimulator
{
	internal class Router
	{
		public static readonly string DEFAULT_MENU = "default";

		private static Lazy<Router> _lazyInstance = new Lazy<Router>(() => new Router(), true);

		public static Router Instance => _lazyInstance.Value;

		private Router() { }

		public IDictionary<string, IMenu> Routes { get; set; }

		private IMenu _current;

		public IMenu Current
		{
			get
			{
				if (_current != null)
				{
					return _current;
				}

				if (!Routes.ContainsKey(DEFAULT_MENU))
				{
					throw new ArgumentException("You should set default menu!");
				}

				return Routes[DEFAULT_MENU];
			}
			private set
			{
				_current = value;
			}
		}

		public void Switch(string route)
		{

			if (!Routes.ContainsKey(route))
			{
				throw new ArgumentException($"Can't find {route}");
			}

			Routes[route].OnShow();
			Current = Routes[route];
		}
	}
}
