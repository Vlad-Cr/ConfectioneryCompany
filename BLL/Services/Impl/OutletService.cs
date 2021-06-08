using AutoMapper;
using BLL.DTO;
using BLL.Entities.Impl;
using BLL.Services.Interface;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services.Impl
{
    public class OutletService : IOutletService
    {
        protected readonly IUnitOfWork _database;
        private ServiceState _state;

        public OutletService(IUnitOfWork db, ServiceState state)
        {
            _database = db;
            _state = state;
        }

        public WorkOutlet GetOutletById(int Id)
        {
            return _state.GetOutletById(Id);
        }

        public HistoryOfOutlet AddHistoryObserver(WorkOutlet workOutler)
        {
            return _state.AddHistoryObserver(workOutler);
        }

        public void SetState(ServiceState state)
        {
            _state = state;
        }

        public void ToggleState()
        {
            _state.Handle(this);
        }
    }
}
