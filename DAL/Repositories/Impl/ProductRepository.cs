using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		internal ProductRepository(ConfectioneryCompanyContext context)
			: base(context)
		{
		}
	}
}
