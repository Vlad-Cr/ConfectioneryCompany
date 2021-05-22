using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
	public interface IReportService
	{
		IEnumerable<ReportDTO> GetReports(int page);
	}
}
