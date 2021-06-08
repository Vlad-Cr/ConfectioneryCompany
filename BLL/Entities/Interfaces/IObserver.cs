using BLL.Entities.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Interfaces
{
    public interface IObserver
    {
        void Update(WorkOutlet workOutlet); 
    }
}
