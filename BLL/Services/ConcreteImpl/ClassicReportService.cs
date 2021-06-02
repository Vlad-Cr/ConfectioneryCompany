using AutoMapper;
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
	public class ClassicReportService : BaseReportService
	{
		public ClassicReportService(IUnitOfWork DB) : base(DB)
		{
		}

		public override void Add(ReportDTO report)
		{
			var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReportDTO, Report>()).CreateMapper();
			var DBreport = mapper.Map<ReportDTO, Report>(report);

			_db.Reports.Create(DBreport);
		}

		public override ReportDTO CalculateReport(IEnumerable<ProductDTO> products)
		{
			ReportDTO repDTO = new ReportDTO();
			int CountBorder = 200;

			if(products.Count() > CountBorder && products.Any(p => p.ProductionDate > DateTime.Now))
			{
				repDTO.Date = DateTime.Now;
				repDTO.RealizationRate = 0.7f;
			}
			else
			{
				repDTO.Date = DateTime.Now;
				repDTO.RealizationRate = 0.3f;
			}

			Add(repDTO);

			return repDTO;
		}

		public override IEnumerable<ReportDTO> GetAll(int page)
		{
			var reportsEntities = _db.Reports.GetAll();

			var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Report, ReportDTO>()).CreateMapper();
			var reportsDto = mapper.Map<IEnumerable<Report>, List<ReportDTO>>(reportsEntities);

			return reportsDto;
		}

		public override IEnumerable<ReportDTO> GetAllWithRate(int page, float Rate)
		{
			var reportsEntities = _db.Reports.Find(r => r.RealizationRate > Rate);

			var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Report, ReportDTO>()).CreateMapper();
			var reportsDtoRate = mapper.Map<IEnumerable<Report>, List<ReportDTO>>(reportsEntities);

			return reportsDtoRate;
		}

		public override bool IsValid(ReportDTO report)
		{
			var reportsEntities = _db.Reports.Find(r => r.Id == report.Id);

			if (reportsEntities.Count() == 0)
			{
				return false;
			}

			return true;
		}
	}
}
