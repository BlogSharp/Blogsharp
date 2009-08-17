namespace BlogSharp.Core.Helpers
{
	using System;
	using System.Linq.Expressions;

	public static class Guard
	{
		public static void NotNull(object item,string propName)
		{
			if(item==null)
				throw new ArgumentNullException(propName);
		}
		public static void NotNull(Expression<Func<object>> item)
		{
			string propName = ((MemberExpression) item.Body).Member.Name;
			NotNull(item.Compile()(), propName);
		}
		public static void NotNullOrEmpty(Expression<Func<string>> item)
		{
			string propName=((MemberExpression) item.Body).Member.Name;
			NotNullOrEmpty(item.Compile()(),propName);
		}
		public static void NotNullOrEmpty(string item,string name)
		{
			if (string.IsNullOrEmpty(item))
				throw new ArgumentNullException(name);
		}
	}
}
