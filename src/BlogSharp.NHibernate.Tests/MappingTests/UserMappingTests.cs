using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.NHibernate.Tests.MappingTests
{
	using global::NHibernate;
	using Model;
	using NUnit.Framework;

	public class UserMappingTests:MappingsFixtureBase
	{

		[Test]
		public void Throws_exception_for_non_nullable_props()
		{
			var user = GetUserWith(delegate { });
			SaveShouldNotFail(user);
			user = GetUserWith(usr => usr.Email = null);
			SaveShouldFail(user);
			user = GetUserWith(usr => usr.Password = null);
			SaveShouldFail(user);
			user = GetUserWith(usr => usr.UserName = null);
			SaveShouldFail(user);
		}
		protected User GetUserWith(Action<User> userAction)
		{
			var user = GetUser();
			userAction(user);
			return user;
		}
		public User GetUser()
		{
			return new User
			       	{
			       		Email = "myemail@gmail.com",
			       		Password = "password",
			       		UserName = "username",
			       		Biography = "biography here",
			       		BirthDate = new DateTime(1988, 07, 28)

			       	};
		}

		protected void SaveShouldFail(User user)
		{
			Assert.Throws<PropertyValueException>(() => DoInNewSessionAndTransaction(session => session.Save(user)));
		}
		protected void SaveShouldNotFail(User user)
		{
			Assert.DoesNotThrow(() => DoInNewSessionAndTransaction(session => session.Save(user)));
		}


		[Test]
		public void Can_add_delete_user()
		{
			var user = GetUserWith(delegate { });
			
			var userGet = default(User);
			DoInNewSessionAndTransaction(session => session.Save(user));
			Assert.That(user.ID,Is.GreaterThan(0));

			DoInNewSessionAndTransaction(session=>userGet=session.Get<User>(user.ID));
			Assert.That(user.ID,Is.EqualTo(userGet.ID));
			Assert.That(user.Biography, Is.EqualTo(userGet.Biography));
			Assert.That(user.Email, Is.EqualTo(userGet.Email));
			Assert.That(user.BirthDate, Is.EqualTo(userGet.BirthDate));
			Assert.That(user.Password, Is.EqualTo(userGet.Password));
			Assert.That(user.UserName, Is.EqualTo(userGet.UserName));

			DoInNewSessionAndTransaction(session=>
			                             	{
			                             		var item = session.Get<User>(user.ID);
			                             		session.Delete(item);
			                             	});

			DoInNewSessionAndTransaction(session =>userGet = session.Get<User>(user.ID));
			Assert.That(userGet,Is.Null);
		}


	}
}
