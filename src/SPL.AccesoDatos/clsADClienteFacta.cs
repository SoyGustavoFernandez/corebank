using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;

namespace SPL.AccesoDatos
{
    public class clsADClienteFacta
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable CNActualizarClienteNaturalFacta(int idCli, Boolean lFacta, Boolean lAceptaResidenciaUS)
        {
            return objEjeSp.EjecSP("SPL_ActualizarClienteNaturalFacta_SP", idCli, lFacta, lAceptaResidenciaUS);
        }

        public DataTable ADObtenerClienteFactaPorIdCli(int idCli)
        {
            return objEjeSp.EjecSP("SPL_ObtenerClienteFactaPorIdCli_SP", idCli);
        }
    }
}
