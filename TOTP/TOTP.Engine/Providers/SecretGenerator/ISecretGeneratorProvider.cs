namespace TOTP.Engine.Providers.SecretGenerator
{
	public interface ISecretGeneratorProvider
	{
		/// <summary>
		/// Generates a secret key to be used in the OTP 
		/// </summary>
		/// <param name="from"></param>
		/// <returns>string version of the key</returns>
		string GenerateSecret(string @from = null);
	}
}
