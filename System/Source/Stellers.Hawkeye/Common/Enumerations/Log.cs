using System;
using System.Collections.Generic;
using System.Text;

namespace Stellers.Hawkeye.Common.Enumerations
{
	public struct Log
	{
		/// <summary>
		/// 
		/// </summary>
		public enum Source
		{
			/// <summary>
			/// 
			/// </summary>
			None = 0,

			/// <summary>
			/// For all messages from the Tenant micro service
			/// </summary>
			Tenant = 1,

			/// <summary>
			/// For all messages from the Gateway micro service
			/// </summary>
			Gateway = 2,

			/// <summary>
			/// For all messages from the User micro service
			/// </summary>
			User = 4,

			/// <summary>
			/// For all source
			/// </summary>
			All = ~0
		}

		/// <summary>
		/// 
		/// </summary>
		public enum Category
		{
			/// <summary>
			/// The general category
			/// </summary>
			General,

			/// <summary>
			/// The data access category (SQL commands are logged here)
			/// </summary>
			DataAccess,

			/// <summary>
			/// The authentication category
			/// </summary>
			Authentication,

			/// <summary>
			/// The authorization category
			/// </summary>
			Authorization,

			/// <summary>
			/// The Business category
			/// </summary>
			Business,

			/// <summary>
			/// The Transport category
			/// </summary>
			Transport
		}

		/// <summary>
		/// 
		/// </summary>
		[Flags]
		public enum Severity
		{
			/// <summary>
			/// 
			/// </summary>
			None = 0,

			/// <summary>
			/// 
			/// </summary>
			Verbose = 1,

			/// <summary>
			/// 
			/// </summary>
			Debug = 2,

			/// <summary>
			/// 
			/// </summary>
			Information = 4,

			/// <summary>
			/// 
			/// </summary>
			Warning = 8,

			/// <summary>
			/// 
			/// </summary>
			Error = 16,

			/// <summary>
			/// 
			/// </summary>
			Fatal = 32,

			/// <summary>
			/// 
			/// </summary>
			All = ~0
		}
	}
}
