using AutoMapper;
using BLL.DTO;
using BLL.Entities.Interfaces;
using BLL.Translator.Impl;
using BLL.Translator.Interface;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Impl
{
    public class WorkReport : AggregateReport
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float RealizationRate { get; set; }
        List<ProductDTO> ReportedProducts { get; set; }

        public WorkReport(ReportDTO report)
        {
            Id = report.Id;
            Date = report.Date;
            RealizationRate = report.RealizationRate;
        }

        public WorkReport(int id, DateTime date, List<ProductDTO> list)
        {
            Id = id;
            Date = date;
            ReportedProducts = list;
        }

        public void AddReportedProducts(IEnumerable<ProductDTO> list)
        {
            ReportedProducts.AddRange(list);
        }

        public IIterator GetIterator()
        {
            return new ReportIterator(ReportedProducts);
        }

        public ReportDTO GetReportDTO()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WorkReport, ReportDTO>()).CreateMapper();
            return mapper.Map<WorkReport, ReportDTO>(this);
        }
    }
}
