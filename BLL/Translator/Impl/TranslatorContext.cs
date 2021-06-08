using BLL.Translator.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Translator.Impl
{
    public class TranslatorContext
    {
        public ITranslator _translator { get; set; }

        public TranslatorContext(ITranslator translator)
        {
            _translator = translator;
        }

        public IEnumerable<T1> ExecuteTranslate<T, T1>(IEnumerable<T> list) where T1 : new()
        {
            return _translator.Translate<T, T1>(list);
        }
    }
}
