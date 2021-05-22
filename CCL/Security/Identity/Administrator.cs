using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
	public class Administrator : User
	{
		public Administrator(int userId, string name)
			: base(userId, name, nameof(Administrator))
		{
		}
	}
}
