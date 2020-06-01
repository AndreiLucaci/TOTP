using System;
using Castle.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTP.Engine.Providers.SecretGenerator.Implementations;

namespace TOTP.EngineTests
{
	[TestClass]
	public class HMAC256UserIdSecretGeneratorProviderTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void HMAC256UserIdSecretGeneratorProvider_NullInput_ThrowsArgumentException()
		{
			// arrange
			var sut = new HMAC256UserIdSecretGeneratorProvider();

			// act
			sut.GenerateSecret(null);

			// assert
			Assert.Fail();
		}

		[TestMethod]
		public void HMAC256UserIdSecretGeneratorProvider_ValidInput_GeneratesCorrectSecret()
		{
			// arrange
			var sut = new HMAC256UserIdSecretGeneratorProvider();
			var userId = "some user id";
			var expectedSecret = "utijaNtvWNwKcQb6UiZyrxXfFyRli9Xj8QNMeXbEy0w=";

			// act
			var result = sut.GenerateSecret(userId);

			// assert
			Assert.IsNotNull(result);
			Assert.AreEqual(expectedSecret, result);
		}

		[TestMethod]
		public void HMAC256UserIdSecretGeneratorProvider_ValidInput_OutputIsBase64Compliant()
		{
			// arrange
			var sut = new HMAC256UserIdSecretGeneratorProvider();
			var userId = "some other id";

			// act
			var result = sut.GenerateSecret(userId);

			// assert
			Assert.IsNotNull(result);
			try
			{
				Convert.FromBase64String(result);
			}
			catch (Exception ex)
			{
				Assert.Fail("Expected no exception!", ex);
			}
		}
	}
}
