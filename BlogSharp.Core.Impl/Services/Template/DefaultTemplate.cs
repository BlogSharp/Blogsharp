namespace BlogSharp.Core.Impl.Services.Template
{
	using Core.Services.Template;

	public class DefaultTemplate : ITemplate
	{
		private readonly string content;
		private readonly ITemplateEngine engine;

		public DefaultTemplate(string content, ITemplateEngine engine)
		{
			this.content = content;
			this.engine = engine;
		}

		#region ITemplate Members

		public string GetContent()
		{
			return this.content;
		}


		public ITemplateEngine Engine
		{
			get { return this.engine; }
		}

		#endregion
	}
}