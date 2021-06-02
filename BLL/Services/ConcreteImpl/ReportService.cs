using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace BLL.Services.Impl
{
	public class ReportService : AbstractionReportService
	{
		private int pageSize = 10;
		
        public ReportService(BaseReportService reportService) : base(reportService)
		{
			if (reportService == null)
			{
				throw new ArgumentNullException(nameof(reportService));
			}
		}

		/// <exception cref="MethodAccessException"></exception>
		public override IEnumerable<ReportDTO> GetReports(int pageNumber)
		{
			if (!IsUserCorrect())
			{
				throw new MethodAccessException();
			}

			return ReportServiceImpl.GetAll(pageNumber);
		}

		private bool IsUserCorrect()
		{
			var user = SecurityContext.GetUser();
			var userType = user.GetType();

			if (userType != typeof(Director) && userType != typeof(Accountant))
			{
				return false;
			}

			return true;
		}

		public override void AddNew(ReportDTO report)
		{
			if (!IsUserCorrect())
			{
				throw new MethodAccessException();
			}

			ReportServiceImpl.Add(report);
		}

		public override ReportDTO CreateReport(IEnumerable<ProductDTO> products)
		{
			if (!IsUserCorrect())
			{
				throw new MethodAccessException();
			}

			return ReportServiceImpl.CalculateReport(products);
		}

		/// <exception cref="MethodAccessException"></exception>
		public override IEnumerable<ReportDTO> GetRealizationReports(int page, float Rate)
		{
			if (!IsUserCorrect())
			{
				throw new MethodAccessException();
			}

			return ReportServiceImpl.GetAllWithRate(0, Rate);
		}

		public override bool isValid(ReportDTO report)
		{
			if (!IsUserCorrect())
			{
				throw new MethodAccessException();
			}

			return ReportServiceImpl.IsValid(report);
		}
	}
}
