namespace Stellers.Hawkeye.Common.Enumerations
{
	public struct DependencyConfiguration
	{
		public struct Database
		{
			public enum ConnectionType
			{
				Read,

				ReadWrite
			}
		}

		public struct Bus
		{
			public enum ConnectionType
			{
				Read,

				Listen,

				List
			}
		}

		public struct Cache
		{
			public enum ItemPriority
			{
				Low = 0,
				Normal = 1,
				High = 2,
				NeverRemove = 3
			}
		}
	}
}