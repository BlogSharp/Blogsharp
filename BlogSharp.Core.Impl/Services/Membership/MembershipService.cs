namespace BlogSharp.Core.Impl.Services.Membership
{
	using System;
	using Core.Services.Encryption;
	using Core.Services.Membership;
	using Event.MembershipEvents;
	using Model;
	using Persistence.Repositories;

	public class MembershipService : IMembershipService
	{
		private readonly IEncryptionService _encryptionService;
		private readonly IUserRepository _userRepository;

		public MembershipService(IUserRepository userRepository, IEncryptionService encryptionService)
		{
			_encryptionService = encryptionService;
			_userRepository = userRepository;
		}

		#region IMembershipService Members

		public User CreateNewUser(string username, string password, string email)
		{
			var author = new User {UserName = username, Password = password, Email = email};
			_userRepository.SaveUser(author);
			var userRegistered = new UserRegisteredEventArgs(this, author);
			UserRegistered.Raise(userRegistered);
			return author;
		}

		public void DeleteUser(string username)
		{
			var user = _userRepository.GetAuthorByUsername(username);
			DeleteUser(user);
		}

		public void DeleteUser(User user)
		{
			_userRepository.RemoveUser(user);
		}

		public User GetAuthorInfoByName(string author)
		{
			var aut = _userRepository.GetAuthorByUsername(author);
			return aut;
		}

		//TODO: Introduce IEncryptionService
		public void ResetPassword(string email)
		{
			var author = _userRepository.GetAuthorByEmail(email);
			author.Password = Guid.NewGuid().ToString();
			_userRepository.SaveUser(author);
			var passwordResetEvent = new PasswordResettedEventArgs(this, author, author.Password);
			PasswordResetted.Raise(passwordResetEvent);
		}

		public event Core.EventHandler<UserRegisteredEventArgs> UserRegistered = delegate { };
		public event Core.EventHandler<PasswordResettedEventArgs> PasswordResetted = delegate { };

		#endregion
	}
}