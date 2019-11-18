using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stellers.Hawkeye.Caching.Interfaces
{
	/// <summary>
	/// Interface used to abstract the caching tier.
	/// </summary>
	public interface ICacheProvider
	{
		/// <summary>
		/// Gets the specified cache key from cache if present, otherwise calls the seedFunction to get
		/// the data to cache and adds it using the cachePolicy specified.
		/// </summary>
		/// <typeparam name="T">The type of the data in cache.</typeparam>
		/// <param name="cacheKey">The cache key.</param>
		/// <param name="cachePolicy">The cache policy.</param>
		/// <param name="seedFunction">The synchronous seed function.</param>
		/// <returns></returns>
		T GetOrSet<T>(string cacheKey, string cachePolicy, Func<T> seedFunction);

		/// <summary>
		/// Gets the specified cache key from cache if present, otherwise calls the seedFunction to get
		/// the data to cache and adds it using the cachePolicy specified.
		/// </summary>
		/// <typeparam name="T">The type of the data in cache.</typeparam>
		/// <param name="cacheKey">The cache key.</param>
		/// <param name="cachePolicy">The cache policy.</param>
		/// <param name="seedFunction">The asynchronous seed function.</param>
		/// <returns></returns>
		Task<T> GetOrSetAsync<T>(string cacheKey, string cachePolicy, Func<Task<T>> seedFunction);

		/// <summary>
		/// Sets the data for a specific key
		/// </summary>
		/// <param name="cacheKey">Cache Key</param>
		/// <param name="cachePolicy">Cache policy for this key</param>
		/// <param name="data">data to be cached</param>
		/// <returns></returns>
		void Set(string cacheKey, string cachePolicy, object data);

		/// <summary>
		/// Gets the specified cache key from cache
		/// </summary>
		/// <typeparam name="T">The type of the data in cache.</typeparam>
		/// <param name="cacheKey">The cache key.</param>
		/// <returns></returns>
		T Get<T>(string cacheKey);

		/// <summary>
		/// Gets the specified cache key from cache
		/// </summary>
		/// <typeparam name="T">The type of the data in cache.</typeparam>
		/// <param name="cacheKey">The cache key.</param>
		/// <returns></returns>
		Task<T> GetAsync<T>(string cacheKey);

		/// <summary>
		/// Gets the specified cache key from cache
		/// </summary>
		/// <param name="partialKey">The cache key.</param>
		/// <returns></returns>
		IEnumerable<string> GetKeysByPartialName(string partialKey);

		/// <summary>
		/// Invalidates the cahe objects for the perticuler user id.
		/// </summary>
		/// <param name="key">cache Key.</param>
		/// <returns></returns>
		Task InvalidateCacheAsync(string key);

		/// <summary>
		/// Invalidate all the cache objects by partial key.
		/// </summary>
		/// <param name="partialKey"></param>
		void InvalidateCacheByPartialKey(string partialKey);

		/// <summary>
		/// Invalidates the cahe objects for the perticuler user id.
		/// </summary>
		/// <param name="keys">cache Key.</param>
		/// <returns></returns>
		void InvalidateCacheAsync(string[] keys);

		/// <summary>
		/// Invalidate all the cache objects by partial keys.
		/// </summary>
		/// <param name="partialKeys"></param>
		void InvalidateCacheByPartialKey(string[] partialKeys);
	}
}
