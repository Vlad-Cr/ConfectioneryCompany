using BLL.DTO;
using BLL.Services.Impl;
using CCL.Security;
using DAL.UnitOfWork;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BLL.FactoryMethod;
using CCL.Security.Identity;
using System.Linq;

namespace BLL.Singleton
{
	public class DbSystem
	{
		private static DbSystem _dbsystem;
		private static object syncRoot = new Object();

		private static IUnitOfWork _db;

		private DbSystem()
		{
			DbContextOptions opt = new DbContextOptionsBuilder<ConfectioneryCompanyContext>().Options;
			IUnitOfWork _db = new EFUnitOfWork(opt);
		}

		public static DbSystem GetInstance()
		{
			if (_dbsystem == null)
			{
				lock (syncRoot)
				{
					if (_dbsystem == null)
						_dbsystem = new DbSystem();
				}
			}
			return _dbsystem;
		}

		public IUnitOfWork GetDB()
		{
			return _db;
		}

		public IEnumerable<ReportDTO> GetReports()
		{
			ReportService reportService = new ReportService(_db);
			return reportService.GetReports(0);
		}

		public bool Login(string email, string password)
		{
			UserDb user = _db.Users.Find(u => u.Email == email && u.Password == password).First();
			
			if (user == null)
			{
				throw new MethodAccessException();
			}

			UserCreator userCreator = GetUserCreator(user.UserType);

			if(userCreator == null)
			{
				throw new MethodAccessException();
			}

			SecurityContext.SetUser(userCreator.CreateUser(user));

			return true;
		}

		private UserCreator GetUserCreator(string UserType)
		{
			Dictionary<string, UserCreator> Creators = new Dictionary<string, UserCreator>
			{
				{ nameof(Director), new DirectorCreator(nameof(Director))},
				{ nameof(Administrator), new AdminCreator(nameof(Administrator))},
				{ nameof(Accountant), new AccountantCreator(nameof(Accountant))},
			};

			return Creators[UserType];
		}
	}
}
