using CCL.Security.Identity;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.FactoryMethod
{
	public class AdminCreator : UserCreator
	{
		public AdminCreator (string userType) : base(userType)
		{

		}

		public override User CreateUser(UserDb user)
		{
			return new Administrator(user.Id, user.Name, user.Password, user.Email);
		}
	}
}
