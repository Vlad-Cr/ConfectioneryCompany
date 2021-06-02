using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services.Impl
{
	public class ActualReportService : BaseReportService
	{
		public ActualReportService(IUnitOfWork DB) : base(DB)
		{
		}

		public override void Add(ReportDTO report)
		{
			Report newRep = new Report()
			{
				Id = report.Id,
				Date = report.Date,
				RealizationRate = report.RealizationRate,
			};

			_db.Reports.Create(newRep);
		}

		public override ReportDTO CalculateReport(IEnumerable<ProductDTO> products)
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<ReportDTO> GetAll(int page)
		{
			var reportsEntities = _db.Reports.GetAll();
			List<ReportDTO> reportsDto = new List<ReportDTO>();


			foreach (var rep in reportsEntities)
			{
				ReportDTO newRep = new ReportDTO()
				{
					Id = rep.Id,
					Date = rep.Date,
					RealizationRate = rep.RealizationRate,
				};

				reportsDto.Add(newRep);
			}

			return reportsDto;
		}

		public override IEnumerable<ReportDTO> GetAllWithRate(int page, float Rate)
		{
			var reportsEntities = _db.Reports.GetAll();
			List<ReportDTO> reportsDto = new List<ReportDTO>();
			
			foreach (var rep in reportsEntities)
			{
				if (rep.RealizationRate > 0.5f)
				{
					ReportDTO newRep = new ReportDTO()
					{
						Id = rep.Id,
						Date = rep.Date,
						RealizationRate = rep.RealizationRate,
					};

					reportsDto.Add(newRep);
				}
			}

			return reportsDto;
		}

		public override bool IsValid(ReportDTO report)
		{
			var reportsEntities = _db.Reports.Find(r => r.Id == report.Id).First();

			if (reportsEntities == null)
			{
				return false;
			}

			return true;
		}
	}
}
