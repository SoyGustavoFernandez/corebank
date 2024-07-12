using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace ADM.AccesoDatos
{
    public class clsADAuthObjetoForm
    {
        clsGENEjeSP objGENEjeSP = new clsGENEjeSP();

        public DataTable listarAuthObjetoForm(int idMenu, int idAgencia, int idEstablecimiento, int idPerfil, int idUsuario, int idSolicitud)
        {
            return objGENEjeSP.EjecSP("ADM_ListarAuthObjetoForm_SP", idMenu, idAgencia, idEstablecimiento, idPerfil, idUsuario, idSolicitud);
        }

    }
}
