using Microsoft.Extensions.Configuration;
using TOTP.Common.Converters;
using TOTP.Common.Models.Settings;

namespace TOTP.Web.Converters
{
	public class ConfigurationToSettingsConverter : IOneWayConverter<IConfiguration, ISettings>
	{
		private const string Section = "OTPSettings";

		public ISettings Convert(IConfiguration input)
		{
			var timeStep = int.Parse(this.GetFromConfiguration(input, "TimeStep"));
			var tolerance = int.Parse(this.GetFromConfiguration(input, "Tolerance"));
			var digitLength = int.Parse(this.GetFromConfiguration(input, "DigitLength"));

			var settings = new Settings(timeStep, tolerance, digitLength);

			return settings;
		}

		private string GetFromConfiguration(IConfiguration configuration, string field)
		{
			var key = Format(field);

			return configuration[key];
		}

		private string Format(string field)
		{
			return $"{Section}:{field}";
		}
	}
}
