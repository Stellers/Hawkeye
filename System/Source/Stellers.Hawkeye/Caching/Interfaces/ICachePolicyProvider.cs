using Microsoft.Extensions.Caching.Memory;

namespace Stellers.Hawkeye.Caching.Interfaces
{
	/// <summary>
	/// Provides access to CachePolicies by configuration names.
	/// </summary>
	public interface ICachePolicyProvider
	{
		/// <summary>
		/// Gets the cache item policy based on the configured name
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		T GetPolicy<T>(string name);
	}
}