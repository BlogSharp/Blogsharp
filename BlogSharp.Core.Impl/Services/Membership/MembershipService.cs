using System;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Core.Persistence.Repositories;
using BlogSharp.Core.Services.Encryption;
using BlogSharp.Core.Services.Membership;
using BlogSharp.Model;

namespace BlogSharp.Core.Impl.Services.Membership
{
	public class MembershipService : IMembershipService
	{
		private readonly IEncryptionService encryptionService;
		private readonly IUserRepository userRepository;

		public MembershipService(IUserRepository userRepository, IEncryptionService encryptionService)
		{
			this.encryptionService = encryptionService;
			this.userRepository = userRepository;
		}

		#region IMembershipService Members

		public User CreateNewUser(string username, string password, string email)
		{
			var author = new User {Username = username, Password = password, Email = email};
			userRepository.SaveUser(author);
			var userRegistered = new UserRegisteredEventArgs(this, author);
			UserRegistered.Raise(userRegistered);
			return author;
		}

		public void DeleteUser(string username)
		{
			var user = userRepository.GetAuthorByUsername(username);
			DeleteUser(user);
		}

		public void DeleteUser(User user)
		{
			userRepository.RemoveUser(user);
		}

		public User GetAuthorInfoByName(string author)
		{
			var aut = userRepository.GetAuthorByUsername(author);
			return aut;
		}

		//TODO: Introduce IEncryptionService
		public void ResetPassword(string email)
		{
			var author = userRepository.GetAuthorByEmail(email);
			author.Password = Guid.NewGuid().ToString();
			userRepository.SaveUser(author);
			var passwordResetEvent = new PasswordResettedEventArgs(this, author, author.Password);
			PasswordResetted.Raise(passwordResetEvent);
		}

		public event EventHandler<UserRegisteredEventArgs> UserRegistered = delegate { };
		public event EventHandler<PasswordResettedEventArgs> PasswordResetted = delegate { };

		#endregion
	}
}