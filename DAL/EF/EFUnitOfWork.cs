using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
	internal class EFUnitOfWork
		: IUnitOfWork
	{
		private ConfectioneryCompanyContext db;
		private IReportRepository reportRepository;
		private IProductRepository productRepository;
		private IOutletIRepository outletRepository;
		
        public EFUnitOfWork(DbContextOptions options)
		{
			db = new ConfectioneryCompanyContext(options);
		}

		public EFUnitOfWork()
		{
		}

		public IReportRepository Reports
		{
			get
			{
				if (reportRepository == null)
					reportRepository = new ReportRepository(db);
				return reportRepository;
			}
		}
		
        public IProductRepository Products
		{
			get
			{
				if (productRepository == null)
					productRepository = new ProductRepository(db);
				return productRepository;
			}
		}

		public IOutletIRepository Outlets
		{
			get
			{
				if (outletRepository == null)
					outletRepository = new OutletRepository(db);
				return outletRepository;
			}
		}
		
        public void Save()
		{
			db.SaveChanges();
		}
		
        private bool disposed = false;
		
        public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}
		
        public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
