namespace BlogSharp.NHibernate.Mappings
{
	using Model;

	public class PostMap:EntityBaseMap<Post>
	{
		public PostMap()
		{
			Map(post => post.Title)
				.Access.BackingField()
				.Column("Title")
				.Not.Nullable();
			Map(post => post.FriendlyTitle)
				.Access.BackingField()
				.Column("FriendlyTitle")
				.Not.Nullable();
			Map(post => post.Published)
				.Access.BackingField()
				.Column("IsPublished")
				.Default("1");
			References(post => post.Blog)
				.Not.Nullable()
				.Access.BackingField()
				.Column("BlogId")
				.ForeignKey("FK_Blog");
			References(post => post.Publisher)
				.Column("UserId")
				.Not.Nullable()
				.Access.BackingField()
				.ForeignKey("FK_Post_User");
			Map(post => post.DateCreated)
				.Access.BackingField()
				.Column("DateCreated")
				.Not.Nullable();
			Map(post => post.DatePublished)
				.Access.BackingField()
				.Column("DatePublished")
				.Not.Nullable();
			Map(post => post.Content)
				.Access.BackingField()
				.Column("Content")
				.Not.Nullable();
			HasMany(post => post.Comments)
				.Access.CamelCaseField()
				.Cascade.AllDeleteOrphan()
				.AsBag()
				.Inverse()
				.KeyColumn("PostId");
			HasManyToMany(tag => tag.Tags)
				.Access.CamelCaseField()
				.Table("PostTag")
				.Cascade.All()
				.ParentKeyColumn("PostId")
				.ChildKeyColumn("TagId");
		}
	}
}
