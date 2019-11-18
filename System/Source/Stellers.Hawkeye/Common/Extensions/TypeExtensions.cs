using Newtonsoft.Json;
using Stellers.Hawkeye.Common.Enumerations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;

namespace Stellers.Hawkeye.Common.Extensions
{
	/// <summary>
	/// These are helper methods to aid in converting one type to another with the proper "TryParse"
	/// pattern to avoid throwing unnecessary exceptions.
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Gets the first claim of the specified type and attempts to convert the value to the
		/// specified type.
		/// </summary>
		/// <typeparam name="T">The expected type of the value of the claim.</typeparam>
		/// <param name="identity">The <paramref name="identity"/>.</param>
		/// <param name="claimType"><see cref="Type"/> of the claim.</param>
		/// <param name="defaultValue">
		/// The default value to return if the claim is missing or data type conversion could not be performed.
		/// </param>
		/// <returns>The claim.</returns>
		public static T GetClaim<T>(this ClaimsIdentity identity, string claimType, T defaultValue)
		{
			Claim claim;
			if (identity == null || (claim = identity.FindFirst(claimType)) == null)
			{
				return defaultValue;
			}

			return ((object)claim.Value).ParseOrDefault<T>(defaultValue);
		}

		/// <summary>
		/// Changes the type of <see langword="object"/> to <typeparamref name="T"/>. Will <see langword="throw"/>
		/// <see cref="NotSupportedException"/> if the conversion can not be made.
		/// </summary>
		/// <typeparam name="T">The desired type to change to.</typeparam>
		/// <param name="value">The <paramref name="value"/>.</param>
		/// <returns>A T.</returns>
		public static T ChangeType<T>(this object value)
		{
			if (value != null && value.GetType() == typeof(T))
			{
				return (T)value;
			}

			var tc = TypeDescriptor.GetConverter(typeof(T));
			return (T)tc.ConvertFrom(value);
		}		

		/// <summary>
		/// Maps an HTTP verb to a permission.
		/// </summary>
		/// <param name="httpVerb">The HTTP verb.</param>
		/// <returns>The permission or Permission.None if no match</returns>
		public static Authorization.Permission MapHttpVerbToPermission(this string httpVerb)
		{
			Authorization.Permission permission;
			if (httpVerb != null && HttpVerbMaps.TryGetValue(httpVerb, out permission))
			{
				return permission;
			}

			// HTTP method is not secured, no authz check
			return Authorization.Permission.None;
		}

		/// <summary>
		/// The authoritative source of mapping HTTP Verbs to API Permissions.
		/// </summary>
		/// <remarks>
		/// Case insensitive. 
		/// </remarks>
		private static readonly Dictionary<string, Authorization.Permission> HttpVerbMaps = new Dictionary<string, Authorization.Permission>(StringComparer.OrdinalIgnoreCase)
		{
			{Constants.Constants.HttpVerbs.Get, Authorization.Permission.Read},
			{Constants.Constants.HttpVerbs.Head, Authorization.Permission.Read},
			{Constants.Constants.HttpVerbs.Put, Authorization.Permission.Update},
			{Constants.Constants.HttpVerbs.Delete, Authorization.Permission.Delete},
			{Constants.Constants.HttpVerbs.Post, Authorization.	Permission.Create }
		};
	}
}
