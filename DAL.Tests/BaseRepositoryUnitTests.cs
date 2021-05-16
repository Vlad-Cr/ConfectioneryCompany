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
	}
}
