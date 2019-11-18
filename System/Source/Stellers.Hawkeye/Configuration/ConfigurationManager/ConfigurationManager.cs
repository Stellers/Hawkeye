using Microsoft.Extensions.Options;
using Stellers.Hawkeye.Configuration.Helpers;

namespace Stellers.Hawkeye.Configuration.ConfigurationManager
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ConfigurationManager<T> : IConfigurationManager<T> where T : class, new()
	{
		/// <summary>
		/// 
		/// </summary>
		IOptionsMonitor<T> _setting;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="setting"></param>
		public ConfigurationManager(IOptionsMonitor<T> setting)
		{
			_setting = setting;

			if (typeof(INotifyConfigurationChange).IsAssignableFrom(typeof(T)))
			{
				setting.OnChange(OnConfigurationUpdated);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public T AppSettings { get => _setting.CurrentValue; }

		/// <summary>
		/// 
		/// </summary>
		public event ConfigurationChangedHandler<T> ConfigurationChanged;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="configuration"></param>
		/// <param name="test"></param>
		private void OnConfigurationUpdated(T configuration, string test)
		{
			ConfigurationChangedHandler<T> configurationChangedHandler = ConfigurationChanged;
			configurationChangedHandler?.Invoke(configuration);
		}
	}
}