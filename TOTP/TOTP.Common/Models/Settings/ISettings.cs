namespace TOTP.Common.Models.Settings
{
	public interface ISettings
	{
		int TimeStep { get; }
		int Tolerance { get; }
		int DigitLength { get; }
	}
}
