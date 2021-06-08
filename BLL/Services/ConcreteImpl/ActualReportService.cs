using BLL.DTO;
using BLL.Entities.Impl;
using BLL.Entities.Interfaces;
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
        private WorkReport CurrentWorkReport;
        
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

        public override void InitCalculation()
        {
            CountBorderOfReport = 100;
        }

        public override void Calculate(IEnumerable<ProductDTO> products)
        {
            Random rand = new Random();
            List<ProductDTO> productsList = new List<ProductDTO>();
            productsList.AddRange(products);

            CurrentWorkReport = new WorkReport(rand.Next(1000), DateTime.Now, productsList);
            var iterator = CurrentWorkReport.GetIterator();

            int countSpecialType = 0;
            ProductDTO item = (ProductDTO)iterator.First();

            while (!iterator.IsDone())
            {
                item = (ProductDTO)iterator.Next();

                if (item.Type == "SpecialCake")
                {
                    countSpecialType++;
                }
            }

            if (countSpecialType < 100)
            {
                CurrentWorkReport.RealizationRate = 0.3f;
            }
            else
            {
                CurrentWorkReport.RealizationRate = 0.8f;
            }
        }

        public override ReportDTO AddFinalReport()
        {
            Add(CurrentWorkReport.GetReportDTO());
            return CurrentWorkReport.GetReportDTO();
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
