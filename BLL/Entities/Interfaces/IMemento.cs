using BLL.Entities.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Interfaces
{
    public interface IMemento
    {
        void SetState(OutletState state);
        OutletState SaveState();
    }
}
