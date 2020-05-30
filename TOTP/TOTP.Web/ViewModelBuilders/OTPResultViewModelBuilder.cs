using System;
using TOTP.Common.Models.OTPResult;
using TOTP.Web.ViewModels;

namespace TOTP.Web.ViewModelBuilders
{
	// ReSharper disable InconsistentNaming
	public class OTPResultViewModelBuilder
	{
		private readonly OTPResultViewModel _viewModel;

		public OTPResultViewModelBuilder()
		{
			this._viewModel = new OTPResultViewModel();
		}

		public OTPResultViewModelBuilder WithValidFrom(DateTime validFrom)
		{
			this._viewModel.ValidFrom = validFrom;

			return this;
		}

		public OTPResultViewModelBuilder WithValidUntil(DateTime validUntil)
		{
			this._viewModel.ValidUntil = validUntil;

			return this;
		}

		public OTPResultViewModelBuilder WithOTPPassword(string OTPPassword)
		{
			this._viewModel.OTPPassword = OTPPassword;

			return this;
		}

		public OTPResultViewModelBuilder WithValidSecondsLeft(int secondsLeft)
		{
			this._viewModel.ValidSecondsLeft = secondsLeft;

			return this;
		}

		public OTPResultViewModelBuilder FromOTPResult(OTPResult otpResult)
		{
			this._viewModel.Successful = otpResult != null;

			if (otpResult != null)
				this.WithValidUntil(otpResult.ValidUntil)
					.WithOTPPassword(otpResult.OTPPassword)
					.WithValidFrom(otpResult.ValidFrom)
					.WithValidSecondsLeft(otpResult.ValidSecondsLeft);

			return this;
		}

		public OTPResultViewModel Build()
		{
			return this._viewModel;
		}
	}
}
