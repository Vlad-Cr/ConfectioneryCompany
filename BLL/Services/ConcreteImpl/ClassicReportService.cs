using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using BLL.Translator.Impl;
using BLL.Translator.Interface;
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
        private ReportDTO currentReportDTO;


        public ClassicReportService(IUnitOfWork DB) : base(DB)
		{
		}

		public override void Add(ReportDTO report)
		{
			var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReportDTO, Report>()).CreateMapper();
			var DBreport = mapper.Map<ReportDTO, Report>(report);
            
            _db.Reports.Create(DBreport);
		}
        
        public override void InitCalculation()
        {
            CountBorderOfReport = 200;
            currentReportDTO = new ReportDTO();
        }

        public override void Calculate(IEnumerable<ProductDTO> products)
        {
            if (products.Count() > CountBorderOfReport && products.Any(p => p.ProductionDate > DateTime.Now))
            {
                currentReportDTO.Date = DateTime.Now;
                currentReportDTO.RealizationRate = 0.7f;
            }
            else
            {
                currentReportDTO.Date = DateTime.Now;
                currentReportDTO.RealizationRate = 0.3f;
            }
        }

        public override ReportDTO AddFinalReport()
        {
            Add(currentReportDTO);
            return currentReportDTO;
        }

        public override IEnumerable<ReportDTO> GetAll(int page)
		{
			var reportsEntities = _db.Reports.GetAll();
            
            ITranslator mapTranslator = new MapTranslator();
            //ITranslator simpleTranslator = new SimpleTranslator();

            TranslatorContext context = new TranslatorContext(mapTranslator);
            var reportsDto = context.ExecuteTranslate<Report, ReportDTO>(reportsEntities);

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
