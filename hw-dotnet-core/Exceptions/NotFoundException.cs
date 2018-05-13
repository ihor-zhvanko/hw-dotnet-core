﻿using System;
namespace hwdotnetcore.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException() : base("Resource not found")
		{
		}

		public NotFoundException(string msg) : base(msg) { }
	}
}
