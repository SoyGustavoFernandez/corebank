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
    public class clsADNotaPedido
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public List<clsNotaPedido> buscarNotaPedido(int idNotaPedido, DateTime dFechaIni, DateTime dFechaFin, 
                                                    int idAgenciaGen, int idEstado, int nOpcion)
        {
            List<clsNotaPedido> lstNotaPedido = new List<clsNotaPedido>();

            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_ListarNotaPedido_SP", idNotaPedido, dFechaIni, dFechaFin, idAgenciaGen, idEstado, nOpcion);
            lstNotaPedido = MapeaTablaEntidadNotaPedido(dtResult);

            return lstNotaPedido;
        }

        public List<clsNotaPedido> buscarSolicitudProc3Nivel(int idNotaPedido, DateTime dFechaIni, DateTime dFechaFin,
                                                    int idAgenciaGen, int idEstado, int nOpcion)
        {
            List<clsNotaPedido> lstNotaPedido = new List<clsNotaPedido>();

            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_ListarSolcitudProc3Nivel_SP", idNotaPedido, dFechaIni, dFechaFin, idAgenciaGen, idEstado, nOpcion);
            lstNotaPedido = MapeaTablaEntidadNotaPedido(dtResult);

            return lstNotaPedido;
        }

        public List<clsNotaPedido> buscarListaNotaPedido(int idNotaPedido)
        {
            List<clsNotaPedido> lstNotaPedido = new List<clsNotaPedido>();
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_ListarNotaPedidoConsolidado_SP", idNotaPedido);
            lstNotaPedido = MapeaTablaEntidadNotaPedido(dtResult);

            return lstNotaPedido;
        }

        public List<clsNotaPedido> buscarSeguimientoNP(DateTime dFecIni, DateTime dFecFin, int idAgencia,
                                                        int idArea, int idTipoProceso, int idEstado)
        {            
            List<clsNotaPedido> lstNotaPedido = new List<clsNotaPedido>();            
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_SeguimientoNP_SP", dFecIni, dFecFin, idAgencia, idArea, idTipoProceso, idEstado);
            lstNotaPedido = MapeaTablaEntidadNotaPedido(dtResult);

            return lstNotaPedido;
        }

        public clsNotaPedido ADRetornaDatosNPConsolidado(int idNotaPedido)
        {
            clsNotaPedido objNotaPedido = new clsNotaPedido();
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_RetornaNotaPedidoConsolidado_sp", idNotaPedido);
            if (dtResult.Rows.Count > 0)
            {
                objNotaPedido = MapeaTablaEntidadNotaPedido(dtResult).First();
                objNotaPedido.lstDetNotPedido = buscarDetalleNotaPedido(objNotaPedido.idNotaPedido, true);
            }
            return objNotaPedido;
        }

        public clsNotaPedido ADRetornaDatosNPbyID(int idNotaPedido)
        {
            clsNotaPedido objNotaPedido = new clsNotaPedido();
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_RetornaNotaPedidobyId_sp", idNotaPedido);
            if (dtResult.Rows.Count == 0)
            {
                return null;
            }
            objNotaPedido = MapeaTablaEntidadNotaPedido(dtResult).First(); 
            objNotaPedido.lstDetNotPedido = buscarDetalleNotaPedido(objNotaPedido.idNotaPedido, true);
             
            return objNotaPedido;
        }


        public clsNotaPedido ADRetornaDatosNPbyIDGEN(int idNotaPedido)
        {
            clsNotaPedido objNotaPedido = new clsNotaPedido();
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_RetornaNotaPedidobyId_sp", idNotaPedido);
            if (dtResult.Rows.Count == 0)
            {
                return null;
            }
            objNotaPedido = MapeaTablaEntidadNotaPedido(dtResult).First();
            objNotaPedido.lstDetNotPedido = buscarDetalleNotaPedido(objNotaPedido.idNotaPedido, false);
            
            return objNotaPedido;
        }

        public List<clsEvaRequisitosMinimos> buscarReqMinPedido(int idNotaPedido, int nItem)
        {
            DataTable dt = objEjeSp.EjecSP("LOG_ObtenerReqMinimosxDetallePedido_SP", idNotaPedido);

            List<clsEvaRequisitosMinimos> lListaReqMin =  new List<clsEvaRequisitosMinimos>();

            foreach (DataRow item in dt.Rows)
            {
                clsEvaRequisitosMinimos objReqMin = new clsEvaRequisitosMinimos();
                objReqMin.idDetalleNotaPedido = Convert.ToInt32(item["idDetalleNotaPedido"]);
                objReqMin.idReqMinimo = Convert.ToInt32(item["idReqMinimo"]);
                objReqMin.idTipoReqMinimo = Convert.ToInt32(item["idTipoReqMinimo"]);
                objReqMin.cSustento = Convert.ToString(item["cSustento"]);
                objReqMin.lVigente = Convert.ToBoolean(item["lVigente"]);
                objReqMin.lIndica = Convert.ToBoolean(item["lIndica"]);
                objReqMin.nItem = nItem;
                lListaReqMin.Add(objReqMin);
            }

            return lListaReqMin;
        }

        public List<clsDetalleNotaPedido> buscarDetalleAtencionNotaPedido(int idNotaPedido, Boolean lIgv,bool np = false)
        {
            List<clsDetalleNotaPedido> lstDetNotaPedido = new List<clsDetalleNotaPedido>();
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_ListarDetalleNotaPedido_SP", idNotaPedido);
            lstDetNotaPedido = MapeaTablaEntidadDetalleAtencionNotaPedido(dtResult, lIgv, np);
            
            return lstDetNotaPedido;
        }

        public List<clsDetalleNotaPedido> buscarDetalleSolictudProc3Nivel(int idNotaPedido, Boolean lIgv, bool np = false)
        {
            List<clsDetalleNotaPedido> lstDetNotaPedido = new List<clsDetalleNotaPedido>();
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_ListarDetallesSolicitudProc3Nivel_SP", idNotaPedido);
            lstDetNotaPedido = MapeaTablaEntidadDetalleAtencionNotaPedido(dtResult, lIgv, np);

            return lstDetNotaPedido;
        }

        public List<clsDetalleNotaPedido> buscarDetalleAdquisicionNotaPedido(int idNotaPedido, Boolean lIgv, bool np = false)
        {
            List<clsDetalleNotaPedido> lstDetNotaPedido = new List<clsDetalleNotaPedido>();
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_ListarDetalleNotaPedido_SP", idNotaPedido);
            lstDetNotaPedido = MapeaTablaEntidadDetalleAdquisicionNotaPedido(dtResult, lIgv, np);

            return lstDetNotaPedido;
        }

        public List<clsDetalleNotaPedido> buscarDetalleNotaPedido(int idNotaPedido, bool np = false)
        {
            List<clsDetalleNotaPedido> lstDetNotaPedido = new List<clsDetalleNotaPedido>();
            DataTable dtResult = new DataTable();
            dtResult = objEjeSp.EjecSP("LOG_ListarDetalleNotaPedido_SP", idNotaPedido);
            lstDetNotaPedido = MapeaTablaEntidadDetalleNotaPedido(dtResult, np);

            return lstDetNotaPedido;
        }

        public clsDBResp ADGuardarNotaPedido(clsNotaPedido objNotaPedido)
        {
            int idNotaPedido = objNotaPedido.idNotaPedido;
            DateTime dFechaReg = objNotaPedido.dFechaNotaPedido; 
            Int32 idAgencia = objNotaPedido.idAgenciaGen; 
            Int32 idArea = objNotaPedido.idAreGen; 
            int? idActividad = objNotaPedido.idActividad;
            string cMotivoNotaPedido = objNotaPedido.cMotivoNotaPedido;
            Int32 idMoneda = objNotaPedido.idMoneda;
            Int32 idTipoPedido = objNotaPedido.idTipoPedido;
            Int32 idUsuGen = objNotaPedido.idUsuarioGen;
            decimal nSubTotal = objNotaPedido.nSubTotal;
            decimal nTotalCosto = objNotaPedido.nTotalCosto;
            decimal nTotalConvertido = objNotaPedido.nTotalConvertido;
            bool lIncluImpuesto = objNotaPedido.lIncluImpuesto;
            decimal nIGV = objNotaPedido.nIGV;
            decimal nMonTipoCambio = objNotaPedido.nMonTipoCambio;
            string tXmlItems = objNotaPedido.lstDetNotPedido.GetXml<clsDetalleNotaPedido>();

            DataTable dtResult = new clsGENEjeSP().EjecSP("LOG_GuardaNotaPedido_sp", idNotaPedido, dFechaReg, idAgencia, idArea, 
                                                          idActividad,cMotivoNotaPedido, idMoneda, idTipoPedido, 
                                                          idUsuGen,nSubTotal, nTotalCosto, nTotalConvertido, 
                                                          lIncluImpuesto, nIGV, nMonTipoCambio,tXmlItems);

            clsDBResp objDbResp = new clsDBResp();
            objDbResp.idGenerado = Convert.ToInt32(dtResult.Rows[0]["idGenerado"]);
            objDbResp.nMsje = Convert.ToInt32(dtResult.Rows[0]["nMsje"]);
            objDbResp.cMsje = Convert.ToString(dtResult.Rows[0]["cMsje"]);

            return objDbResp;
        } 

        public clsDBResp ADAprobarDenegarNotaPedido(clsNotaPedido objNotaPedido)
        {
            int idNotPed = objNotaPedido.idNotaPedido;
            int idEstado = objNotaPedido.idEstadoLog;
            DateTime? dFecAprob = objNotaPedido.dFechaAprob;
            int? idUsuAprob = objNotaPedido.idUsuAprob;
            decimal? nTotalCostoAprob = objNotaPedido.nTotalCostoAprobado;
            decimal? nTotalConvertAprob = objNotaPedido.nTotalConvertAprob;
            decimal? nMonTipCam = objNotaPedido.nMonTipCambioAprob;
            string xmlDetNotPed = objNotaPedido.lstDetNotPedido.GetXml<clsDetalleNotaPedido>();
            clsDBResp objDbResp = new clsDBResp();
            DataTable dtResult =  new clsGENEjeSP().EjecSP("LOG_AproDenNotPed_Sp", idNotPed, idEstado, dFecAprob, idUsuAprob,
                                             nTotalCostoAprob, nTotalConvertAprob, nMonTipCam, xmlDetNotPed);
            objDbResp.nMsje = Convert.ToInt16(dtResult.Rows[0]["nMsje"]);
            objDbResp.cMsje = Convert.ToString(dtResult.Rows[0]["cMsje"]);
            return objDbResp;
        }

        public clsDBResp ADAprobarDenegarSolicitudesProc3Nivel(clsNotaPedido objNotaPedido)
        {
            int idNotPed = objNotaPedido.idNotaPedido;
            int idEstado = objNotaPedido.idEstadoLog;
            DateTime? dFecAprob = objNotaPedido.dFechaAprob;
            int? idUsuAprob = objNotaPedido.idUsuAprob;
            decimal? nTotalCostoAprob = objNotaPedido.nTotalCostoAprobado;
            decimal? nTotalConvertAprob = objNotaPedido.nTotalConvertAprob;
            decimal? nMonTipCam = objNotaPedido.nMonTipCambioAprob;
            string xmlDetNotPed = objNotaPedido.lstDetNotPedido.GetXml<clsDetalleNotaPedido>();
            clsDBResp objDbResp = new clsDBResp();
            DataTable dtResult = new clsGENEjeSP().EjecSP("LOG_AproDenSolicitudProc3Nivel_Sp", idNotPed, idEstado, dFecAprob, idUsuAprob,
                                             nTotalCostoAprob, nTotalConvertAprob, nMonTipCam, xmlDetNotPed);
            objDbResp.nMsje = Convert.ToInt16(dtResult.Rows[0]["nMsje"]);
            objDbResp.cMsje = Convert.ToString(dtResult.Rows[0]["cMsje"]);
            return objDbResp;
        }


        public clsDBResp ADGuardarNotaPedidoConsolidado(clsNotaPedido objNotaPedido)
        {
            int idNotaPedido = objNotaPedido.idNotaPedido;
            DateTime dFechaReg = objNotaPedido.dFechaNotaPedido; 
            Int32 idAgencia = objNotaPedido.idAgenciaGen;
            Int32 idArea = objNotaPedido.idAreGen;
            string cMotivoNotaPedido = objNotaPedido.cMotivoNotaPedido;
            Int32 idMoneda = objNotaPedido.idMoneda;
            Int32 idTipoPedido = objNotaPedido.idTipoPedido;
            Int32 idUsuGen = objNotaPedido.idUsuarioGen;
            decimal nSubTotal = objNotaPedido.nSubTotal;
            decimal nTotalCosto = objNotaPedido.nTotalCosto;                    
            decimal nTotalConvertido = objNotaPedido.nTotalConvertido;
            bool lIncluImpuesto = objNotaPedido.lIncluImpuesto;
            decimal nIGV = objNotaPedido.nIGV;
            decimal nMonTipoCambio = objNotaPedido.nMonTipoCambio;
            string tXmlNotaPedido = objNotaPedido.lstNotaPedidoConsolid.GetXml<clsNotaPedido>();
            string tXmlItems = objNotaPedido.lstDetNotPedido.GetXml<clsDetalleNotaPedido>();

            DataTable dtResult = new clsGENEjeSP().EjecSP("LOG_GuardaConolidadoNotaPedido_sp",idNotaPedido, dFechaReg, idAgencia, idArea, cMotivoNotaPedido, 
                                                                idMoneda, idTipoPedido, idUsuGen,nSubTotal, 
                                                              nTotalCosto, nTotalConvertido, lIncluImpuesto, nIGV, 
                                                              nMonTipoCambio, tXmlNotaPedido, tXmlItems);
            clsDBResp objDbResp = new clsDBResp();
            objDbResp.idGenerado = Convert.ToInt16(dtResult.Rows[0]["idGenerado"]);
            objDbResp.nMsje = Convert.ToInt16(dtResult.Rows[0]["nMsje"]);
            objDbResp.cMsje = Convert.ToString(dtResult.Rows[0]["cMsje"]);

            return objDbResp;
        }

        public DataTable ADActualizarNotaPedidoConsolidado(Int32 idNotaPedido, DateTime dFechaMod, Int32 idAgencia, 
                                                            Int32 idArea,string cMotivoNotaPedido, Int32 idMoneda, 
                                                            Int32 idTipoPedido, Int32 idUsuMod, decimal nSubTotal, 
                                                            decimal nTotalCosto, decimal nTotalConvertido, bool lIncluImpuesto, 
                                                            decimal nIGV, decimal nMonTipoCambio, string tXmlNotaPedido,
                                                            string tXmlItems)
        {
            return new clsGENEjeSP().EjecSP("LOG_ActualizarNotaPedidoConsolidado_sp", idNotaPedido, dFechaMod, cMotivoNotaPedido, idMoneda, idTipoPedido, idUsuMod, nSubTotal, nTotalCosto,
                                              nTotalConvertido, lIncluImpuesto, nIGV, nMonTipoCambio, tXmlNotaPedido,
                                              tXmlItems);
        }   

        public List<clsEvaRequisitosMinimos> ADRetornaReqMin(int idNotaPedido)
        {
            clsListaEvaRequisitosMinimos lstEvaReqMin = new clsListaEvaRequisitosMinimos();
            DataTable dt = new clsGENEjeSP().EjecSP("LOG_ListaReqMinXNotaPed_sp", idNotaPedido);

            foreach (DataRow item in dt.Rows)
            {
                lstEvaReqMin.Add(new clsEvaRequisitosMinimos()
                {
                    idReqMinimo = Convert.ToInt32(item["idReqMinimo"]),
                    idDetalleNotaPedido = Convert.ToInt32(item["idDetalleNotaPedido"]),
                    idTipoReqMinimo = Convert.ToInt32(item["idTipoReqMinimo"]),
                    nItem = Convert.ToInt32(item["nItem"]),
                    cSustento = item["cSustento"].ToString(),
                    cTipoReqMinimo = item["cTipoReqMinimo"].ToString(),
                    lIndica = true,
                    lVigente = Convert.ToBoolean(item["lVigente"])
                });

            }

            return lstEvaReqMin;
        }

        private List<clsNotaPedido> MapeaTablaEntidadNotaPedido(DataTable dtResult)
        {
            List<clsNotaPedido> lstNotaPedido = new List<clsNotaPedido>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsNotaPedido objNotaPedido = new clsNotaPedido();
                objNotaPedido.idNotaPedido = Convert.ToInt32(row["idNotaPedido"]);
                objNotaPedido.dFechaNotaPedido = Convert.ToDateTime(row["dFechaNotaPedido"]);
                objNotaPedido.idAgenciaGen = Convert.ToInt32(row["idAgenciaGen"]);
                objNotaPedido.idAreGen = Convert.ToInt32(row["idAreGen"]);
                objNotaPedido.idActividad = (row["idActividad"] == DBNull.Value) ? (int?)null : Convert.ToInt32(row["idActividad"]);
                objNotaPedido.cMotivoNotaPedido = Convert.ToString(row["cMotivoNotaPedido"]);
                objNotaPedido.idEstadoLog = Convert.ToInt32(row["idEstadoLog"]);
                objNotaPedido.idMoneda = Convert.ToInt32(row["idMoneda"]);
                objNotaPedido.idTipoPedido = Convert.ToInt32(row["idTipoPedido"]);
                objNotaPedido.idUsuarioGen = Convert.ToInt32(row["idUsuarioGen"]);
                objNotaPedido.dFechaMod = (row["dFechaMod"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(row["dFechaMod"]);
                objNotaPedido.idUsuMod = (row["idUsuMod"] == DBNull.Value) ? (int?)null : Convert.ToInt32(row["idUsuMod"]);
                objNotaPedido.nTotalCosto = Convert.ToDecimal(row["nTotalCosto"]);
                objNotaPedido.nTotalConvertido = Convert.ToDecimal(row["nTotalConvertido"]);
                objNotaPedido.nIGV = Convert.ToDecimal(row["nIGV"]);
                objNotaPedido.nMonTipoCambio = Convert.ToDecimal(row["nMonTipoCambio"]);
                objNotaPedido.lIncluImpuesto = Convert.ToBoolean(row["nIncluImpuesto"]);
                objNotaPedido.cAgencia = Convert.ToString(row["cAgencia"]);
                objNotaPedido.cArea = Convert.ToString(row["cArea"]);
                objNotaPedido.cActividadLog = Convert.ToString(row["cActividadLog"]);
                objNotaPedido.cUsuarioGen = Convert.ToString(row["cUsuarioGen"]);
                objNotaPedido.cNombreEstado = Convert.ToString(row["cNombreEstado"]);
                objNotaPedido.cUsuarioApro = Convert.ToString(row["cUsuarioApro"]);
                objNotaPedido.lIndicaConsolidado = Convert.ToBoolean(row["lIndicaConsolidado"]);
                objNotaPedido.dFechaAprob = (row["dFechaAprob"] == DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(row["dFechaAprob"]);
                objNotaPedido.idCli = Convert.ToInt32(row["idCli"]);
                
                lstNotaPedido.Add(objNotaPedido);      
            }
            return lstNotaPedido;
        }

        private List<clsDetalleNotaPedido> MapeaTablaEntidadDetalleAdquisicionNotaPedido(DataTable dtResult, Boolean lIgv, bool lGen = false)
        {
            List<clsDetalleNotaPedido> lstDetNotaPedido = new List<clsDetalleNotaPedido>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsDetalleNotaPedido objDetNotaPedido = new clsDetalleNotaPedido();
                objDetNotaPedido.idDetalleNotaPedido = Convert.ToInt32(row["idDetalleNotaPedido"]);
                objDetNotaPedido.idNotaPedido = Convert.ToInt32(row["idNotaPedido"]);
                objDetNotaPedido.nItem = Convert.ToInt32(row["nItem"]);
                objDetNotaPedido.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objDetNotaPedido.cUnidad = Convert.ToString(row["cNomCorto"]);
                objDetNotaPedido.idUnidad = Convert.ToInt32(row["idUnidadAlmacenaje"]);
                if (lGen != true)
                {
                    objDetNotaPedido.nCantidad = Convert.ToDecimal(row["nCantidadAprobada"]);
                }
                else
                {
                    objDetNotaPedido.nCantidad = Convert.ToDecimal(row["nCantidad"]);
                }

                objDetNotaPedido.nPrecioUnit = Convert.ToDecimal(row["nPrecioUnit"]);
                objDetNotaPedido.cProducto = Convert.ToString(row["cProducto"]);
                if (lGen != true)
                {
                    if (lIgv == true)
                    {
                        objDetNotaPedido.nSubTotal = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]) + Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]) * Convert.ToDecimal((0.18));
                    }
                    else {
                        objDetNotaPedido.nSubTotal = Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                    }
                }
                else
                {
                    objDetNotaPedido.nSubTotal = Convert.ToDecimal(row["nCantidad"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                }
                objDetNotaPedido.cEstado = Convert.ToString(row["cEstado"]);
                objDetNotaPedido.lVigente = Convert.ToBoolean(row["lVigente"]);
                objDetNotaPedido.idProveedor = (row["idProveedor"] == DBNull.Value) ? (int?)null : Convert.ToInt32(row["idProveedor"]);
                objDetNotaPedido.nCantApro = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]);

                if (lIgv == true)
                {
                    objDetNotaPedido.nSubTotApro = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]) + Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]) * Convert.ToDecimal((0.18));
                }
                else
                {
                    objDetNotaPedido.nSubTotApro = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                }


                lstDetNotaPedido.Add(objDetNotaPedido);
            }
            return lstDetNotaPedido;
        }

        private List<clsDetalleNotaPedido> MapeaTablaEntidadDetalleAtencionNotaPedido(DataTable dtResult, Boolean lIgv,bool lGen = false)
        {
            List<clsDetalleNotaPedido> lstDetNotaPedido = new List<clsDetalleNotaPedido>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsDetalleNotaPedido objDetNotaPedido = new clsDetalleNotaPedido();
                objDetNotaPedido.idDetalleNotaPedido = Convert.ToInt32(row["idDetalleNotaPedido"]);
                objDetNotaPedido.idNotaPedido = Convert.ToInt32(row["idNotaPedido"]);
                objDetNotaPedido.nItem = Convert.ToInt32(row["nItem"]);
                objDetNotaPedido.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objDetNotaPedido.cUnidad = Convert.ToString(row["cNomCorto"]);
                objDetNotaPedido.idUnidad = Convert.ToInt32(row["idUnidadAlmacenaje"]);
                if (lGen != true)
                {
                    objDetNotaPedido.nCantidad = Convert.ToDecimal(row["nCantidadAprobada"]);
                }
                else
                {
                    objDetNotaPedido.nCantidad = Convert.ToDecimal(row["nCantidad"]);
                }

                objDetNotaPedido.nPrecioUnit = Convert.ToDecimal(row["nPrecioUnit"]);
                objDetNotaPedido.cProducto = Convert.ToString(row["cProducto"]);
                if (lGen != true)
                {
                    objDetNotaPedido.nSubTotal = Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                }
                else
                {
                    objDetNotaPedido.nSubTotal = Convert.ToDecimal(row["nCantidad"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                }
                objDetNotaPedido.cEstado = Convert.ToString(row["cEstado"]);
                objDetNotaPedido.lVigente = Convert.ToBoolean(row["lVigente"]);
                objDetNotaPedido.idProveedor = (row["idProveedor"] == DBNull.Value) ? (int?)null : Convert.ToInt32(row["idProveedor"]);
                objDetNotaPedido.nCantApro = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]);

                if(lIgv == true)
                {
                    objDetNotaPedido.nSubTotApro = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]) + Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]) * Convert.ToDecimal((0.18));
                }else{
                    objDetNotaPedido.nSubTotApro = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                }
                

                lstDetNotaPedido.Add(objDetNotaPedido);
            }
            return lstDetNotaPedido;
        }

        private List<clsDetalleNotaPedido> MapeaTablaEntidadDetalleNotaPedido(DataTable dtResult, bool lGen = false)
        {
            List<clsDetalleNotaPedido> lstDetNotaPedido = new List<clsDetalleNotaPedido>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsDetalleNotaPedido objDetNotaPedido = new clsDetalleNotaPedido();
                objDetNotaPedido.idDetalleNotaPedido = Convert.ToInt32(row["idDetalleNotaPedido"]);
                objDetNotaPedido.idNotaPedido = Convert.ToInt32(row["idNotaPedido"]);
                objDetNotaPedido.nItem = Convert.ToInt32(row["nItem"]);
                objDetNotaPedido.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objDetNotaPedido.cUnidad = Convert.ToString(row["cNomCorto"]);
                objDetNotaPedido.idUnidad = Convert.ToInt32(row["idUnidadAlmacenaje"]);
                if(lGen != true)
                {
                    objDetNotaPedido.nCantidad = Convert.ToDecimal(row["nCantidadAprobada"]);
                }else{
                    objDetNotaPedido.nCantidad = Convert.ToDecimal(row["nCantidad"]);
                }
                
                objDetNotaPedido.nPrecioUnit = Convert.ToDecimal(row["nPrecioUnit"]);
                objDetNotaPedido.cProducto = Convert.ToString(row["cProducto"]);
                if (lGen != true)
                {
                    objDetNotaPedido.nSubTotal = Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                }
                else {
                    objDetNotaPedido.nSubTotal = Convert.ToDecimal(row["nCantidad"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                }
                objDetNotaPedido.cEstado = Convert.ToString(row["cEstado"]);
                objDetNotaPedido.lVigente = Convert.ToBoolean(row["lVigente"]);
                objDetNotaPedido.idProveedor = (row["idProveedor"] == DBNull.Value) ? (int?) null : Convert.ToInt32(row["idProveedor"]);
                objDetNotaPedido.nCantApro = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]);
                objDetNotaPedido.nSubTotApro = (row["nCantidadAprobada"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["nCantidadAprobada"]) * Convert.ToDecimal(row["nPrecioUnit"]);
                objDetNotaPedido.lstReqMin = buscarReqMinPedido(Convert.ToInt32(objDetNotaPedido.idDetalleNotaPedido), Convert.ToInt32(row["nItem"]));

                lstDetNotaPedido.Add(objDetNotaPedido);
            }
            return lstDetNotaPedido;
        }

        #region Codigo sin llamadas

        public DataTable ADRetornaEstimacionPre(int idNotaPedido)
        {
            return new clsGENEjeSP().EjecSP("LOG_ListaEstimacionPre_sp", idNotaPedido);
        }

        public clslistaFactorPonderacion buscaFactoresPonderacion(int idTipoPedido)
        {
            clslistaFactorPonderacion listFacPond = new clslistaFactorPonderacion();
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarFactorPonderacion_SP", idTipoPedido);
            int i = 0;
            foreach (DataRow item in ds.Rows)
            {
                listFacPond.Add(new clsFactorPonderacion()
                {
                    cFacPonderacion = item["cFacPonderacion"].ToString(),
                    idTipoFacPonderacion = Convert.ToInt32(item["idTipoFacPonderacion"].ToString()),
                    idGrupo = Convert.ToInt32(item["idGrupo"].ToString()),
                    idProceso = Convert.ToInt32(item["idProceso"].ToString()),
                    nEvaluacion = Convert.ToDecimal(item["nEvaluacion"].ToString()),
                    nEvaMax = Convert.ToDecimal(item["nEvaMax"].ToString()),
                    nEvaMin = Convert.ToDecimal(item["nEvaMin"].ToString()),
                    nEvaTotal = Convert.ToDecimal(item["nEvaTotal"].ToString()),
                    nFacMax = Convert.ToDecimal(item["nFacMax"].ToString()),
                    nFacMin = Convert.ToDecimal(item["nFacMin"].ToString()),
                    nFactibilidad = Convert.ToDecimal(item["nFactibilidad"].ToString()),
                    nTotal = Convert.ToDecimal(item["nTotal"].ToString())
                }
                );
                i += 1;
            }
            return listFacPond;
        } 

        public DataTable buscarEstadoReqMinimo()
        {
            DataTable ds = new DataTable();
            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            ds = objEjeSp.EjecSP("LOG_ListarEstadoReqMinimo_SP");
            return ds;
        }

        #endregion

    }
}
