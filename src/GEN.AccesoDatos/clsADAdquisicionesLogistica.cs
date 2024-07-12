using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
namespace GEN.AccesoDatos
{
    public class clsADAdquisicionesLogistica
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable buscarTipoProceso()
        {
            return objEjeSp.EjecSP("LOG_ListarTipoProceso_SP");
        }
        public DataTable buscarEstadoProcesoLog(int idOpcPro)
        {
            return objEjeSp.EjecSP("LOG_ListarEstadoProcesLog_SP", idOpcPro);
        }
        public DataTable buscarTipoEvalAdj()
        {
            return objEjeSp.EjecSP("LOG_ListarTipoEvalAdj_SP");
        }

        public DataTable BuscarEtapasCalendario(Int32 idTipoProceso)
        {
            return objEjeSp.EjecSP("LOG_ListarEtapaCalenario_SP", idTipoProceso);
        }

        public DataTable BuscarTipoDocumentoAdj(int idTipoProceso, int idEtapaCal)
        {
            return objEjeSp.EjecSP("LOG_ListarTipoDocAdj_SP", idTipoProceso, idEtapaCal);
        }
        public DataTable BuscarTipoPedido()
        {
            return objEjeSp.EjecSP("LOG_ListaTipoPedido_sp");
        }
        public DataTable BuscarUnidaMedia()
        {
            return objEjeSp.EjecSP("LOG_ListarUnidad_SP");
        }
        public DataTable buscarTipoProcesoGeneral()
        {
            return objEjeSp.EjecSP("LOG_ListarTipoProcesoGeneral_SP");
        }

        public DataTable listarProveedoresProcAdq(int idProcAdq)
        {
            return objEjeSp.EjecSP("LOG_ListarProveedoresProcAdq_SP", idProcAdq);
        }
    }
}
