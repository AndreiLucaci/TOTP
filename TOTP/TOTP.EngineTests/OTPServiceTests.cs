using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TOTP.Common.Converters;
using TOTP.Common.Models.Settings;
using TOTP.Engine.Providers.SecretGenerator;
using TOTP.Engine.Services.OTP;

namespace TOTP.EngineTests
{
	[TestClass]
	public class OTPServiceTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CTOR_NullSettings_ThrowsArgumentNullException()
		{
			// arrange
			var sut = new OTPService(null, null, null);

			// act
			sut.GenerateOTP(null);

			// assert
			Assert.Fail();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CTOR_NullHotpToByteConverter_ThrowsArgumentNullException()
		{
			// arrange
			var sut = new OTPService(Mock.Of<ISettings>(), null, null);

			// act
			sut.GenerateOTP(null);

			// assert
			Assert.Fail();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CTOR_NullSecretGeneratorProvider_ThrowsArgumentNullException()
		{
			// arrange
			var sut = new OTPService(Mock.Of<ISettings>(),
				Mock.Of<IOneWayConverter<long, byte[]>>(), null);

			// act
			sut.GenerateOTP(null);

			// assert
			Assert.Fail();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GenerateOTP_NullUserId_ThrowsArgumentException()
		{
			// arrange
			var sut = new OTPService(Mock.Of<ISettings>(),
				Mock.Of<IOneWayConverter<long, byte[]>>(),
				Mock.Of<ISecretGeneratorProvider>());

			// act
			sut.GenerateOTP(null);

			// assert
			Assert.Fail();
		}

		[TestMethod]
		public void GenerateOTP_SecretGenerator_SecretIsGeneratedUsingUserId()
		{
			// arrange
			var secretGeneratorMock = new Mock<ISecretGeneratorProvider>();
			var userId = "some user id";
			var userIdBase64 = "c29tZSB1c2VyIGlk";
			secretGeneratorMock.Setup(x => x.GenerateSecret(userId)).Returns(userIdBase64);
			var sut = new OTPService(this.MockSettings().Object,
				Mock.Of<IOneWayConverter<long, byte[]>>(), secretGeneratorMock.Object);

			// act
			sut.GenerateOTP(userId);

			// assert
			secretGeneratorMock.Verify(x => x.GenerateSecret(userId), Times.Once);
		}	
		
		[TestMethod]
		public void GenerateOTP_Settings_MakesUserOfTimeStep()
		{
			// arrange
			var secretGeneratorMock = new Mock<ISecretGeneratorProvider>();
			var userId = "some user id";
			var userIdBase64 = "c29tZSB1c2VyIGlk";
			var settingsMock = this.MockSettings();
			secretGeneratorMock.Setup(x => x.GenerateSecret(userId)).Returns(userIdBase64);
			var sut = new OTPService(settingsMock.Object,
				Mock.Of<IOneWayConverter<long, byte[]>>(), secretGeneratorMock.Object);

			// act
			sut.GenerateOTP(userId);

			// assert
			settingsMock.VerifyGet(x => x.TimeStep, Times.AtLeastOnce());
		}

		[TestMethod]
		public void GenerateOTP_HotpToByteConverter_CovnertsBytes()
		{
			// arrange
			var secretGeneratorMock = new Mock<ISecretGeneratorProvider>();
			var userId = "some user id";
			var userIdBase64 = "c29tZSB1c2VyIGlk";
			var settingsMock = this.MockSettings();
			var dateTime = new DateTime(2020, 1, 1, 0, 0, 1);
			var hotpByteConverter = new Mock<IOneWayConverter<long, byte[]>>();
			var hotpValue = 52594560L;
			secretGeneratorMock.Setup(x => x.GenerateSecret(userId)).Returns(userIdBase64);
			var sut = new OTPService(settingsMock.Object, hotpByteConverter.Object, secretGeneratorMock.Object);

			// act
			sut.GenerateOTP(userId, dateTime);

			// assert
			hotpByteConverter.Verify(x => x.Convert(hotpValue), Times.Once());
		}

		[TestMethod]
		public void GenerateOTP_ValidInput_GeneratesValidOTPResult()
		{
			// arrange
			var secretGeneratorMock = new Mock<ISecretGeneratorProvider>();
			var userId = "some user id";
			var userIdBase64 = "c29tZSB1c2VyIGlk";
			var settingsMock = this.MockSettings();
			var dateTime = new DateTime(2020, 1, 1, 0, 0, 1);
			var hotpByteConverter = new Mock<IOneWayConverter<long, byte[]>>();
			secretGeneratorMock.Setup(x => x.GenerateSecret(userId)).Returns(userIdBase64);
			var sut = new OTPService(settingsMock.Object, hotpByteConverter.Object, secretGeneratorMock.Object);

			// act
			var result = sut.GenerateOTP(userId, dateTime);

			// assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GenerateOTP_ValidInput_GeneratesCorrectOTPPassword()
		{
			// arrange
			var secretGeneratorMock = new Mock<ISecretGeneratorProvider>();
			var userId = "some user id";
			var userIdBase64 = "c29tZSB1c2VyIGlk";
			var settingsMock = this.MockSettings();
			var nowDateTime = new DateTime(2020, 1, 1, 0, 0, 1);
			var hotpByteConverter = new Mock<IOneWayConverter<long, byte[]>>();
			secretGeneratorMock.Setup(x => x.GenerateSecret(userId)).Returns(userIdBase64);
			var sut = new OTPService(settingsMock.Object, hotpByteConverter.Object, secretGeneratorMock.Object);
			var otpPassword = "767312";

			// act
			var result = sut.GenerateOTP(userId, nowDateTime);

			// assert
			Assert.IsNotNull(result);
			Assert.AreEqual(otpPassword, result.OTPPassword);
		}

		[TestMethod]
		public void GenerateOTP_ValidInput_OTPResultIsNotExpired()
		{
			// arrange
			var secretGeneratorMock = new Mock<ISecretGeneratorProvider>();
			var userId = "some user id";
			var userIdBase64 = "c29tZSB1c2VyIGlk";
			var settingsMock = this.MockSettings();
			var nowDateTime = new DateTime(2020, 1, 1, 0, 0, 1);
			var hotpByteConverter = new Mock<IOneWayConverter<long, byte[]>>();
			secretGeneratorMock.Setup(x => x.GenerateSecret(userId)).Returns(userIdBase64);
			var sut = new OTPService(settingsMock.Object, hotpByteConverter.Object, secretGeneratorMock.Object);

			// act
			var result = sut.GenerateOTP(userId, nowDateTime);

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(nowDateTime <= result.ValidUntil);
			Assert.IsTrue(nowDateTime >= result.ValidFrom);
		}

		[TestMethod]
		public void GenerateOTP_ValidInput_OTPResultHasCorrectSecondsLeft()
		{
			// arrange
			var secretGeneratorMock = new Mock<ISecretGeneratorProvider>();
			var userId = "some user id";
			var userIdBase64 = "c29tZSB1c2VyIGlk";
			var settingsMock = this.MockSettings();
			var nowDateTime = new DateTime(2020, 1, 1, 0, 0, 1);
			var hotpByteConverter = new Mock<IOneWayConverter<long, byte[]>>();
			secretGeneratorMock.Setup(x => x.GenerateSecret(userId)).Returns(userIdBase64);
			var sut = new OTPService(settingsMock.Object, hotpByteConverter.Object, secretGeneratorMock.Object);
			var expectedSecondsLeft = 14;

			// act
			var result = sut.GenerateOTP(userId, nowDateTime);

			// assert
			Assert.IsNotNull(result);
			Assert.AreEqual(expectedSecondsLeft, result.ValidSecondsLeft);
		}

		// TODO: extend with other unit-tests

		private Mock<ISettings> MockSettings()
		{
			var mock = new Mock<ISettings>();
			mock.SetupGet(x => x.TimeStep).Returns(30);
			mock.SetupGet(x => x.DigitLength).Returns(6);
			mock.SetupGet(x => x.Tolerance).Returns(2);

			return mock;
		}
	}
}
