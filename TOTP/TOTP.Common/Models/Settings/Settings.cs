namespace TOTP.Common.Models.Settings
{
	public class Settings : ISettings
	{
		public Settings(int timeStep, int tolerance, int digitLength)
		{
			this.TimeStep = timeStep;
			this.Tolerance = tolerance;
			this.DigitLength = digitLength;
		}

		public int TimeStep { get; }
		public int Tolerance { get; }
		public int DigitLength { get; }
	}
}
