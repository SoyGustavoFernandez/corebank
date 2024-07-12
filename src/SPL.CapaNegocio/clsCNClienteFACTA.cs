using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SPL.AccesoDatos;

namespace SPL.CapaNegocio
{
    public class clsCNClienteFACTA
    {
        clsADClienteFacta adClienteFacta = new clsADClienteFacta();
        
        public DataTable CNActualizarClienteNaturalFacta(int idCli, Boolean lFacta, Boolean lAceptaResidenciaUS)
        {
            return adClienteFacta.CNActualizarClienteNaturalFacta(idCli, lFacta, lAceptaResidenciaUS);
        }

        public DataTable CNObtenerClienteFactaPorIdCli(int idCli)
        {
            return adClienteFacta.ADObtenerClienteFactaPorIdCli(idCli);
        }
    }
}
