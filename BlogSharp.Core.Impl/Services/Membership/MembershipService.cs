using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using BlogSharp.Core.Impl.Services.Template;
using BlogSharp.Core.Persistence.Repositories;
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
		public MembershipService(IUserRepository userRepository,IEncryptionService encryptionService)
		{
			this.encryptionService = encryptionService;
			this.userRepository = userRepository;
		}

		private readonly IUserRepository userRepository;
		private readonly IEncryptionService encryptionService;

		public IUser CreateNewUser(string username, string password, string email)
		{
			var author = EntityFactory<IUser>.Instance.Create();
			author.Username = username;
			author.Password = password;
			author.Email = email;
			userRepository.SaveUser(author);
			var userRegistered = new UserRegisteredEventArgs(this,author);
			this.UserRegistered.Raise(userRegistered);
			return author;
		}

		public void DeleteUser(string username)
		{
			var user = this.userRepository.GetAuthorByUsername(username);
			DeleteUser(user);
		}

		public void DeleteUser(IUser user)
		{
			this.userRepository.RemoveUser(user);
		}

		public IUser GetAuthorInfoByName(string author)
		{
			var aut = this.userRepository.GetAuthorByUsername(author);
			return aut;
		}

		//TODO: Introduce IEncryptionService
		public void ResetPassword(string email)
		{
			var author = userRepository.GetAuthorByEmail(email);
			author.Password = Guid.NewGuid().ToString();
			userRepository.SaveUser(author);
			var passwordResetEvent = new PasswordResettedEventArgs(this,author, author.Password);
			this.PasswordResetted.Raise(passwordResetEvent);
		}

		public event EventHandler<UserRegisteredEventArgs> UserRegistered = delegate { };
		public event EventHandler<PasswordResettedEventArgs> PasswordResetted=delegate { };

	}
}
