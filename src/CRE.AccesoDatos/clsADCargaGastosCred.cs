using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADCargaGastosCred
    {
        public DataTable GetGastosManualesCuenta(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("CRE_GetGastosManualesCuenta_Sp", idCuenta);
        }

        public DataTable ListarCargaGastosPorCuenta(int nCuenta)
        {
            return new clsGENEjeSP().EjecSP("CRE_ListarGastosPorCuenta_sp", nCuenta);
        }

        public DataTable ListarOtrosGastosPorCuota(int nCuenta, int nCuota)
        {
            return new clsGENEjeSP().EjecSP("CRE_ListarOtrosGastosPorCuota_sp", nCuenta, nCuota);
        }
    }
}
