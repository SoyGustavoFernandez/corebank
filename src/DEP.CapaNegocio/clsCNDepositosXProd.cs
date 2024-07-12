using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DEP.AccesoDatos;
using GEN.CapaNegocio;

namespace DEP.CapaNegocio
{
    public class clsCNDepositosXProd
    {
        public clsADDepositosXProd DepositosProd = new clsADDepositosXProd();

        public DataTable ListarDepXProd(string cidProducto, int idMoneda, int idAgencia, int idEstado, int idTipPersona, int idCaracteristica)
        {
            return DepositosProd.ListarDepXProd(cidProducto, idMoneda, idAgencia, idEstado, idTipPersona, idCaracteristica);
        }


    }
}
