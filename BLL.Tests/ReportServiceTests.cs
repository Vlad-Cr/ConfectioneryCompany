﻿using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BLL.Tests
{
	public class ReportServiceTests
	{
		[Fact]
		public void Ctor_InputNull_ThrowArgumentNullException()
		{
			// Arrange
			IUnitOfWork nullUnitOfWork = null;
			
			// Act
			// Assert
			Assert.Throws<ArgumentNullException>(() => new ReportService(nullUnitOfWork));
		}

		[Fact]
		public void GetReports_UserIsAdministrator_ThrowMethodAccessException()
		{
			// Arrange
			User user = new Administrator(1, "test", "test", "test");
			SecurityContext.SetUser(user);
			var mockUnitOfWork = new Mock<IUnitOfWork>();
			IReportService streetService = new ReportService(mockUnitOfWork.Object);
			
			// Act
			// Assert
			Assert.Throws<MethodAccessException>(() => streetService.GetReports(0));
		}

		[Fact]
		public void GetReports_ReportFromDAL_CorrectMappingToReportDTO()
		{
			// Arrange
			User user = new Director(1, "test", "test", "test");
			SecurityContext.SetUser(user);
			var reportService = GetReportService();
			
			// Act
			var actualReportDTO = reportService.GetReports(0).First();
			
			// Assert
			Assert.True(
				actualReportDTO.Id == 1
				&& actualReportDTO.RealizationRate < 71.0f
				&& actualReportDTO.RealizationRate > 69.0f
			);
		}
		
		IReportService GetReportService()
		{
			var mockContext = new Mock<IUnitOfWork>();
			var expectedReport = new Report()
			{
				Id = 1,
				RealizationRate = 70.0f,
			};

			var mockDbSet = new Mock<IReportRepository>();
			mockDbSet .Setup(z => z.GetAll())
				.Returns(new List<Report>() { expectedReport } );
			mockContext.Setup(context =>context.Reports)
				.Returns(mockDbSet.Object);
			
			 IReportService reportService = new ReportService(mockContext.Object);
			
			return reportService;
		}
	}
}
