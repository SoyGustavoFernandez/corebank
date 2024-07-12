using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.AccesoDatos;
namespace GEN.CapaNegocio
{
    public class clsCNAdquisionesLogistica
    {
        clsADAdquisicionesLogistica adquiLog = new clsADAdquisicionesLogistica();
        public DataTable listarTipoProceso()
        {
            return adquiLog.buscarTipoProceso();
        }
        public DataTable listarEstadoProcesoAdj(int idOpcPro)
        {
            return adquiLog.buscarEstadoProcesoLog(idOpcPro);
        }
        public DataTable listarTipoEvalAdj()
        {
            return adquiLog.buscarTipoEvalAdj();
        }
        public DataTable listarEtapaCalendario(Int32 idTipoProceso)
        {
            return adquiLog.BuscarEtapasCalendario(idTipoProceso);
        }

        public DataTable listarTipoDocumentoAdj(int idTipoProceso, int idEtapaCal)
        {
            return adquiLog.BuscarTipoDocumentoAdj(idTipoProceso, idEtapaCal);
        }
        public DataTable listarTipoPedido()
        {
            return adquiLog.BuscarTipoPedido();
        }
        public DataTable listaUnidaMedida()
        {
            return adquiLog.BuscarUnidaMedia();
        }
        public DataTable listarTipoProcesoGeneral()
        {
            return adquiLog.buscarTipoProcesoGeneral();
        }

        public DataTable listarProveedoresProcAdq(int idProcAdq)
        {
            return adquiLog.listarProveedoresProcAdq(idProcAdq);
        }
    }
}
