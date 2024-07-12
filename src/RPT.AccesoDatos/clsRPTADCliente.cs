using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADCliente
    {
        public DataTable ADDireccion(int idCuenta)
        {
            return new clsGENEjeSP().EjecSP("CLI_LisDirCli_SP", idCuenta);
        }

        public DataTable ADDocumento(int idCliente) 
        {
            return new clsGENEjeSP().EjecSP("CRE_DatoDocCliente_SP", idCliente);
        }
    }
}
