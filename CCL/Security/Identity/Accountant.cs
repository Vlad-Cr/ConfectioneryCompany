using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
	public class Accountant : User
	{
		public Accountant(int userId, string name, string password, string email)
			: base(userId, name, password, email, nameof(Accountant))
		{
		}
	}
}
