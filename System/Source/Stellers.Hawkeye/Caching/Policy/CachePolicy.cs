using System;
using Stellers.Hawkeye.Common.Enumerations;

namespace Stellers.Hawkeye.Caching.Policy
{
	public class CachePolicy
	{
		public DependencyConfiguration.Cache.ItemPriority Priority { get; set; }

		public TimeSpan? AbsoluteExpirationWindow { get; set; }

		public TimeSpan? SlidingExpirationWindow { get; set; }

		public CachePolicy(DependencyConfiguration.Cache.ItemPriority priority, TimeSpan? absoluteExpirationWindow, TimeSpan? slidingExpirationWindow)
		{
			Priority = priority;
			AbsoluteExpirationWindow = absoluteExpirationWindow;
			SlidingExpirationWindow = slidingExpirationWindow;
		}
	}
}
