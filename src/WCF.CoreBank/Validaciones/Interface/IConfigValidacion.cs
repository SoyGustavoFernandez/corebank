using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using EntityLayer;

namespace WCF.CoreBank.Validaciones.Interface
{
    public interface IConfigValidacion
    {
        void setObjeto<T>(T obj);
        Dictionary<string, reglaValidacion[]> configuracion();
    }
}
