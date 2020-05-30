using System;

namespace TOTP.Web.ViewModels
{
	// ReSharper disable InconsistentNaming
	public class OTPResultViewModel
	{
		public string OTPPassword { get; set; }

		public DateTime ValidFrom { get; set; }

		public DateTime ValidUntil { get; set; }

		public bool Successful { get; set; }
		
		public int ValidSecondsLeft { get; set; }

	}
}
