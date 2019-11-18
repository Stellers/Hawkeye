using System;
using System.Collections.Generic;
using System.Text;

namespace Stellers.Hawkeye.Configuration.ConfigurationManager
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="newValue"></param>
	public delegate void ConfigurationChangedHandler<T>(T newValue);

	public interface IConfigurationManager<T> where T : class, new()
	{
		T AppSettings { get; }

		/// <summary>
		/// 
		/// </summary>
		event ConfigurationChangedHandler<T> ConfigurationChanged;
	}
}