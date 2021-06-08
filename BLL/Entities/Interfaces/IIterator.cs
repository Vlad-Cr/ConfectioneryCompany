using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Interfaces
{
    public interface IIterator
    {
        object CurrentItem();
        object First();
        object Next();
        bool IsDone();
        void Reset();
    }
}
