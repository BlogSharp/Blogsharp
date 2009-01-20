using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Core.Event.MembershipEvents;
using BlogSharp.Model;

namespace BlogSharp.Core.Services.Membership
{
	public interface IMembershipService
	{
		IUser CreateNewUser(string username, string password, string email);
		void DeleteUser(string username);
		void DeleteUser(IUser user);
		IUser GetAuthorInfoByName(string author);
		void ResetPassword(string email);
		event EventHandler<UserRegisteredEventArgs> UserRegistered;
		event EventHandler<PasswordResettedEventArgs> PasswordResetted;

	}
}
