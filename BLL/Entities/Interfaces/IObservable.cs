using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Interfaces
{
    public interface IObservable
    {
        void AddObserver(IObserver obser);
        void RemoveObserver(IObserver obser);
        void NotifyObservers();
    }
}
