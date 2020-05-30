using System;
using TOTP.Common.Models.OTPResult;

namespace TOTP.Engine.Services.OTP
{
	// ReSharper disable InconsistentNaming
	public interface IOTPService
	{
		OTPResult GenerateOTP(string userId, DateTime? utcDateTime = null);

		bool ValidateOTP(string userId, string otp);
	}
}
