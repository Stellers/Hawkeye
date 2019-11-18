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
		private static MethodInfo tolower = typeof(String).GetMethod("ToLower", Type.EmptyTypes);

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

			return ParseOrDefault((object)claim.Value, defaultValue);
		}

		/// <summary>
		/// Gets the value from the collection and if found, converts it to the desired type. If the
		/// item is not found of if the conversion fails, the <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <typeparam name="T">.</typeparam>
		/// <param name="hash">The <paramref name="hash"/>.</param>
		/// <param name="key">The <paramref name="key"/>.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>The value.</returns>
		public static T GetValue<T>(this IDictionary hash, string key, T defaultValue)
		{
			object val;
			if (hash == null || !hash.Contains(key) || (val = hash[key]) == null)
			{
				return defaultValue;
			}

			return ParseOrDefault(val, defaultValue);
		}

		/// <summary>
		/// Gets the value from the collection and if found, converts it to the desired type. If the
		/// item is not found of if the conversion fails, the <paramref name="defaultValue"/> is
		/// returned. This overload is to to disambiguate because Dictionary implements multiple
		/// interfaces we also have.
		/// </summary>
		/// <typeparam name="T">.</typeparam>
		/// <param name="hash">The <paramref name="hash"/> .</param>
		/// <param name="key">The <paramref name="key"/> .</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>The value.</returns>
		public static T GetValue<T>(this Dictionary<string, string> hash, string key, T defaultValue) => GetValue<string, string, T>(hash, key, defaultValue);

		/// <summary>
		/// Gets the value from the collection and if found, converts it to the desired type. If the
		/// item is not found of if the conversion fails, the <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of <paramref name="key"/> in dictionary.</typeparam>
		/// <typeparam name="TU"><see cref="Type"/> of value in dictionary.</typeparam>
		/// <typeparam name="TV"><see cref="Type"/> of desired return value.</typeparam>
		/// <param name="hash">The hash.</param>
		/// <param name="key">The key.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>The value.</returns>
		public static TV GetValue<T, TU, TV>(this IDictionary<T, TU> hash, T key, TV defaultValue)
		{
			TU val;
			if (hash == null || !hash.TryGetValue(key, out val))
			{
				return defaultValue;
			}

			return ParseOrDefault(val, defaultValue);
		}

		/// <summary>
		/// Adds key if not default/exists and value to the collection
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of <paramref name="key"/> in dictionary</typeparam>
		/// <typeparam name="TV"><see cref="Type"/> of <paramref name="value"/> in dictionary</typeparam>
		/// <param name="hash">The hash</param>
		/// <param name="key">key to be added to the hash</param>
		/// <param name="value">value to be added to the hash</param>
		/// <returns>returns true if successfully added to the <paramref name="hash"/> in dictonary. else false</returns>
		public static void AddIfExistsElseUpdate<T, TV>(this IDictionary<T, TV> hash, T key, TV value)
		{
			if (hash == null)
			{
				return;
			}

			if (!hash.TryGetValue(key, out value))
			{
				hash.Add(key, value);
				return;
			}

			hash[key] = value;
		}

		/// <summary>
		/// Adds key if not default/exists and value to the collection
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of <paramref name="key"/> in dictionary</typeparam>
		/// <typeparam name="TV"><see cref="Type"/> of <paramref name="value"/> in dictionary</typeparam>
		/// <param name="hash">The hash</param>
		/// <param name="key">key to be added to the hash</param>
		/// <param name="value">value to be added to the hash</param>
		/// <returns>returns true if successfully added to the <paramref name="hash"/> in dictonary. else false</returns>
		public static void AddIfExistsElseConcat<T>(this IDictionary<T, string> hash, T key, string value)
		{
			if (hash == null)
			{
				return;
			}

			string currentValue;
			if (!hash.TryGetValue(key, out currentValue))
			{
				hash.Add(key, value);
				return;
			}

			hash[key] = string.Concat(currentValue, ",", value);
		}

		/// <summary>
		/// Parses the <paramref name="value"/> into the desired type, T, or returns the default.
		/// </summary>
		/// <typeparam name="T">.</typeparam>
		/// <param name="value">The <paramref name="value"/>.</param>
		/// <param name="defaultValue">The default <paramref name="value"/>.</param>
		/// <returns>A T.</returns>
		public static T ParseOrDefault<T>(object value, T defaultValue)
		{
			var t = typeof(T);

			try
			{
				if (t.IsEnum || t == typeof(Guid) || t == typeof(TimeSpan))
				{
					return value == null ? defaultValue : ChangeType<T>(value);
				}

				if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					return ChangeType<T>(value);
				}

				return (T)Convert.ChangeType(value, t);
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// Converts the given <paramref name="value"/> to the desired type. If the conversion fails,
		/// the <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <typeparam name="T">.</typeparam>
		/// <param name="value">The <paramref name="value"/>.</param>
		/// <param name="defaultValue">The default <paramref name="value"/>.</param>
		/// <returns>A T.</returns>
		public static T ParseOrDefault<T>(this string value, T defaultValue) => ParseOrDefault((object)value, defaultValue);

		/// <summary>
		/// Changes the type of <see langword="object"/> to <typeparamref name="T"/>. Will <see langword="throw"/>
		/// <see cref="NotSupportedException"/> if the conversion can not be made.
		/// </summary>
		/// <typeparam name="T">The desired type to change to.</typeparam>
		/// <param name="value">The <paramref name="value"/>.</param>
		/// <returns>A T.</returns>
		private static T ChangeType<T>(object value)
		{
			if (value != null && value.GetType() == typeof(T))
			{
				return (T)value;
			}

			var tc = TypeDescriptor.GetConverter(typeof(T));
			return (T)tc.ConvertFrom(value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="T1"></typeparam>
		/// <param name="values"></param>
		/// <param name="propName"></param>
		/// <returns></returns>
		public static Expression<Func<T, bool>> WhereContains<T, T1>(this T1 values, string propName) where T1 : IEnumerable
		{
			return values.WhereContains<T, T1>(propName, true);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="T1"></typeparam>
		/// <param name="values"></param>
		/// <param name="propName"></param>
		/// <returns></returns>
		public static Expression<Func<T, bool>> WhereNotContains<T, T1>(this T1 values, string propName) where T1 : IEnumerable
		{
			return values.WhereContains<T, T1>(propName, false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="fieldName"></param>
		/// <param name="isAscending"></param>
		/// <returns></returns>
		public static IOrderedEnumerable<T> OrderByField<T>(this IEnumerable<T> collection, string fieldName, bool isAscending)
		{
			var property = typeof(T).GetProperty(fieldName);

			return isAscending ? collection.OrderBy(x => property.GetValue(x)) : collection.OrderByDescending(x => property.GetValue(x));
		}

		/// <summary> 
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="T1"></typeparam>
		/// <param name="values"></param>
		/// <param name="propName"></param>
		/// <param name="checkForEqual"></param>
		/// <returns></returns>
		private static Expression<Func<T, bool>> WhereContains<T, T1>(this T1 values, string propName, bool checkForEqual) where T1 : IEnumerable
		{
			var param = Expression.Parameter(typeof(T), "source");
			BinaryExpression expression = null;
			var isStringInput = typeof(T1).GenericTypeArguments[0] == typeof(string);

			foreach (var value in values)
			{
				var left = isStringInput ? (Expression)Expression.Call(Expression.PropertyOrField(param, propName), tolower) : Expression.PropertyOrField(param, propName);
				var right = isStringInput ? (Expression)Expression.Call(Expression.Constant(value), tolower) : Expression.Constant(value);

				var condition = checkForEqual ? Expression.Equal(left, right) : Expression.NotEqual(left, right);

				if (expression == null)
				{
					expression = condition;
					continue;
				}

				expression = checkForEqual ? Expression.OrElse(expression, condition) : Expression.And(expression, condition);
			}

			return Expression.Lambda<Func<T, bool>>(expression, param);
		}

		/// <summary>
		/// Break a list of items into chunks of a specific size
		/// </summary>
		public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
		{
			while (source.Any())
			{
				yield return source.Take(chunksize);
				source = source.Skip(chunksize);
			}
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
		/// An string extension method that converts an JSON string to a given object.
		/// </summary>
		/// <param name="jsonString">The JSON string.s</param>
		/// <returns>string as a caller given type</returns>
		public static T ToObject<T>(this string jsonString)
		{
			if (string.IsNullOrWhiteSpace(jsonString))
			{
				return default(T);
			}

			return JsonConvert.DeserializeObject<T>(jsonString);
		}

		/// <summary>
		/// An object extension method that converts an object to a JSON.
		/// </summary>
		/// <param name="obj">The object to act on.</param>
		/// <returns>object as a string.</returns>
		public static string ToJson(this object obj)
		{
			return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
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
