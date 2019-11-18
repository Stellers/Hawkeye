using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Stellers.Hawkeye.Common.Extensions
{
	public static class ObjectExtensions
	{
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
		/// Parses the <paramref name="value"/> into the desired type, T, or returns the default.
		/// </summary>
		/// <typeparam name="T">.</typeparam>
		/// <param name="value">The <paramref name="value"/>.</param>
		/// <param name="defaultValue">The default <paramref name="value"/>.</param>
		/// <returns>A T.</returns>
		public static T ParseOrDefault<T>(this object value, T defaultValue)
		{
			var t = typeof(T);

			try
			{
				if (t.IsEnum || t == typeof(Guid) || t == typeof(TimeSpan))
				{
					return value == null ? defaultValue : value.ChangeType<T>();
				}

				if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					return value.ChangeType<T>();
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
		public static T ParseOrDefault<T>(this string value, T defaultValue) => ((object)value).ParseOrDefault(defaultValue);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static byte[] ToByteArray(this object obj)
		{
			if (obj == null)
			{
				return null;
			}

			BinaryFormatter binaryformatter = new BinaryFormatter();
			using MemoryStream memoryStream = new MemoryStream();
			binaryformatter.Serialize(memoryStream, obj);

			return memoryStream.ToArray();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="arrBytes"></param>
		/// <returns></returns>
		public static object ToObject(this byte[] arrBytes)
		{
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(arrBytes, 0, arrBytes.Length);
			memoryStream.Seek(0, SeekOrigin.Begin);

			BinaryFormatter binaryformatter = new BinaryFormatter();

			return (object)binaryformatter.Deserialize(memoryStream);
		}
	}
}
