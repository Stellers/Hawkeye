using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Stellers.Hawkeye.Security.SecretsHasher
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SecretsHashProvider : PasswordHasher<Dummy>, ISecretsHashProvider
	{
		Dummy _dummy;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		public SecretsHashProvider(IOptions<PasswordHasherOptions> options = null) : base(options)
		{
			_dummy = new Dummy();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <param name="textToBeHashed"></param>
		/// <returns></returns>
		public string Hash(string textToBeHashed)
		{
			return base.HashPassword(_dummy, textToBeHashed);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <param name="hashedText"></param>
		/// <param name="textToVerified"></param>
		/// <returns></returns>
		public bool VerifyHash(string hashedText, string textToVerified)
		{
			return base.VerifyHashedPassword(_dummy, hashedText, textToVerified) == PasswordVerificationResult.Success;
		}
	}

	public class Dummy { }
}