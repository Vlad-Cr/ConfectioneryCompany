using BLL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Impl
{
    public class HistoryOfOutlet : IObserver
    {
        private Stack<OutletState> History;

        public HistoryOfOutlet()
        {
            History = new Stack<OutletState>();
        }

        public void Save(OutletState state)
        {
            History.Push(state);
        }

        public OutletState UndoState()
        {
            return History.Pop();
        }

        public void Update(WorkOutlet workOutlet)
        {
            Save(workOutlet.SaveState());
        }
    }
}
