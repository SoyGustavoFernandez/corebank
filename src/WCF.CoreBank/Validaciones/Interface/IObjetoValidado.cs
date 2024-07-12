using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace WCF.CoreBank.Validaciones.Interface
{
    public interface IObjetoValidado
    {
        void setObjeto<T>(T obj);
        object getObjeto();
    }

}
