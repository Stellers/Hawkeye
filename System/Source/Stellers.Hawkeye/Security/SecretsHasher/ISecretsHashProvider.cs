using System;
using System.Collections.Generic;
using System.Text;

namespace Stellers.Hawkeye.Security.SecretsHasher
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ISecretsHashProvider
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="textToBeHashed"></param>
		/// <returns></returns>
		string Hash(string textToBeHashed);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hashedText"></param>
		/// <param name="textToVerified"></param>
		/// <returns></returns>
		bool VerifyHash(string hashedText, string textToVerified);
	}
}