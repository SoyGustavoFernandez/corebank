using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADGastosCuenta
    {
        public DataTable ADLstGastosCuenta(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("CRE_LstGastosCuenta_Sp", idCuenta);
        }

        public clsDBResp  ADGrabarGastos(string xmlGastosCuenta,byte[] msBytes)
        {
            clsDBResp objDbResp = new clsDBResp(new clsGENEjeSP().EjecSP("CRE_RegistroGastoCuenta_Sp", xmlGastosCuenta,  
                                                                                                (msBytes == null)?(object)DBNull.Value:msBytes));
            return objDbResp;
        }

        public clsDBResp ADConfirmarGastos(string xmlCuotasGastos)
        {
            clsDBResp objDbResp = new clsDBResp(new clsGENEjeSP().EjecSP("CRE_ConfirmacionGastoCuenta_Sp", xmlCuotasGastos));
            return objDbResp;
        }
    }
}
