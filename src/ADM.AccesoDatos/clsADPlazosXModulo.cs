using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADPlazosXModulo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarPlazos(int idModulo)
        {
            return objEjeSp.EjecSP("ADM_ListarPlazosXmod_sp", idModulo);
        }

        public void ActualizarPlazos(string XMLPlazos, int idMod, int idUsuario)
        {
            objEjeSp.EjecSP("ADM_ActualizarPlazos_sp", XMLPlazos, idMod, idUsuario);
        }
        public DataTable UsoPlazos(int idMonto)
        {
            return objEjeSp.EjecSP("ADM_ValidarUsoPlazo_sp", idMonto);
        }
    }
}
