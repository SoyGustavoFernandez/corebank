using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNDeclaracionJurada
    {
        clsADDeclaracionJurada objDeclaracionJurada = new clsADDeclaracionJurada();

        public DataTable CNDatosTrabajador(int idCliente)
        {
            return objDeclaracionJurada.ADDatosTrabajador(idCliente);
        }

        public DataTable CNDatosPariente(int idCliente)
        {
            return objDeclaracionJurada.ADDatosPariente(idCliente);
        }

        public DataTable CNDatosFamiliares(int idCliente)
        {
            return objDeclaracionJurada.ADDatosFamiliares(idCliente);
        }

    }
}
