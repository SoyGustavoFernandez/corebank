using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;

namespace LOG.AccesoDatos
{
    public class clsADProcesoAdquisicion
    {
        clsGENEjeSP objEjesp = new clsGENEjeSP();

        public clsDBResp ADGuardarProcAdq(clsSolicitudProcesoAdquisicion objProcAdq)
        {
            int idProcAdq = objProcAdq.idProcAdq;
            int idUsuarioSol = objProcAdq.idUsuReg;
            int idArea = objProcAdq.idArea;
            int idAgencia = objProcAdq.idAgenciaReg;
            DateTime dFechaRegistro = objProcAdq.dFechaRegistro;
            int idEstadoLog = objProcAdq.idEstadoLog;
            int idMoneda = objProcAdq.idMoneda;
            string cSustento = objProcAdq.cSustento;
            string xmldetalleNS = objProcAdq.LstDetProcAdq.GetXml<clsDetProcesoAdquisicion>();
            DataTable dtResult = objEjesp.EjecSP("LOG_GuardarProcesoAdquisicionTercerNivel_SP", idProcAdq, idUsuarioSol, idArea, idAgencia, dFechaRegistro, idEstadoLog, cSustento, idMoneda, xmldetalleNS );
            clsDBResp objDBResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]), Convert.ToString(dtResult.Rows[0]["cMsje"]));
            objDBResp.idGenerado = Convert.ToInt32(dtResult.Rows[0]["idGenerado"]);
            return objDBResp;
        }

        public List<clsSolicitudProcesoAdquisicion> ADListProcesoAdquisicion(int idProcAdq, DateTime dFechaIni, DateTime dFechaFin,
                                                    int idAgencia, /*string cEstado*/ int idEstadoLog, int idUsuario)
        {
            DataTable dtResult = objEjesp.EjecSP("LOG_ListarProcesoAdquisicionTercerNivel_SP", idProcAdq, dFechaIni, dFechaFin,
                                                idAgencia, /*cEstado*/ idEstadoLog, idUsuario);
            if (dtResult.Rows.Count == 0)
                return new List<clsSolicitudProcesoAdquisicion>();
            List<clsSolicitudProcesoAdquisicion> lstNotaSalida = MapeaTablaEntidadNotaSalida(dtResult);
            foreach (clsSolicitudProcesoAdquisicion objNotSal in lstNotaSalida)
            {
                dtResult = objEjesp.EjecSP("LOG_ListarDetProcAdqTercerNiv_SP", objNotSal.idProcAdq);
                objNotSal.LstDetProcAdq = MapeaTablaEntidadDetNotaSalida(dtResult);
            }
            return lstNotaSalida;
        }

        private List<clsSolicitudProcesoAdquisicion> MapeaTablaEntidadNotaSalida(DataTable dtResult)
        {
            List<clsSolicitudProcesoAdquisicion> LstNotaSalida = new List<clsSolicitudProcesoAdquisicion>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsSolicitudProcesoAdquisicion objNotaSalida = new clsSolicitudProcesoAdquisicion();
                objNotaSalida.idProcAdq = Convert.ToInt32(row["idProcAdq"]);
                objNotaSalida.cSustento = Convert.ToString(row["cSustento"]);
                objNotaSalida.idMoneda = Convert.ToInt32(row["idMoneda"]);
                objNotaSalida.idArea = Convert.ToInt32(row["idArea"]);
                if (row.Table.Columns.Contains("cArea"))
                {
                    objNotaSalida.cArea = Convert.ToString(row["cArea"]);
                }
                objNotaSalida.idAgenciaReg = Convert.ToInt32(row["idAgencia"]);
                if (row.Table.Columns.Contains("cAgencia"))
                {
                    objNotaSalida.cAgenciaReg = Convert.ToString(row["cAgencia"]);
                }
                objNotaSalida.idEstadoLog = Convert.ToInt32(row["idEstadoLog"]);
                if (row.Table.Columns.Contains("cEstLog"))
                {
                    objNotaSalida.cEstLog = Convert.ToString(row["cEstLog"]);
                }
                objNotaSalida.idUsuReg = Convert.ToInt32(row["idUsuReg"]);
                objNotaSalida.dFechaRegistro = Convert.ToDateTime(row["dFechaRegistro"]);
                if (row.Table.Columns.Contains("cUsuReg"))
                {
                    objNotaSalida.cUsuReg = Convert.ToString(row["cUsuReg"]);
                }
                if (row.Table.Columns.Contains("idCli"))
                {
                    objNotaSalida.idCli = Convert.ToInt32(row["idCli"]);
                }
                objNotaSalida.idUsuAprob = row["idUsuAprob"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idUsuAprob"]);
                objNotaSalida.dFechaAprobacion = row["dFechaAprobacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["dFechaAprobacion"]);
                //objNotaSalida.idAgenciaAprob = row["idAgenciaAprob"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idAgenciaAprob"]);
                if (row.Table.Columns.Contains("cUsuAprob"))
                {
                    objNotaSalida.cUsuAprob = Convert.ToString(row["cUsuAprob"]);
                }

                if (row.Table.Columns.Contains("cNombreUsuReg"))
                {
                    objNotaSalida.cNombreUsuReg = Convert.ToString(row["cNombreUsuReg"]);
                }
                if (row.Table.Columns.Contains("cEstadoUsu"))
                {
                    objNotaSalida.cEstadoUsu = Convert.ToString(row["cEstadoUsu"]);
                }
                
               

                LstNotaSalida.Add(objNotaSalida);
            }
            return LstNotaSalida;
        }

        private List<clsDetProcesoAdquisicion> MapeaTablaEntidadDetNotaSalida(DataTable dtResult)
        {
            List<clsDetProcesoAdquisicion> LstDetNotaSalida = new List<clsDetProcesoAdquisicion>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsDetProcesoAdquisicion objDetNotaSalida = new clsDetProcesoAdquisicion();
                if (Convert.ToBoolean(row["lIndActivo"]))
                {
                    objDetNotaSalida.objCatalogo = new clsActivo();
                }

                objDetNotaSalida.idDetalleProcAdq = Convert.ToInt32(row["idDetProcAdq"]);
                objDetNotaSalida.objCatalogo.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objDetNotaSalida.objCatalogo.cProducto = Convert.ToString(row["cProducto"]);
                objDetNotaSalida.cDetalleProducto = Convert.ToString(row["cDetalleProducto"]);
                objDetNotaSalida.objCatalogo.nCantidadTotal = row["nCantidadTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nCantidadTotal"]);
                objDetNotaSalida.objCatalogo.nCantidadFisico = row["nCantidadFisico"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nCantidadFisico"]);
                objDetNotaSalida.objCatalogo.nCantidadVirtual = row["nCantidadVirtual"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nCantidadVirtual"]);
                //objDetNotaSalida.objCatalogo.nPrecioUnit = row["nPrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nPrecioUnitario"]);
                objDetNotaSalida.nCantidad = Convert.ToInt32(row["nCantidad"]);
                objDetNotaSalida.nPrecioRef = Convert.ToDecimal(row["nPrecioRef"]);
                objDetNotaSalida.nDiasRef = Convert.ToInt32(row["nDiasRef"]);
                objDetNotaSalida.nLineaCreditoRef = Convert.ToDecimal(row["nLineaCreditoref"]);
                
                
                objDetNotaSalida.idUniMedida = Convert.ToInt32(row["idUnidadMedida"]);
                objDetNotaSalida.lVigente = Convert.ToBoolean(row["lVigente"]);
                objDetNotaSalida.cUnidMedida = Convert.ToString(row["cUnidad"]);
                objDetNotaSalida.objCatalogo.lIndActivo = Convert.ToBoolean(row["lIndActivo"]);
                
                LstDetNotaSalida.Add(objDetNotaSalida);
            }
            return LstDetNotaSalida;
        }

        public clsDBResp ADGuardarPropuestaProcAdq(clsSolicitudProcesoAdquisicion objProcAdq, bool lIgv, int idTipoComprobante, string cObservacion)
        {
            int idProcAdq = objProcAdq.idProcAdq;
            int idUsuarioReg = objProcAdq.idUsuReg;
            int idProveedor = objProcAdq.idProveedor;

            int idPropuesta = 0;

            DateTime dFechaRegistro = objProcAdq.dFechaRegistro;
            
            string xmldetalleNS = objProcAdq.LstDetProcAdq.GetXml<clsDetProcesoAdquisicion>();
            DataTable dtResult = objEjesp.EjecSP("LOG_GuardarPropuestaProcAdqTercerNivel_SP", idPropuesta,idProcAdq, idProveedor, idUsuarioReg, dFechaRegistro, xmldetalleNS, lIgv, idTipoComprobante, cObservacion);
            clsDBResp objDBResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]), Convert.ToString(dtResult.Rows[0]["cMsje"]));
            objDBResp.idGenerado = Convert.ToInt32(dtResult.Rows[0]["idGenerado"]);
            return objDBResp;
        }

        public DataTable ADGetResultadosProcesoAdquisicion( int idProcAdq)
        {
            return objEjesp.EjecSP("LOG_ObtenerResultadosProcesoAdquision_SP", idProcAdq);
        }

        public clsDBResp ADGuardarResultadoProcAdq(string xmlResultado)
        {
            DataTable dtResult = objEjesp.EjecSP("LOG_GuardarResultadoProcAdqTercerNivel_SP", xmlResultado);
            clsDBResp objDBResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]), Convert.ToString(dtResult.Rows[0]["cMsje"]));
            return objDBResp;
        }

        public DataTable ADListarPropuestasProveedores(int idProcAdq)
        {
            return objEjesp.EjecSP("LOG_ListarPropuestasProcAdq_SP", idProcAdq);
        }

        public DataTable ADListarGanadoresProveedores(int idProcAdq)
        {
            return objEjesp.EjecSP("LOG_ListarGanadorProcAdq_SP", idProcAdq);
        }
    }
}
