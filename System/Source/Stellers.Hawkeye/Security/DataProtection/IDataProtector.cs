using Stellers.Hawkeye.Common.Helpers;

namespace Stellers.Hawkeye.Security.DataProtection
{
	/// <summary>
	/// 
	/// </summary>
	public interface IDataProtector
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		void Protect<T>(T data) where T : IHasProtectedSettings;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		string Protect(string data);

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		void UnProtect<T>(T data) where T : IHasProtectedSettings;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		string UnProtect(string data);
	}
}