using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace LOG.AccesoDatos
{
    public class clsADTipoActividades
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADMostrarTipoActividades()
        {
            return objEjeSp.EjecSP("LOG_RetornaTipActividades_SP");
        }

        public DataTable ADGrabarActividadLogistica(int idActivLog, int idAgencia, int idArea, int idTipActLog, string descripcion, bool lvigente)
        {
            return objEjeSp.EjecSP("LOG_GrabarActividadLogistica_SP", idActivLog, idAgencia, idArea, idTipActLog, descripcion, lvigente);
        }
    }
}
