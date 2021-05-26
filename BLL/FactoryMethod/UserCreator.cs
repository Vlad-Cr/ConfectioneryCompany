using CCL.Security.Identity;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.FactoryMethod
{
	public abstract class UserCreator
	{
		protected string UserType { get; }

		public UserCreator (string userType)
		{
			UserType = userType;
		}

		public abstract User CreateUser(UserDb user);
	}
}
