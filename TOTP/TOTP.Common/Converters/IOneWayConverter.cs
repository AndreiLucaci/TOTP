namespace TOTP.Common.Converters
{
	/// <summary>
	/// Converts from one type to another
	/// Even though this interface is generic, it's implementations might defer from original intent!
	/// </summary>
	/// <typeparam name="TIn">contravariant input parameter</typeparam>
	/// <typeparam name="TOut">covariant output parameter</typeparam>
	public interface IOneWayConverter<in TIn, out TOut>
	{
		TOut Convert(TIn input);
	}
}
