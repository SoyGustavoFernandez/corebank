using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNConfigPlantillaImp
    {
        clsADConfigPlantillaImp objADConfigPlantilla = new clsADConfigPlantillaImp();

        public DataTable CNListarTipoPlantillaImpresion()
        {
            return objADConfigPlantilla.ADListarTipoPlantillaImpresion();
        }

        public DataTable CNObtenerRegistroPC(string cIdentificadorPC)
        {
            return objADConfigPlantilla.ADObtenerRegistroPC(cIdentificadorPC);
        }

        public DataTable CNActualizarTipoPlantillaImpresion(int idRegistro, int idTipoPlantillaImpresion)
        {
            return objADConfigPlantilla.ADActualizarTipoPlantillaImpresion(idRegistro, idTipoPlantillaImpresion);
        }
    }
}
