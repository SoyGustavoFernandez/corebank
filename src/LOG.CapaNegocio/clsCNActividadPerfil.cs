using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using System.Data;

namespace LOG.CapaNegocio
{
    public class clsCNActividadPerfil
    {
        clsADActividadPerfil objActPerf = new clsADActividadPerfil();

        public DataTable CNCargarPerfilUsuario()
        {
            return objActPerf.ADCargarPerfilUsuario();
        }
        
        public DataTable CNCargarActividadLog(int idActividad, int lVigente)
        {
            return objActPerf.ADCargarActividadLog(idActividad, lVigente);
        }

        public DataTable CNCargarActividadLogAgencia(int idAgencia)
        {
            return objActPerf.ADCargarActividadLogAgencia(idAgencia);
        }

        public DataTable CNGuardarActLogPerfil(int idActByPerfil, int idperfil, int idActividadLog, bool @lvigente)
        {
            return objActPerf.ADGuardarActLogPerfil(idActByPerfil, idperfil, idActividadLog, @lvigente);
        }
    }
}
