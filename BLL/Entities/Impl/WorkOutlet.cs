using BLL.DTO;
using BLL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Impl
{
    public class WorkOutlet : IMemento, IObservable
    {
        private OutletDTO _outlet;
        private HistoryOfOutlet _history;
        private List<IObserver> _observers;

        public WorkOutlet(OutletDTO outlet)
        {
            _outlet = outlet;
            _history = new HistoryOfOutlet();
            AddObserver(_history);
        }

        public OutletDTO GetOutletDTO()
        {
            return new OutletDTO(_outlet);
        }

        public HistoryOfOutlet GetHistory()
        {
            return _history;
        }

        public void AddObserver(IObserver obser)
        {
            _observers.Add(obser);
        }

        public void NotifyObservers()
        {
            foreach(var ob in _observers)
            {
                ob.Update(this);
            }
        }

        public void RemoveObserver(IObserver obser)
        {
            _observers.Remove(obser);
        }

        public OutletState SaveState()
        {
            return new OutletState(_outlet);
        }

        public void SetState(OutletState state)
        {
            _outlet = state.GetInfo();
        }

        public void SetId(int id)
        {
            _outlet.Id = id;
            NotifyObservers();
        }

        public void SetName(string name)
        {
            _outlet.Name = name;
            NotifyObservers();
        }

        public void SetRegion(string region)
        {
            _outlet.Region = region;
            NotifyObservers();
        }

        public void SetProfit(float profit)
        {
            _outlet.Profit = profit;
            NotifyObservers();
        }

        public int GetId()
        {
            return _outlet.Id;
        }

        public string GetName()
        {
            return _outlet.Name;
        }

        public string GetRegion()
        {
            return _outlet.Region;
        }

        public float GetProfit()
        {
            return _outlet.Profit;
        }
    }
}
