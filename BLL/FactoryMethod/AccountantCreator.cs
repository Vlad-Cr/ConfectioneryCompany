using CCL.Security.Identity;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.FactoryMethod
{
	public class AccountantCreator : UserCreator
	{
		public AccountantCreator(string userType) : base(userType)
		{
		}

		public override User CreateUser(UserDb user)
		{
			return new Accountant(user.Id, user.Name, user.Password, user.Email);
		}
	}
}
