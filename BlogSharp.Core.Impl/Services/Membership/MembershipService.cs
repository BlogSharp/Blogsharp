using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.DataAccess;
using BlogSharp.Core.Impl.Services.Template;
using BlogSharp.Core.Services.Encryption;
using BlogSharp.Core.Services.Mail;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Core.Services.Template;
using BlogSharp.Model;
using NVelocity.Context;
using BlogSharp.Core.Event.MembershipEvents;

namespace BlogSharp.Core.Impl.Services.Membership
{
	public class MembershipService:IMembershipService
	{
		public MembershipService(IEncryptionService encryptionService)
		{
			this.encryptionService = encryptionService;
		}

		private readonly IEncryptionService encryptionService;
		#region IMembershipService Members

		public IAuthor CreateNewUser(string username, string password, string email)
		{
			var author = EntityFactory<IAuthor>.Instance.Create();
			author.Username = username;
			author.Password = password;
			author.Email = email;
			Repository<IAuthor>.Instance.Save(author);
			var userRegistered = new UserRegisteredEventArgs(author);
			this.UserRegistered.Raise(this,userRegistered);
			return author;
		}

		public void DeleteUser(string username)
		{
			var user=Repository<IAuthor>.Instance.GetByExpression(x => x.Username == username).First();
			DeleteUser(user);
		}

		public void DeleteUser(IAuthor author)
		{
			Repository<IAuthor>.Instance.Remove(author);
		}

		public IAuthor GetAuthorInfoByName(string author)
		{
			var aut = Repository<IAuthor>.Instance.GetByExpression(x => x.Username==author).First();
			return aut;
		}

		//TODO: Introduce IEncryptionService
		public void ResetPassword(string email)
		{
			var author = Repository<IAuthor>.Instance.GetByExpression(x => x.Email == email).First();
			author.Password = Guid.NewGuid().ToString();
			Repository<IAuthor>.Instance.Save(author);
			var passwordResetEvent = new PasswordResettedEventArgs(author, author.Password);
			this.PasswordResetted.Raise(this,passwordResetEvent);
		}

		#endregion

		#region IMembershipService Members
		public event EventHandler<IMembershipService, UserRegisteredEventArgs> UserRegistered = delegate { };
		public event EventHandler<IMembershipService, PasswordResettedEventArgs> PasswordResetted=delegate { };
		#endregion
	}
}
