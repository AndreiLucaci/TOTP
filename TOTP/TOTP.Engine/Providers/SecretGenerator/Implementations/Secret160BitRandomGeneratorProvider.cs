namespace TOTP.Engine.Providers.SecretGenerator.Implementations
{
	public class Secret160BitRandomGeneratorProvider : BaseRandomSecretGeneratorProvider
	{
		private const int KeyLength = 160;

		public Secret160BitRandomGeneratorProvider() 
			: base(KeyLength)
		{
		}
	}
}
