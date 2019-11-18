using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Stellers.Hawkeye.Common.Extensions
{
	public static class CollectionExtensions
	{
		private static MethodInfo tolower = typeof(String).GetMethod("ToLower", Type.EmptyTypes);

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

			return val.ParseOrDefault(defaultValue);
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
			if (hash == null || !hash.TryGetValue(key, out TU val))
			{
				return defaultValue;
			}

			return val.ParseOrDefault(defaultValue);
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

			if (!hash.TryGetValue(key, out string currentValue))
			{
				hash.Add(key, value);
				return;
			}

			hash[key] = string.Concat(currentValue, ",", value);
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
	}
}
