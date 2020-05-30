using Microsoft.Extensions.DependencyInjection;
using TOTP.Engine.DI;

namespace TOTP.Engine
{
	public class ModuleInitialization
	{
		public static IServiceCollection InitializeEngine(IServiceCollection serviceCollection)
		{
			var bootstrapper = new Bootstrapper(serviceCollection);

			var updatedServiceCollection = bootstrapper.Initialize();

			return updatedServiceCollection;
		}
	}
}
