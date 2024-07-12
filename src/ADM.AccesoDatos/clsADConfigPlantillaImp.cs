using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace ADM.AccesoDatos
{
    public class clsADConfigPlantillaImp
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTipoPlantillaImpresion()
        {
            return objEjeSp.EjecSP("ADM_ListarTipoPlantillaImpresion_SP");
        }

        public DataTable ADObtenerRegistroPC(string cIdentificadorPC)
        {
            return objEjeSp.EjecSP("ADM_ObtenerRegistroDatPC_SP", cIdentificadorPC);
        }

        public DataTable ADActualizarTipoPlantillaImpresion(int idRegistro, int idTipoPlantillaImpresion)
        {
            return objEjeSp.EjecSP("ADM_ActualizarPlantillaImpresion_SP", idRegistro, idTipoPlantillaImpresion);
        }
    }
}
