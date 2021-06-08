using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Translator.Interface
{
    public interface ITranslator
    {
        IEnumerable<T1> Translate<T, T1>(IEnumerable<T> list) where T1 : new();
    }
}
