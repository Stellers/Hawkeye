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
	}
}