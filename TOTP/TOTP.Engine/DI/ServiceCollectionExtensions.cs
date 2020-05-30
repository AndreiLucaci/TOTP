using Microsoft.Extensions.DependencyInjection;
using TOTP.Common.Converters;
using TOTP.Engine.Converters;
using TOTP.Engine.Providers.SecretGenerator;
using TOTP.Engine.Providers.SecretGenerator.Implementations;
using TOTP.Engine.Services.OTP;

namespace TOTP.Engine.DI
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddEngineConverters(this IServiceCollection serviceCollection)
		{
			serviceCollection
				.AddSingleton<IOneWayConverter<long, byte[]>, HOTPValueLongToByteArrayConverter>();

			return serviceCollection;
		}

		public static IServiceCollection AddProviders(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<ISecretGeneratorProvider, HMAC256UserIdSecretGeneratorProvider>();

			return serviceCollection;
		}

		public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IOTPService, OTPService>();

			return serviceCollection;
		}
	}
}
