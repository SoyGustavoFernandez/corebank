using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADActividadLog
    {
        public DataTable ADListaActividadLog(int idAgencia,int idPerfil)
        {
            return new clsGENEjeSP().EjecSP("LOG_ListarTipoActividadLog_sp", idAgencia, idPerfil);
        }
    }
}
