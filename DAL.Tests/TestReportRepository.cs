using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
	class TestReportRepository : BaseRepository<Report>
	{
		public TestReportRepository(DbContext context)
		: base(context)
		{
		}

	}
}
