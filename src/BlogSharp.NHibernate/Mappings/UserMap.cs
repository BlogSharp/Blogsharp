namespace BlogSharp.NHibernate.Mappings
{
	using FluentNHibernate.Conventions.Inspections;
	using Model;

	public class UserMap:EntityBaseMap<User>
	{
		public UserMap()
		{
			HasManyToMany(user => user.Blogs)
				.ParentKeyColumn("UserId")
				.ChildKeyColumn("BlogId")
				.Access.CamelCaseField()
				.AsBag();
			Map(user => user.UserName)
				.Column("Username")
				.Not.Nullable();
			Map(user => user.Password)
				.Column("Password")
				.Not.Nullable()
				.Access.BackingField();

			Map(user => user.Email)
				.Column("Email")
				.Access.BackingField()
				.Not.Nullable();

			Map(user => user.BirthDate)
				.Access.BackingField()
				.Column("BirthDate")
				.Not.Nullable();

			Map(user => user.Biography)
				.Column("Biography")
				.Access.BackingField()
				.Nullable();


		}
	}
}
