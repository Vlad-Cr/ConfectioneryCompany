using BLL.DTO;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
	public abstract class AbstractionReportService
	{
		protected readonly IUnitOfWork _database;
		protected BaseReportService ReportServiceImpl;

		public AbstractionReportService(BaseReportService reportService)
		{
			ReportServiceImpl = reportService;
		}

		public virtual IEnumerable<ReportDTO> GetReports(int page)
		{
			return ReportServiceImpl.GetAll(0);
		}

		public virtual IEnumerable<ReportDTO> GetRealizationReports(int page, float Rate)
		{
			return ReportServiceImpl.GetAllWithRate(0, Rate);
		}

		public virtual bool isValid(ReportDTO report)
		{
			return true;
		}

		public virtual void AddNew(ReportDTO report)
		{
			ReportServiceImpl.Add(report);
		}

		public virtual ReportDTO CreateReport(IEnumerable<ProductDTO> products)
		{
			throw new NotImplementedException();
		}
	}
}
