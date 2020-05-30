using System;
using System.Security.Cryptography;
using System.Text;

namespace TOTP.Engine.Providers.SecretGenerator.Implementations
{
	public class HMAC256UserIdSecretGeneratorProvider : ISecretGeneratorProvider
	{
		public string GenerateSecret(string from)
		{
			var stringBytes = Encoding.ASCII.GetBytes(from);
			using var hmac = new HMACSHA256(stringBytes);
			var hashBytes = hmac.ComputeHash(stringBytes);
			var hashString = Convert.ToBase64String(hashBytes);
			return hashString;
		}
	}
}
