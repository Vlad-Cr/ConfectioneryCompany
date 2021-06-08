using BLL.Entities.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interface
{
    public interface IOutletService
    {
        WorkOutlet GetOutletById(int Id);
    }
}
