using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTP.Engine.Converters;

namespace TOTP.EngineTests
{
	[TestClass]
	public class HOTPValueLongToByteArrayConverterTests
	{
		[TestMethod]
		public void HOTPValueLongToByteArrayConverter_ValidInput_ConvertsToBytes()
		{
			// arrange
			var sut = new HOTPValueLongToByteArrayConverter();
			var inputLong = 12353417236273L;

			// act
			var result = sut.Convert(inputLong);

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Length > 0);
		}

		[TestMethod]
		public void HOTPValueLongToByteArrayConverter_ValidInput_ConvertsToCorectByteSequence()
		{
			// arrange
			var sut = new HOTPValueLongToByteArrayConverter();
			var inputLong = 12353417236273L;
			var expectedBytes = new byte[] {0x0, 0x0, 0xB, 0x3C, 0x41, 0xB, 0xCF, 0x31};

			// act
			var result = sut.Convert(inputLong);

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Length > 0);
			CollectionAssert.AreEqual(expectedBytes, result);
		}

		[TestMethod]
		public void HOTPValueLongToByteArrayConverter_ValidInput_ConvertsToBigEndianByteArray()
		{
			// arrange
			var sut = new HOTPValueLongToByteArrayConverter();
			var inputLong = 12353417236273L;
			var littleEndianBytes = new byte[] { 0x31, 0xCF, 0xB, 0x41, 0x3C, 0xB, 0x0, 0x0 };
			var expectedBigEndianBytes = new byte[] { 0x0, 0x0, 0xB, 0x3C, 0x41, 0xB, 0xCF, 0x31 };

			// act
			var result = sut.Convert(inputLong);

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Length > 0);
			CollectionAssert.AreNotEqual(littleEndianBytes, result);
			CollectionAssert.AreEqual(expectedBigEndianBytes, result);
		}
	}
}
