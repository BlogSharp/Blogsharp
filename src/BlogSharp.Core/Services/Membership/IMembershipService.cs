namespace BlogSharp.Core.Services.Membership
{
	using Event.MembershipEvents;
	using Model;

	public interface IMembershipService
	{
		User CreateNewUser(string username, string password, string email);
		void DeleteUser(string username);
		void DeleteUser(User user);
		User GetAuthorInfoByName(string author);
		void ResetPassword(string email);
		event EventHandler<UserRegisteredEventArgs> UserRegistered;
		event EventHandler<PasswordResettedEventArgs> PasswordResetted;
	}
}