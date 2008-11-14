namespace BlogSharp.Core.Structure
{
	public interface IFriendlyUrlGenerator
	{
		string GenerateUrl(string format, params string[] args);
	}
}