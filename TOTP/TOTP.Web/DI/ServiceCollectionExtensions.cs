using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOTP.Web.Converters;
using TOTP.Web.ViewModelBuilders;

namespace TOTP.Web.DI
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddSettings(
			this IServiceCollection serviceCollection,
			IConfiguration configuration)
		{
			var settings = new ConfigurationToSettingsConverter().Convert(configuration);
			serviceCollection.AddSingleton(settings);

			return serviceCollection;
		}

		public static IServiceCollection AddViewModelBuilders(
			this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<OTPResultViewModelBuilder>();

			return serviceCollection;
		}
	}
}
