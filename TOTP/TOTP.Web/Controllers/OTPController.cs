using System;
using Microsoft.AspNetCore.Mvc;
using TOTP.Engine.Services.OTP;
using TOTP.Web.ViewModelBuilders;
using TOTP.Web.ViewModels;

namespace TOTP.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	// ReSharper disable InconsistentNaming
	public class OTPController : ControllerBase
	{
		private readonly IOTPService _otpService;
		private readonly OTPResultViewModelBuilder _viewModelBuilder;

		public OTPController(IOTPService otpService, OTPResultViewModelBuilder viewModelBuilder)
		{
			this._otpService = otpService;
			this._viewModelBuilder = viewModelBuilder;
		}

		[HttpGet]
		public OTPResultViewModel Get(string userId, DateTime? dateTime)
		{
			var utcDateTime = dateTime ?? DateTime.UtcNow;

			var otpResult = this._otpService.GenerateOTP(userId, utcDateTime);

			var viewModel = this._viewModelBuilder
				.FromOTPResult(otpResult)
				.Build();

			return viewModel;
		}
	}
}
