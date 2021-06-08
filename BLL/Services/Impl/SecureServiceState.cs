using AutoMapper;
using BLL.DTO;
using BLL.Entities.Impl;
using BLL.Services.Interface;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services.Impl
{
    public class SecureServiceState : ServiceState
    {
        public SecureServiceState(IUnitOfWork db) : base(db)
        {
           
        }

        public override void Handle(OutletService context)
        {
            if (context != null)
                context.SetState(new UnsecureServiceState(_database));
        }

        public override WorkOutlet GetOutletById(int Id)
        {
            var outlet = _database.Outlets.Find(o => o.Id == Id).First();

            if (outlet == null)
            {
                return null;
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Outlet, OutletDTO>()).CreateMapper();
            var outl = mapper.Map<Outlet, OutletDTO>(outlet);

            WorkOutlet workOutlet = new WorkOutlet(outl);

            return workOutlet;
        }

        public override HistoryOfOutlet AddHistoryObserver(WorkOutlet workOutler)
        {
            HistoryOfOutlet newHistory = new HistoryOfOutlet();
            workOutler.AddObserver(newHistory);
            return newHistory;
        }
    }
}
