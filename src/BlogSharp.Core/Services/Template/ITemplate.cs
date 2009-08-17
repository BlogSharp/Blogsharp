namespace BlogSharp.Core.Services.Template
{
	public interface ITemplate
	{
		ITemplateEngine Engine { get; }
		string GetContent();
	}
}