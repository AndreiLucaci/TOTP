using System;

namespace TOTP.Common.Guard
{
	public class Guard
	{
		public static void ArgumentNotNull(object argument, string argumentName)
		{
			if (argument == null)
			{
				throw new ArgumentNullException(argumentName, "The given argument is null");
			}
		}

		public static void ArgumentStringNotNullOrEmpty(string argument, string argumentName)
		{
			if (string.IsNullOrEmpty(argument))
			{
				throw new ArgumentException("The given argument is null", argumentName);
			}
		}
	}
}
