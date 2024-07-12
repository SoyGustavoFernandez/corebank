using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace ADM.AccesoDatos
{
    public class clsADAuditoriaTablas
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTablasNoAuditadas()
        {
            return objEjeSp.EjecSP("ADM_ListarTablasNoAuditadas_SP");
        }

        public DataTable ADListarTablasAuditadas()
        {
            return objEjeSp.EjecSP("ADM_ListarTablasAuditadas_SP");
        }

        public DataTable ADHabilitarAuditoriaTabla(string cNombreTabla)
        {
            return objEjeSp.EjecSP("ADM_HabilitarAuditoriaTabla_SP", cNombreTabla);
        }

        public DataTable ADDeshabilitarAuditoriaTablas(string cNombreTabla)
        {
            return objEjeSp.EjecSP("ADM_DeshabilitarAuditoriaTabla_SP", cNombreTabla);
        }

        public DataTable ADListarTablasDeAuditoria()
        {
            return objEjeSp.EjecSP("ADM_ListarTablasDeAuditoria_SP");
        }

        public DataTable ADVisualizarAuditoriaTabla(string cNombreTablaAudit, DateTime dFecInicial, DateTime dFecFinal)
        {
            return objEjeSp.EjecSP("ADM_VisualizarAuditoriaTabla_SP", cNombreTablaAudit, dFecInicial, dFecFinal);
        }
    }
}