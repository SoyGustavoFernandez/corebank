using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;
using System.Data;

namespace LOG.AccesoDatos
{
    public class clsADActividadPerfil
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADCargarPerfilUsuario()
        {
            return objEjeSp.EjecSP("LOG_CargarPerfilUsuario_SP");
        }

        public DataTable ADCargarActividadLog(int idActividad, int lVigente)
        {
            return objEjeSp.EjecSP("LOG_CargarActividadLog_SP", idActividad, lVigente);
        }
        
        public DataTable ADCargarActividadLogAgencia(int idAgencia)
        {
            return objEjeSp.EjecSP("LOG_CargarActividadLogAgencia_SP", idAgencia);
        }

        public DataTable ADGuardarActLogPerfil(int idActByPerfil, int idperfil, int idActividadLog, bool @lvigente)
        {
            return objEjeSp.EjecSP("LOG_GuardarActLogPerfil_SP", idActByPerfil, idperfil, idActividadLog, @lvigente);
        }
    }
}
