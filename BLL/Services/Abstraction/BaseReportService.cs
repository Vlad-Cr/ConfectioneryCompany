using BLL.DTO;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
	public abstract class BaseReportService
	{
		protected IUnitOfWork _db;

		public BaseReportService(IUnitOfWork DB)
		{
			_db = DB;
		}

		public abstract IEnumerable<ReportDTO> GetAll(int page);
		public abstract IEnumerable<ReportDTO> GetAllWithRate(int page, float Rate);
		public abstract bool IsValid(ReportDTO report);
		public abstract void Add(ReportDTO report);
		public abstract ReportDTO CalculateReport(IEnumerable<ProductDTO> products);
	}
}
