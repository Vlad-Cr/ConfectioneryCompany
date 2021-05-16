using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace DAL.Tests
{
	public class BaseRepositoryUnitTests
	{
		[Fact]
		public void Create_InputReportInstance_CalledAddMethodOfDBSetWithReportInstance()
		{
			// Arrange
			DbContextOptions opt = new DbContextOptionsBuilder<ConfectioneryCompanyContext>().Options;
			var mockContext = new Mock<ConfectioneryCompanyContext>(opt);
			var mockDbSet = new Mock<DbSet<Report>>();

			mockContext .Setup(context => context.Set<Report>()).Returns(mockDbSet.Object);
			var repository = new TestReportRepository(mockContext.Object);
			Report expectedReport = new Mock<Report>().Object;
			
			//Act
			repository.Create(expectedReport);
			
			// Assert
			mockDbSet.Verify(dbSet => dbSet.Add(expectedReport), Times.Once());
	
		}

		[Fact]
		public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
		{
			// Arrange
			DbContextOptions opt = new DbContextOptionsBuilder<ConfectioneryCompanyContext>()
				.Options;
			var mockContext = new Mock<ConfectioneryCompanyContext>(opt);
			var mockDbSet = new Mock<DbSet<Report>>();
			mockContext.Setup(context => context.Set<Report>()).Returns(mockDbSet.Object);

			Report expectedReport = new Report() { Id = 1 };
			mockDbSet.Setup(mock => mock.Find(expectedReport.Id)).Returns(expectedReport);
			var repository = new TestReportRepository(mockContext.Object);

			//Act
			var actualStreet = repository.Get(expectedReport.Id);

			// Assert
			mockDbSet.Verify(dbSet => dbSet.Find(expectedReport.Id), Times.Once());
			Assert.Equal(expectedReport, actualStreet);
		}

		[Fact]
		public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
		{
			// Arrange
			DbContextOptions opt = new DbContextOptionsBuilder<ConfectioneryCompanyContext>()
				.Options;
			var mockContext = new Mock<ConfectioneryCompanyContext>(opt);
			var mockDbSet = new Mock<DbSet<Report>>();

			mockContext.Setup(context => context.Set<Report>()).Returns(mockDbSet.Object);
			var repository = new TestReportRepository(mockContext.Object);

			Report expectedReport = new Report() { Id = 1 };
			mockDbSet.Setup(mock => mock.Find(expectedReport.Id)).Returns(expectedReport);

			//Act
			repository.Delete(expectedReport.Id);

			// Assert
			mockDbSet.Verify(dbSet => dbSet.Find(expectedReport.Id), Times.Once());
			mockDbSet.Verify(dbSet => dbSet.Remove(expectedReport), Times.Once());
		}

	}
}
