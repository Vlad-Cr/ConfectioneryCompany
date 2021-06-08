using BLL.Entities.Impl;
using BLL.Services.Impl;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interface
{
    public abstract class ServiceState
    {
        protected readonly IUnitOfWork _database;

        public ServiceState(IUnitOfWork db)
        {
            _database = db;
        }

        public abstract void Handle(OutletService context);
   
        public abstract WorkOutlet GetOutletById(int Id);
        public abstract HistoryOfOutlet AddHistoryObserver(WorkOutlet workOutler);
    }
}
