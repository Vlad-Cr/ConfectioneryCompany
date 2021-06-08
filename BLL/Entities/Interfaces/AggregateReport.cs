using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Interfaces
{
    public interface AggregateReport
    {
        IIterator GetIterator();
    }
}
