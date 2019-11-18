using System;
using System.Collections.Generic;
using System.Text;

namespace Stellers.Hawkeye.Common.Constants
{
	public partial struct Constants
	{
		/// <summary>
		/// 
		/// </summary>
		public struct Caching
		{
			/// <summary>
			/// 
			/// </summary>
			public struct Keys
			{
				/// <summary>
				/// 
				/// </summary>
				public const string AssignedRoleForUser = "User_{0}_AssignedRoles";
			}

			/// <summary>
			/// 
			/// </summary>
			public struct Policies
			{
				/// <summary>
				/// The default cache policy (30 min, default priority)
				/// </summary>
				public const string Default = "Default";

				/// <summary>
				/// The user roles cache policy (7 days, non-removable)
				/// </summary>
				public const string UserRolesDependencies = "UserRoles";
			}
		}
	}
}
