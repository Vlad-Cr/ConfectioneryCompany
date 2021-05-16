using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IReportRepository Reports { get; }
		IProductRepository Products { get; }
		IOutletIRepository Outlets { get; }
		void Save();
	}
}
