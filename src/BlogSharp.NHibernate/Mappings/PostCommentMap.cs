namespace BlogSharp.NHibernate.Mappings
{
	using FluentNHibernate.Mapping;
	using Model;

	public class PostCommentMap:SubclassMap<PostComment>
	{
		public PostCommentMap()
		{
			References(postComment => postComment.Parent)
				.Column("ParentId")
				.Not.Nullable()
				.ForeignKey("FK_PostComment_Post");
			HasMany(postComment => postComment.Comments)
				.AsBag()
				.Cascade.AllDeleteOrphan()
				.Access.CamelCaseField();
		}
	}
}
