using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
	public abstract class User
	{
		public User(int userId, string name, string password, string email, string userType)
		{
			UserId = userId;
			Name = name;
			Password = password;
			Email = email;
			UserType = userType;
		}

		public int UserId { get; }
		public string Name { get; }
		public string Password { get; set; }
		public string Email { get; set; }
		protected string UserType { get; }
	}
}
