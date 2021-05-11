using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	class Product
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public DateTime ProductionDate { get; set; }
	}
}
