using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
	public class ConfectioneryCompanyContext : DbContext
	{
		public DbSet<Report> Reports { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Outlet> Outlets { get; set; }
		
        public ConfectioneryCompanyContext(DbContextOptions options)
			: base(options)
		{
		}
	}
}
