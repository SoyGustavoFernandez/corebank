using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.Funciones
{
    public class ListToIList
    {
        public static IList<T> ConvertToListOf<T>(IList iList)
        {
            IList<T> result = new List<T>();
            foreach (T value in iList)
            {
                result.Add(value);
            }
            return result;
        }
    }
}
