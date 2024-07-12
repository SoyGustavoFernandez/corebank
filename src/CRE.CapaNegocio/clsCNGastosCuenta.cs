using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;
using CRE.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNGastosCuenta
    {
        public DataTable CNLstGastosCuenta(int idCuenta)
        {
            return new clsADGastosCuenta().ADLstGastosCuenta(idCuenta);
        }

        public clsDBResp CNGrabarGastos(string xmlGastosCuenta,byte[] msBytes)
        {
            return new clsADGastosCuenta().ADGrabarGastos(xmlGastosCuenta, msBytes);
        }

        public clsDBResp CNConfirmarGastos(string xmlCuotasGastos)
        {
            return new clsADGastosCuenta().ADConfirmarGastos(xmlCuotasGastos);
        }
    }
}
