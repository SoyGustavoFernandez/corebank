using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using EntityLayer;
using System.Data;

namespace LOG.CapaNegocio
{
    public class clsCNNotaPedido
    {
        public List<clsNotaPedido> BuscarNotaPedido(int idNotaPedido, DateTime dFechaIni, DateTime dFechaFin, int idAgenciaGen, int idEstado, int nOpcion)
        {
            return new clsADNotaPedido().buscarNotaPedido(idNotaPedido, dFechaIni, dFechaFin, idAgenciaGen, idEstado, nOpcion);
        }

        public List<clsNotaPedido> BuscarSolicitudProc3Nivel(int idNotaPedido, DateTime dFechaIni, DateTime dFechaFin, int idAgenciaGen, int idEstado, int nOpcion)
        {
            return new clsADNotaPedido().buscarSolicitudProc3Nivel(idNotaPedido, dFechaIni, dFechaFin, idAgenciaGen, idEstado, nOpcion);
        }

        public List<clsDetalleNotaPedido> buscarDetalleAtencionNotaPedido(int idNotaPedido, Boolean lIgv)
        {
            return new clsADNotaPedido().buscarDetalleAtencionNotaPedido(idNotaPedido, lIgv,true);
        }

        public List<clsDetalleNotaPedido> buscarDetalleSolicitudProc3Nivel(int idNotaPedido, Boolean lIgv)
        {
            return new clsADNotaPedido().buscarDetalleSolictudProc3Nivel(idNotaPedido, lIgv, true);
        }

        public List<clsDetalleNotaPedido> buscarDetalleNotaPedido(int idNotaPedido)
        {
            return new clsADNotaPedido().buscarDetalleNotaPedido(idNotaPedido, true);
        }

        public List<clsDetalleNotaPedido> buscarDetalleNotaPedidoGen(int idNotaPedido, bool lIgv)
        {
            return new clsADNotaPedido().buscarDetalleAdquisicionNotaPedido(idNotaPedido, lIgv, false);
        }

        public clsNotaPedido CNRetornaDatosNPbyID(int idNotaPedido)
        {
            return new clsADNotaPedido().ADRetornaDatosNPbyID(idNotaPedido);
        }

        public clsNotaPedido CNRetornaDatosNPbyIDGEN(int idNotaPedido)
        {
            return new clsADNotaPedido().ADRetornaDatosNPbyIDGEN(idNotaPedido);
        }

        public clsNotaPedido CNRetornaDatosNPConsolidado(int idNotaPedido)
        {
            return new clsADNotaPedido().ADRetornaDatosNPConsolidado(idNotaPedido);
        }

        public List<clsNotaPedido> buscaSeguimientoNP(DateTime dFecIni, DateTime dFecFin, int idAgencia, int idArea, int idTipoProceso, int idEstado)
        {
            return new clsADNotaPedido().buscarSeguimientoNP(dFecIni, dFecFin, idAgencia, idArea, idTipoProceso, idEstado);
        }

        public List<clsNotaPedido> buscarListaNotaPedido(int idNotaPedido)
        {
            return new clsADNotaPedido().buscarListaNotaPedido(idNotaPedido);
        }

        public clsDBResp CNGuardarNotaPedidoConsolidado(clsNotaPedido objNotaPedido)
        {
            return new clsADNotaPedido().ADGuardarNotaPedidoConsolidado(objNotaPedido);
        }

        public DataTable CNActualizarNotaPedidoConsolidado(Int32 idNotaPedido, DateTime dFechaMod, Int32 idAgencia, Int32 idArea, string cMotivoNotaPedido, Int32 idMoneda, Int32 idTipoPedido, Int32 idUsuMod,
                                              decimal nSubTotal, decimal nTotalCosto, decimal nTotalConvertido, bool lIncluImpuesto, decimal nIGV, decimal nMonTipoCambio, string tXmlNotaPedido,
                                               string tXmlItems)
        {
            return new clsADNotaPedido().ADActualizarNotaPedidoConsolidado(idNotaPedido, dFechaMod, idAgencia, idArea,
                                             cMotivoNotaPedido, idMoneda, idTipoPedido, idUsuMod,
                                             nSubTotal, nTotalCosto, nTotalConvertido, lIncluImpuesto, nIGV, nMonTipoCambio, tXmlNotaPedido,
                                              tXmlItems);
        }

        public clsDBResp CNGuardarNotaPedido(clsNotaPedido objNotaPedido)
        {
            return new clsADNotaPedido().ADGuardarNotaPedido(objNotaPedido);
        }

        public clsDBResp CNAprobarDenegarNotaPedido(clsNotaPedido objNotaPedido)
        {
            return new clsADNotaPedido().ADAprobarDenegarNotaPedido(objNotaPedido);
        }

        public clsDBResp CNAprobarDenegarSolicitudProc3Nivel(clsNotaPedido objNotaPedido)
        {
            return new clsADNotaPedido().ADAprobarDenegarSolicitudesProc3Nivel(objNotaPedido);
        }

        public List<clsEvaRequisitosMinimos> CNRetornaReqMin(int idNotaPedido)
        {
            return new clsADNotaPedido().ADRetornaReqMin(idNotaPedido);
        }

        #region Codigo sin llamadas

        public DataTable CNRetornaEstimacionPre(int idNotaPedido)
        {
            return new clsADNotaPedido().ADRetornaEstimacionPre(idNotaPedido);
        }

        public clslistaFactorPonderacion buscaFactoresPonderacion(int idTipoPedido)
        {
            return new clsADNotaPedido().buscaFactoresPonderacion(idTipoPedido);
        }    

        public DataTable buscarEstadoReqMinimo()
        {
            return new clsADNotaPedido().buscarEstadoReqMinimo();
        }

        #endregion

    }
}
