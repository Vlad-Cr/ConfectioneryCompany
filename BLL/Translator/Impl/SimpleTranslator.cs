using BLL.Translator.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Translator.Impl
{
    public class SimpleTranslator : ITranslator
    {
        public IEnumerable<T1> Translate<T, T1>(IEnumerable<T> list) where T1 : new()
        {
            List<T1> OutList = new List<T1>();

            foreach (T elem in list)
            {
                T1 newElem = new T1();
                var InProperties = elem.GetType().GetProperties();
                var OutProperties = newElem.GetType().GetProperties();
                
                foreach (var inProperty in InProperties)
                {
                    foreach (var outProperty in OutProperties)
                    {
                        if (inProperty.Name == outProperty.Name && inProperty.PropertyType == outProperty.PropertyType)
                        {
                            outProperty.SetValue(newElem, inProperty.GetValue(elem));
                            break;
                        }
                    }
                }
            }

            return OutList;
        }
    }
}
