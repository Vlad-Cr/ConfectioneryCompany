using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	class Report
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public float RealizationRate { get; set; }
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Outlet> Outlets { get; set; }
	}
}
