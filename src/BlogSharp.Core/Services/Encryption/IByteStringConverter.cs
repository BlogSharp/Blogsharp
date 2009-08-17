namespace BlogSharp.Core.Services.Encryption
{
	public interface IByteStringConverter
	{
		string ConvertByteToString(byte[] b);
		byte[] ConvertStringToByte(string s);
	}
}