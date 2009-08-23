namespace BlogSharp.NHibernate.Mappings
{
	using FluentNHibernate.Mapping;
	using Model;

	public class BlogMap:EntityBaseMap<Blog>
	{
		public BlogMap()
		{
			//TODO: look how to implement BlogConfiguration
			Table("Blogs");

			References(blog => blog.Founder)
				.Column("FounderId")
				.Access.BackingField()
				.Not.Nullable();
			Map(blog => blog.Host)
				.Access.BackingField()
				.Column("Host")
				.Not.Nullable();
			Map(blog => blog.IsInitialized)
				.Access.BackingField()
				.Column("IsInitialized");
			Map(blog => blog.Name)
				.Access.BackingField()
				.Column("Name")
				.Not.Nullable();
			Map(blog => blog.Title)
				.Access.BackingField()
				.Not.Nullable();
			HasMany(blog => blog.Posts)
				.AsBag()
				.Cascade.AllDeleteOrphan()
				.Access.CamelCaseField()
				.Inverse()
				.ForeignKeyConstraintName("FK_Post_Blog")
				.OrderBy("PublishedDate");
			HasManyToMany(blog => blog.Writers)
				.Table("UserBlog")
				.AsSet()
				.Access.CamelCaseField()
				.Cascade.AllDeleteOrphan()
				.ParentKeyColumn("BlogId")
				.ChildKeyColumn("UserId");
		}
	}
}
