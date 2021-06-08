using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Impl
{
    public class OutletState
    {
        private OutletDTO _outlet;

        public OutletState(OutletDTO outlet)
        {
            _outlet = new OutletDTO(outlet);
        }

        public OutletDTO GetInfo()
        {
            return _outlet;
        }
    }
}
