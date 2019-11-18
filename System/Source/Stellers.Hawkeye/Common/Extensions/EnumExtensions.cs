using System;
using System.ComponentModel.DataAnnotations;

namespace Stellers.Hawkeye.Common.Extensions
{
	/// <summary>
	/// Extension methods for enums.
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Retrieve the Name value of the <see cref="DisplayAttribute"/> on the <see langword="enum"/> 
		/// if exists, else it calls SpaceIt on the enum's name.
		/// </summary>
		/// <param name="en">The enumeration.</param>
		/// <returns>
		/// A string representing the friendly name of the <see langword="enum"/> value provided.
		/// </returns>
		public static string GetDescription(this Enum en)
		{
			var display = GetDisplayAttribute(en);

			return display != null ? display.Description : en.ToString();
		}

		/// <summary>
		/// Gets the display name.
		/// </summary>
		/// <param name="en">The enumeration.</param>
		/// <returns></returns>
		public static string GetDisplayName(this Enum en)
		{
			var display = GetDisplayAttribute(en);

			return display != null ? display.Name : en.ToString();
		}

		/// <summary>
		/// Gets the order.
		/// </summary>
		/// <param name="en">The enumeration.</param>
		/// <returns></returns>
		public static int GetOrder(this Enum en)
		{
			var display = GetDisplayAttribute(en);

			return display?.GetOrder() ?? en.GetHashCode();
		}

		/// <summary>
		/// Retrieve the Description value of the <see cref="DisplayAttribute"/> on the <see langword="enum"/> 
		/// if exists, else it calls SpaceIt on the enum's name.
		/// </summary>
		/// <param name="en">The enumeration.</param>
		/// <returns>
		/// A string representing the friendly name of the <see langword="enum"/> value provided.
		/// </returns>
		private static DisplayAttribute GetDisplayAttribute(Enum en)
		{
			var memInfo = en.GetType().GetMember(en.ToString());
			if (memInfo.Length == 0)
			{
				return null;
			}
			var attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
			if (attrs.Length > 0)
			{
				return (DisplayAttribute)attrs[0];
			}
			return null;
		}
	}
}
