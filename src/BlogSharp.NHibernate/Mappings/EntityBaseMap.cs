using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.NHibernate.Mappings
{
	using FluentNHibernate.Mapping;
	using Model;

	public class EntityBaseMap<T>:ClassMap<T> where T:Entity
	{
		public EntityBaseMap()
		{
			Id(entity => entity.ID)
				.Column("Id")
				.Access.BackingField()
				.GeneratedBy.HiLo(1024.ToString());
			Version(entity => entity.Version)
				.Access.BackingField();
			DynamicUpdate();
			DynamicInsert();

		}
	}
}
