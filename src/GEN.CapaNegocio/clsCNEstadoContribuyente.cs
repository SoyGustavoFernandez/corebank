using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNEstadoContribuyente
    {
        clsADEstadoContribuyente ObjEstContribuy = new clsADEstadoContribuyente();

        public DataTable CNListaEstadoContribuyente()
        {
            return ObjEstContribuy.ADListaEstadoContribuyente();
        }
    }
}
