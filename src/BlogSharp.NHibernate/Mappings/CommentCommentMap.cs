using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.NHibernate.Mappings
{
	using FluentNHibernate.Mapping;
	using Model;

	public class CommentCommentMap:SubclassMap<CommentComment>
	{
		public CommentCommentMap()
		{
			References(commentComment => commentComment.Parent)
				.Column("ParentId")
				.Not.Nullable()
				.ForeignKey("FK_Parent");
			HasMany(postComment => postComment.Comments)
				.AsBag()
				.Cascade.AllDeleteOrphan()
				.Access.CamelCaseField();
		}

	}
}
