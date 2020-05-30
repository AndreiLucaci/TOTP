namespace TOTP.Models.Settings
{
	public class DefaultSettings
	{
		public int TimeStep { get; } = 30;
		public int Tolerance { get; } = 3;
		public int DigitLength { get; } = 6;
	}
}
