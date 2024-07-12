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
    public class clsADNotaSalida
    {
        clsGENEjeSP objEjesp = new clsGENEjeSP();

        public clsNotaSalida ADNotaSalida(int idNotaSalida)
        {            
            DataTable dtResult = objEjesp.EjecSP("LOG_BuscarNotaSalida_sp", idNotaSalida);
            if (dtResult.Rows.Count == 0) 
                return null;

            clsNotaSalida objNotaSalida = MapeaTablaEntidadNotaSalida(dtResult).First();
            dtResult = objEjesp.EjecSP("LOG_ListarDetNotasalida_sp", idNotaSalida);
            objNotaSalida.LstDetNotSalida = MapeaTablaEntidadDetNotaSalida(dtResult);
            return objNotaSalida;
        }

        public List<clsNotaSalida> ADListNotaSalida(int idNotaSalida, DateTime dFechaIni, DateTime dFechaFin,
                                                    int idAgencia, string cEstado, int idUsuario)
        {
            DataTable dtResult = objEjesp.EjecSP("LOG_ListarNotaSalida_SP", idNotaSalida, dFechaIni, dFechaFin,
                                                idAgencia, cEstado, idUsuario);
            if (dtResult.Rows.Count == 0)
                return new List<clsNotaSalida>();
            List<clsNotaSalida> lstNotaSalida = MapeaTablaEntidadNotaSalida(dtResult);
            foreach (clsNotaSalida objNotSal in lstNotaSalida)
            {
                dtResult = objEjesp.EjecSP("LOG_ListarDetNotasalida_sp", objNotSal.idNotaSalida);
                objNotSal.LstDetNotSalida = MapeaTablaEntidadDetNotaSalida(dtResult);
            }
            return lstNotaSalida;
        }

        public clsDBResp ADGuardarNotaSalida(clsNotaSalida objNotaSalida)
        {
            int idNotaSalida = objNotaSalida.idNotaSalida; 
            int idActividadLog = objNotaSalida.idActividadLog;
            int idDestinoPed = objNotaSalida.idDestinoPedido;
            int idAlmacen = objNotaSalida.idAlmacen;
            int idUsuarioSol = objNotaSalida.idUsuReg;
            int idArea = objNotaSalida.idArea;
            int idAgencia = objNotaSalida.idAgenciaReg;
            DateTime dFechaRegistro = objNotaSalida.dFechaRegistro;
            int idEstadoLog = objNotaSalida.idEstadoLog;
            string cSustento = objNotaSalida.cSustento;
            string xmldetalleNS = objNotaSalida.LstDetNotSalida.GetXml<clsDetNotaSalida>();
            DataTable dtResult = objEjesp.EjecSP("LOG_GuardarNotaSalida_sp", idNotaSalida, idActividadLog, idDestinoPed, idAlmacen, idUsuarioSol,
                                             idArea, idAgencia, dFechaRegistro, idEstadoLog, cSustento, xmldetalleNS);
            clsDBResp objDBResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]),Convert.ToString(dtResult.Rows[0]["cMsje"]));
            objDBResp.idGenerado = Convert.ToInt32(dtResult.Rows[0]["idGenerado"]);
            return objDBResp;
        }

        public clsDBResp ADActualizarNotaSalida(clsNotaSalida objNotaSalida)
        {
            int idNotaSalida = objNotaSalida.idNotaSalida;
            int idActividadLog = objNotaSalida.idActividadLog;
            int idDestinoPed = objNotaSalida.idDestinoPedido;
            int idAlmacen = objNotaSalida.idAlmacen;
            int idArea = objNotaSalida.idArea;
            int idAgencia = objNotaSalida.idAgenciaReg;
            int idUsuarioSol = objNotaSalida.idUsuReg;
            DateTime dFechaRegistro = objNotaSalida.dFechaRegistro;
            int idEstadoLog = objNotaSalida.idEstadoLog;
            string cSustento = objNotaSalida.cSustento;
            string xmldetalleNS = objNotaSalida.LstDetNotSalida.GetXml<clsDetNotaSalida>();
            DataTable dtResult = objEjesp.EjecSP("LOG_GuardarNotaSalida_sp", idNotaSalida, idActividadLog,idDestinoPed, idAlmacen, idUsuarioSol,
                                        idArea, idAgencia, dFechaRegistro, idEstadoLog, cSustento, xmldetalleNS);
            clsDBResp objDBResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]),Convert.ToString(dtResult.Rows[0]["cMsje"]));
            objDBResp.idGenerado = Convert.ToInt32(dtResult.Rows[0]["idGenerado"]);
            return objDBResp;
        }

        public clsDBResp ADAprobDenegNotaSalida(clsNotaSalida objNotaSalida)
        {
            int idNotaSalida = objNotaSalida.idNotaSalida;
            int idEstLog = objNotaSalida.idEstadoLog;
            DateTime? dFechaAprob = objNotaSalida.dFechaAprobacion;
            int? idUsuAprob = objNotaSalida.idUsuAprob;
            int? idAgenciaAprob = objNotaSalida.idAgenciaAprob;
            string xmlDetalleNS = objNotaSalida.LstDetNotSalida.GetXml<clsDetNotaSalida>();
            DataTable dtResult = objEjesp.EjecSP("LOG_AprobDenegNotaSalida_SP", idNotaSalida, idEstLog, idAgenciaAprob, dFechaAprob, idUsuAprob, xmlDetalleNS);
            clsDBResp objDBResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]),Convert.ToString(dtResult.Rows[0]["cMsje"]));
            return objDBResp;
        }

        public clsDBResp ADAtenderNotaSalida(clsNotaSalida objNotaSalida/*,List<clsActivo> lstActivos*/)
        {
            //DataSet dsDetActivo = new DataSet("dsDetActivo");
            //DataTable dtDetActivo = new DataTable("Table1");
            //dtDetActivo.Columns.Add("idActivo", typeof(int));
            //dtDetActivo.Columns.Add("idUsuOrig", typeof(int));
            //dtDetActivo.Columns.Add("idAgenciaOrig", typeof(int));
            //dtDetActivo.Columns.Add("cTipModif", typeof(string));

            //foreach (var item in lstActivos)
            //{
            //    DataRow dr = dtDetActivo.NewRow();
            //    dr["idActivo"] = item.idActivo;
            //    dr["idUsuOrig"] = item.idUsuOrig;
            //    dr["idAgenciaOrig"] = item.idAgenciaOrig;
            //    dr["cTipModif"] = "I";
            //    dtDetActivo.Rows.Add(dr);
            //}

            //dsDetActivo.Tables.Add(dtDetActivo);

            //string xmlDetalleActivo = dsDetActivo.GetXml();
            //xmlDetalleActivo = "<?xml version='1.0' encoding='ISO-8859-1' standalone='no' ?>" + xmlDetalleActivo;
            //xmlDetalleActivo = xmlDetalleActivo.Replace("\r\n", "").Replace(Environment.NewLine, "");
            //dsDetActivo.Tables.Clear();

            List<clsNotaSalida> lstNotaSalida = new List<clsNotaSalida>();
            lstNotaSalida.Add(objNotaSalida);
            string xmlNotaSalida = lstNotaSalida.GetXml<clsNotaSalida>();

            DataTable dtResult = objEjesp.EjecSP("LOG_AtencionNotaSalida_SP", xmlNotaSalida/*, xmlDetalleActivo*/);
            clsDBResp objDBResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]), Convert.ToString(dtResult.Rows[0]["cMsje"]));
            return objDBResp;
        }

        public clsDBResp ADExtornoNotaSalida(int idKardex, DateTime dFecExtorno, int idUsuExtorno)
        {
            DataTable dtResult = objEjesp.EjecSP("LOG_ExtornoNotaSalida_SP", idKardex, dFecExtorno, idUsuExtorno);
            clsDBResp objDBResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]), Convert.ToString(dtResult.Rows[0]["cMsje"]));
            return objDBResp;
        }

        private List<clsNotaSalida> MapeaTablaEntidadNotaSalida(DataTable dtResult) 
        {
            List<clsNotaSalida> LstNotaSalida = new List<clsNotaSalida>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsNotaSalida objNotaSalida = new clsNotaSalida();
                objNotaSalida.idNotaSalida = Convert.ToInt32(row["idNotaSalida"]);
                objNotaSalida.idActividadLog = Convert.ToInt32(row["idActividadLog"]);
                objNotaSalida.idDestinoPedido = Convert.ToInt32(row["idDestinoPedido"]);
                objNotaSalida.cSustento = Convert.ToString(row["cSustento"]);
                if (row.Table.Columns.Contains("cActividadLog"))
                {
                    objNotaSalida.cActividadLog = Convert.ToString(row["cActividadLog"]);
                }
                objNotaSalida.idArea = Convert.ToInt32(row["idArea"]);
                if (row.Table.Columns.Contains("cArea"))
                {
                    objNotaSalida.cArea = Convert.ToString(row["cArea"]);
                }
                objNotaSalida.idAgenciaReg = Convert.ToInt32(row["idAgenciaReg"]);
                if(row.Table.Columns.Contains("cAgencia"))
                {
                    objNotaSalida.cAgenciaReg = Convert.ToString(row["cAgenciaReg"]);
                }

                objNotaSalida.idAgenAlmacen = Convert.ToInt32(row["idAgenAlmacen"]);
                if (row.Table.Columns.Contains("cNomAgenAlmacen"))
                {
                    objNotaSalida.cNomAgenAlmacen = Convert.ToString(row["cNomAgenAlmacen"]);
                }

                objNotaSalida.idAlmacen = Convert.ToInt32(row["idAlmacen"]);   
                if(row.Table.Columns.Contains("cNombreAlmacen"))
                {
                    objNotaSalida.cNombreAlmacen = Convert.ToString(row["cNombreAlmacen"]);
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
                objNotaSalida.idAgenciaAprob = row["idAgenciaAprob"] == DBNull.Value?(int?)null: Convert.ToInt32(row["idAgenciaAprob"]);
                if (row.Table.Columns.Contains("cUsuAprob"))
                {
                    objNotaSalida.cUsuAprob = Convert.ToString(row["cUsuAprob"]);
                }
                if (row.Table.Columns.Contains("idUsuAten"))
                {
                    objNotaSalida.idUsuAten = row["idUsuAten"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idUsuAten"]);
                }
                if (row.Table.Columns.Contains("cUsuAten"))
                {
                    objNotaSalida.cUsuAten = Convert.ToString(row["cUsuAten"]);
                }
                if (row.Table.Columns.Contains("dFechaAten"))
                {
                    objNotaSalida.dFechaAten = row["dFechaAten"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["dFechaAten"]);
                }
                if (row.Table.Columns.Contains("idAgenciaAten"))
                {
                    objNotaSalida.idAgenciaAten = row["idAgenciaAten"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idAgenciaAten"]);
                }
                //objNotaSalida.idDestinoPedido = Convert.ToInt32(row["idDestinoPedido"]);
                
                LstNotaSalida.Add(objNotaSalida);
            }
            return LstNotaSalida;
        }

        private List<clsDetNotaSalida> MapeaTablaEntidadDetNotaSalida(DataTable dtResult)
        {
            List<clsDetNotaSalida> LstDetNotaSalida = new List<clsDetNotaSalida>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsDetNotaSalida objDetNotaSalida = new clsDetNotaSalida();
                if (Convert.ToBoolean(row["lIndActivo"]))
                {
                    objDetNotaSalida.objCatalogo = new clsActivo();
                }

                objDetNotaSalida.idDetalleNotaSalida = Convert.ToInt32(row["idDetalleNotaSalida"]);
                objDetNotaSalida.objCatalogo.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objDetNotaSalida.objCatalogo.cProducto = Convert.ToString(row["cProducto"]);
                objDetNotaSalida.objCatalogo.nCantidadTotal = row["nCantidadTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nCantidadTotal"]);
                objDetNotaSalida.objCatalogo.nCantidadFisico = row["nCantidadFisico"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nCantidadFisico"]);
                objDetNotaSalida.objCatalogo.nCantidadVirtual = row["nCantidadVirtual"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nCantidadVirtual"]);
                //objDetNotaSalida.objCatalogo.nPrecioUnit = row["nPrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nPrecioUnitario"]);
                objDetNotaSalida.nCantidadSol = Convert.ToDecimal(row["nCantidadSol"]);
                objDetNotaSalida.nCantidadApro = Convert.ToDecimal(row["nCantidadApro"]);
                objDetNotaSalida.nCantidadAten = row["nCantidadAten"] == DBNull.Value ? 0 : Convert.ToDecimal(row["nCantidadAten"]);
                objDetNotaSalida.idUniMedida = Convert.ToInt32(row["idUniMedida"]);
                objDetNotaSalida.lVigente = Convert.ToBoolean(row["lVigente"]);
                objDetNotaSalida.cUnidMedida = Convert.ToString(row["cUnidad"]);
                objDetNotaSalida.objCatalogo.lIndActivo = Convert.ToBoolean(row["lIndActivo"]);
                //if (Convert.ToBoolean(row["lIndActivo"]))
                //{
                //    ((clsActivo)objDetNotaSalida.objCatalogo).idActivo = Convert.ToInt32(row["idActivo"]);
                //    ((clsActivo)objDetNotaSalida.objCatalogo).idUsuOrig = Convert.ToInt32(row["idUsuOrig"]);
                //    ((clsActivo)objDetNotaSalida.objCatalogo).idAgenciaOrig = Convert.ToInt32(row["idAgenciaOrig"]);
                //}

                LstDetNotaSalida.Add(objDetNotaSalida);
            }
            return LstDetNotaSalida;
        }

        public DataTable ADCargaNotaSalida(int idNotaSalida)
        {
            return objEjesp.EjecSP("LOG_CargaNotaSalida_SP", idNotaSalida);
        }
    }
}
