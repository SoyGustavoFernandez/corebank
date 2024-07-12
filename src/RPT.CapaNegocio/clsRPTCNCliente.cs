using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNCliente
    {
        clsRPTADCliente ADCliente = new clsRPTADCliente();

        public DataTable CNDireccion(int idCuenta)
        {
            return ADCliente.ADDireccion(idCuenta);
        }
        public DataTable CNdocumento(int idCliente)
        {
            return ADCliente.ADDocumento(idCliente);
        }
    }
}
