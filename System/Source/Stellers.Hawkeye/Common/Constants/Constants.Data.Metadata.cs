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
		public struct Schemas
		{
			/// <summary>
			/// 
			/// </summary>
			public struct Dbo
			{
				public const string Name = "dbo";
			}

			/// <summary>
			/// 
			/// </summary>
			public struct ReferenceData
			{
				public const string Name = "ReferenceData";

				/// <summary>
				/// 
				/// </summary>
				public struct Tables
				{
					public const string ReferenceTable = "ReferenceTable";

					public const string ReferenceTableValues = "ReferenceTable_Values";
				}
			}

			/// <summary>
			/// 
			/// </summary>
			public struct Authorization
			{
				public const string Name = "Authorization";

				/// <summary>
				/// 
				/// </summary>
				public struct Tables
				{
					public const string RoleDefinitions = "Role_Definitions";

					public const string RoleAssignments = "Role_Assignments";
				}
			}

			/// <summary>
			/// 
			/// </summary>
			public struct User
			{
				public const string Name = "User";

				/// <summary>
				/// 
				/// </summary>
				public struct Tables
				{
					public const string Users = "Users";
				}
			}

			/// <summary>
			/// 
			/// </summary>
			public struct Platform
			{
				public const string Name = "Platform";

				/// <summary>
				/// 
				/// </summary>
				public struct Tables
				{
					public const string PlatformConfiguration = "Platform_Configurations";
				}
			}

			/// <summary>
			/// 
			/// </summary>
			public struct Tenant
			{
				public const string Name = "Tenant";

				/// <summary>
				/// 
				/// </summary>
				public struct Tables
				{
					public const string Tenants = "Tenants";
					
					public const string Configurations = "Configurations";
				}
			}

			/// <summary>
			/// 
			/// </summary>
			public struct LicenseGroup
			{
				public const string Name = "LicenseGroup";

				/// <summary>
				/// 
				/// </summary>
				public struct Tables
				{
					public const string LicenseGroups = "LicenseGroups";

					public const string Configurations = "Configurations";
				}
			}
		}
	}
}