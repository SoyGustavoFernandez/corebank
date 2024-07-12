using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADMontosXModulo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarMontos(int idModulo)
        {
            return objEjeSp.EjecSP("ADM_ListarMontosXmod_sp", idModulo);
        }

        public void ActualizarMontos(string XMLMontos, int idMod,  int idUsuario)
        {
            objEjeSp.EjecSP("ADM_ActualizarMontos_sp", XMLMontos, idMod, idUsuario);
        }
        public DataTable UsoMontos(int idMonto)
        {
            return objEjeSp.EjecSP("ADM_ValidarUsoMonto_sp", idMonto);
        }
    }
}
