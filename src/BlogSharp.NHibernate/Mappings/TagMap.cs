using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.NHibernate.Mappings
{
	using Model;

	public class TagMap:EntityBaseMap<Tag>
	{
		public TagMap()
		{
			Map(tag => tag.FriendlyName)
				.Access.BackingField()
				.Column("FriendlyName")
				.Not.Nullable();
			Map(tag=>tag.Name)
				.Access.BackingField()
				.Column("FriendlyName")
				.Not.Nullable();
			HasManyToMany(tag => tag.Posts)
				.ParentKeyColumn("TagId")
				.ChildKeyColumn("ParentId")
				.AsBag()
				.Access.CamelCaseField();

		}
	}
}
