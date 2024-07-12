using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipoResponsableCaja
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaTipoRespobableCajaOpe(int idAgencia, DateTime dFecOperacion)
        {
            return objEjeSp.EjecSP("CAJ_ListarTipoRespCaja_sp", idAgencia, dFecOperacion);
        }
        //Crear Método para ejecutar SP y trater Listado de Paises
        public DataTable ListaTipoRespobableCajaAdm(int idAgencia)
        {
            return objEjeSp.EjecSP("CAJ_ListTipRespCajaAdm_sp", idAgencia);
        }

        public DataTable ListaTipoRespobableCajaSupervision(string cTipoVisita)
        {
            return objEjeSp.EjecSP("CAJ_ListarTipoResponsableVisita_SP", cTipoVisita);
        }
    }
}
