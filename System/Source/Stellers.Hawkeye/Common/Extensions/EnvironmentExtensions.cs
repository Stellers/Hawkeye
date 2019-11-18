using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using static Stellers.Hawkeye.Common.Constants.Constants;

namespace Stellers.Hawkeye.Common.Extensions
{
	public static class EnvironmentExtensions
	{
		public static bool IsTest(this IHostingEnvironment env)
		{
			return env.IsEnvironment(StandardEnvironment.Test);
		}
	}
}
