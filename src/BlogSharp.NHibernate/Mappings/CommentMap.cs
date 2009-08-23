namespace BlogSharp.NHibernate.Mappings
{
	using Model;

	public class CommentMap:EntityBaseMap<Comment>
	{
		public CommentMap()
		{
			//TODO: Perhaps we'd like to move those into 
			//Feedback Mapping and let trackbacks derive from this.
			Map(comment => comment.Name)
				.Access.BackingField()
				.Column("Name");
			Map(comment => comment.Text)
				.Access.BackingField()
				.Not.Nullable();
			Map(comment => comment.Date)
				.Column("Date")
				.Access.BackingField()
				.Not.Nullable();
			Map(comment => comment.Published)
				.Column("Published")
				.Access.BackingField();
			Map(comment => comment.Spam)
				.Column("Spam");



			Map(comment => comment.Email)
				.Column("Email")
				.Access.BackingField();
			Map(comment => comment.Web)
				.Column("Web")
				.Access.BackingField();
			References(comment => comment.User)
				.Column("UserId")
				.ForeignKey("FK_Comment_User");
			DiscriminateSubClassesOnColumn("CommentType");
		}

	}
}
