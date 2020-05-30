using System;
using System.Security.Cryptography;

namespace TOTP.Engine.Providers.SecretGenerator.Implementations
{
	public abstract class BaseRandomSecretGeneratorProvider : ISecretGeneratorProvider
	{
		private readonly int _keyLength;

		protected BaseRandomSecretGeneratorProvider(int keyLength)
		{
			this._keyLength = keyLength;
		}

		/// <summary>
		/// Generates a random string key based on a length
		/// </summary>
		/// <param name="length">input length of the resulting key</param>
		/// <returns>The generated string</returns>
		protected virtual string GenerateRandomKey(int length)
		{
			var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
			var randomBytes = new byte[length];
			rngCryptoServiceProvider.GetBytes(randomBytes);
			return Convert.ToBase64String(randomBytes);
		}

		public virtual string GenerateSecret(string @from = null)
		{
			return this.GenerateRandomKey(this._keyLength);
		}
	}
}
