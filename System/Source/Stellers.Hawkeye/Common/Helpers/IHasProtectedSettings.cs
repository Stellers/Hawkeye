using System;
using System.Collections.Generic;
using System.Text;

namespace Stellers.Hawkeye.Common.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public interface IHasProtectedSettings
	{

	}

	/// <summary>
	/// 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ProtectedAttribute : Attribute
	{
	}
}