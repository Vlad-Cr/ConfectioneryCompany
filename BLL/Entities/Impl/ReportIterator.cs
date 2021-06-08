using BLL.DTO;
using BLL.Entities.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities.Impl
{
    public class ReportIterator : IIterator
    {
        private List<ProductDTO> Products;
        private int _current;

        public ReportIterator(List<ProductDTO> products)
        {
            Products = products;
            _current = 0;
        }

        public object CurrentItem()
        {
            return Products[_current];
        }

        public void Reset()
        {
            _current = 0;
        }

        public object First()
        {
            if(Products.Count == 0)
            {
                return null;
            }

            return Products[_current];
        }

        public bool IsDone()
        {
            return _current >= Products.Count;
        }

        public object Next()
        {
            object nextElem = null;

            _current++;

            if (_current < Products.Count)
            {
                nextElem = CurrentItem();
            }

            return nextElem;
        }
    }
}
