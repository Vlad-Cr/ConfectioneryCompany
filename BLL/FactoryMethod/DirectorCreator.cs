using CCL.Security.Identity;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.FactoryMethod
{
	public class DirectorCreator : UserCreator
	{
		public DirectorCreator(string userType) : base(userType)
		{
		}

		public override User CreateUser(UserDb user)
		{
			return new Director(user.Id, user.Name, user.Password, user.Email);
		}
	}
}
