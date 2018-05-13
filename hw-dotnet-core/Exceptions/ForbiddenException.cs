using System;
namespace hwdotnetcore.Exceptions
{
	public class ForbiddenException : Exception
	{
		public ForbiddenException()
			: base("forbidden")
		{
		}

		public ForbiddenException(string msg) : base(msg) { }
	}
}
