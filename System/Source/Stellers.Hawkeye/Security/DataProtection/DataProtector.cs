using System;
using System.Collections.Generic;
using System.Text;
using Stellers.Hawkeye.Common.Helpers;

namespace Stellers.Hawkeye.Security.DataProtection
{
	public class DataProtector : IDataProtector
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		public void Protect<T>(T data) where T : IHasProtectedSettings
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public string Protect(string data)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		public void UnProtect<T>(T data) where T : IHasProtectedSettings
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public string UnProtect(string data)
		{
			throw new NotImplementedException();
		}
	}
}