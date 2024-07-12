using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNAuditoriaTablas
    {
        clsADAuditoriaTablas objAuditoria = new clsADAuditoriaTablas();

        public DataTable CNListarTablasNoAuditadas()
        {
            return objAuditoria.ADListarTablasNoAuditadas();
        }

        public DataTable CNListarTablasAuditadas()
        {
            return objAuditoria.ADListarTablasAuditadas();
        }

        public DataTable CNHabilitarAuditoriaTabla(string cNombreTabla)
        {
            return objAuditoria.ADHabilitarAuditoriaTabla(cNombreTabla);
        }

        public DataTable CNDeshabilitarAuditoriaTablas(string cNombreTabla)
        {
            return objAuditoria.ADDeshabilitarAuditoriaTablas(cNombreTabla);
        }

        public DataTable CNListarTablasDeAuditoria()
        {
            return objAuditoria.ADListarTablasDeAuditoria();
        }

        public DataTable CNVisualizarAuditoriaTabla(string cNombreTablaAudit, DateTime dFecInicial, DateTime dFecFinal)
        {
            return objAuditoria.ADVisualizarAuditoriaTabla(cNombreTablaAudit, dFecInicial, dFecFinal);
        }
    }
}
