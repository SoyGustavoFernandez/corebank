using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LOG.AccesoDatos;
using EntityLayer;

namespace LOG.CapaNegocio
{
    public class clsCNProcesoAdquisicion
    {
        private clsADProcesoAdquisicion clsADProcAdq = new clsADProcesoAdquisicion();
        public clsDBResp CNGuardarProcesoAdquisicion(clsSolicitudProcesoAdquisicion objProcAdq)
        {
            return clsADProcAdq.ADGuardarProcAdq(objProcAdq);
        }

        public clsSolicitudProcesoAdquisicion CNBuscarProcesoAdquisicion(int idProcAdq, int idEstadoLog)
        {
            DateTime dFechaIni = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            DateTime dFechaFin = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
            int idAgencia = 0;
            /*string cEstado = string.Format("{0},{1},{2}", Convert.ToInt16(EstLog.SOLICITADO), Convert.ToInt16(EstLog.APROBADO),
                                                            Convert.ToInt16(EstLog.ATENDIDO), Convert.ToInt16(EstLog.DENEGADO));*/

            List<clsSolicitudProcesoAdquisicion> lstNotaSalida = clsADProcAdq.ADListProcesoAdquisicion(idProcAdq, dFechaIni, dFechaFin, idAgencia, /*cEstado*/ idEstadoLog, clsVarGlobal.User.idUsuario);
            if (lstNotaSalida.Count == 0)
                return null;

            return lstNotaSalida.First();
        }

        public clsDBResp CNGuardarPropuestaProcesoAdquisicion(clsSolicitudProcesoAdquisicion objProcAdq, bool igv, int idTipoComprobante, string cObservacion)
        {
            return clsADProcAdq.ADGuardarPropuestaProcAdq(objProcAdq, igv, idTipoComprobante, cObservacion);
        }

        public DataTable CNGetResultadosProcesoAdquisicion( int idProcAdq)
        {
            return clsADProcAdq.ADGetResultadosProcesoAdquisicion(idProcAdq);
        }

        public clsDBResp CNGuardarResultadoProcesoAdquisicion(string xmlResultado)
        {
            return clsADProcAdq.ADGuardarResultadoProcAdq(xmlResultado);
        }

        public DataTable CNListarPropuestasProveedores(int idProcAdq)
        {
            return clsADProcAdq.ADListarPropuestasProveedores(idProcAdq);
        }

        public DataTable CNListarGanadoresProveedores(int idProcAdq)
        {
            return clsADProcAdq.ADListarGanadoresProveedores(idProcAdq);
        }


    }
}
