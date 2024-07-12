using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;

namespace LOG.AccesoDatos
{
    public class clsADTipoComprobantes
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTipoComprobantes()
        {
            return objEjeSp.EjecSP("LOG_ListarTipoComprobantes_SP");
        }
    }
}
