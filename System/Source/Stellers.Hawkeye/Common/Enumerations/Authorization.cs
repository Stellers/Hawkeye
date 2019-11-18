using System;

namespace Stellers.Hawkeye.Common.Enumerations
{
	public struct Authorization
	{
		/// <summary>
		/// Securable/assignable permissions.
		/// Use as bitflag, e.g. Permission.Read|Permission.Update
		/// </summary>
		[Flags]
		public enum Permission
		{
			/// <summary>
			/// Refers to no permissions,
			/// as in: none granted, or none requested.
			/// </summary>
			/// <remarks>
			/// Also here to ensure that the value zero 
			/// is never used as a permission flag!
			/// </remarks>
			None = 0,

			/// <summary>
			/// Ability to create a resource
			/// </summary>
			Create = 1,

			/// <summary>
			/// Ability to read/view a resource
			/// </summary>
			Read = 2,

			/// <summary>
			/// Ability to update/write a resource
			/// </summary>
			Update = 4,

			/// <summary>
			/// Can delete a granted securable entity.
			/// Note that rights may actually be dynamically
			/// </summary>
			Delete = 8,

			/// <summary>
			/// 
			/// </summary>
			Contributor = Read | Update,

			/// <summary>
			/// Owner is able to really manage the lifecycle 
			/// of entities mapped to that user. 
			/// </summary>
			Admin = Create | Read | Update | Delete,

			/// <summary>
			/// All permissions are affected.
			/// </summary>
			All = ~0
		}
	}
}