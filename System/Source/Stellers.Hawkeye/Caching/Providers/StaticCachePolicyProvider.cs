using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Stellers.Hawkeye.Caching.Interfaces;
using Stellers.Hawkeye.Caching.Policy;
using Stellers.Hawkeye.Common.Constants;
using Stellers.Hawkeye.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stellers.Hawkeye.Caching.Providers
{
	/// <summary>
	/// A simple cache provider that uses hard coded policies.
	/// </summary>
	/// <seealso cref="Interfaces.ICachePolicyProvider" />
	public class StaticCachePolicyProvider : ICachePolicyProvider
	{
		/// <summary>
		/// 
		/// </summary>
		private readonly Dictionary<string, CachePolicy> _configs;

		/// <summary>
		/// 
		/// </summary>
		readonly IMapper _mapper;

		/// <summary>
		/// 
		/// </summary>
		public StaticCachePolicyProvider(IMapper mapper)
		{
			_mapper = mapper;
			_configs = new Dictionary<string, CachePolicy>()
			{
				{ Constants.Caching.Policies.Default, new CachePolicy(DependencyConfiguration.Cache.ItemPriority.Low, new TimeSpan(0, 30, 0), null) },
				{ Constants.Caching.Policies.UserRolesDependencies, new CachePolicy(DependencyConfiguration.Cache.ItemPriority.NeverRemove,  new TimeSpan(7, 0, 0, 0), null) }
			};
		}

		/// <summary>
		/// Creates a new cache item policy based on the configuration specified by name.
		/// </summary>
		/// <param name="name">The cache policy name.</param>
		/// <returns>A new policy with correct dates relative to now</returns>
		/// <exception cref="System.InvalidOperationException">If a policy with that name is not configured</exception>
		public T GetPolicy<T>(string name)
		{
			CachePolicy policy;
			if (_configs.TryGetValue(name, out policy))
			{
				return _mapper.Map<T>(policy);
			}

			throw new InvalidOperationException($"Unknown cache policy '{name}'");
		}
	}
}
