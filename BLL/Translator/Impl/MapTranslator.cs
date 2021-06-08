using AutoMapper;
using BLL.Translator.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Translator.Impl
{
    public class MapTranslator : ITranslator
    {
        public IEnumerable<T1> Translate<T,T1>(IEnumerable<T> list) where T1 : new()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<T, T1>()).CreateMapper();
            var OutList = mapper.Map<IEnumerable<T>, IEnumerable<T1>>(list);

            return OutList;
        }
    }
}
