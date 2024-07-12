using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;
using GEN.Funciones;

namespace LOG.AccesoDatos
{
    public class clsADOrdenCompra
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public List<clsOrdenCompra> ListarOrdenes(DateTime dFecIni, DateTime dFecFin, int idAlmacen)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListarOrdenes_SP", dFecIni, dFecFin,idAlmacen);
            List<clsOrdenCompra> lstOrdenCompra = MapeaTablaEntidadOrdenCompra(dtResult);
            return lstOrdenCompra;
        }

        public clsOrdenCompra ListarOrdenesidOrden(int idOrden)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListarOrdenesidOrden_SP",idOrden);
            List<clsOrdenCompra> lstOrdenCompra = MapeaTablaEntidadOrdenCompra(dtResult);
            if(lstOrdenCompra.Count<=0) return null;
            return lstOrdenCompra.First();
        }

        public DataTable EliminarOrdenes(int idOrden)
        {
            return objEjeSp.EjecSP("LOG_EliminarOrdenes_SP");
        }

        public DataTable ActualizarOrden(int  idOrden,int idTipoOrden,int idTipoProceso,int	idEstadoLog,int	idProceso,
                                        bool lVigente,int idProveedor,int idMoneda,DateTime	dFechaEmision,decimal nMontoTotal,
                                        decimal	nMontoIGV,decimal nTipoCambio,int idFormaPago,int idAlmacenEntrega,string cLugarEntrega,
                                        string cObservacion,int	idUsuReg,int idUsuMod,DateTime dFechaReg,DateTime dFechaMod,int	idTipoPago)
        {
            return objEjeSp.EjecSP("LOG_ActualizarOrdenes_SP",idOrden,idTipoOrden,idTipoProceso,idEstadoLog,idProceso,
                                        lVigente,idProveedor,idMoneda,dFechaEmision,nMontoTotal,
                                        nMontoIGV,nTipoCambio,idFormaPago,idAlmacenEntrega,cLugarEntrega,
                                        cObservacion,idUsuReg,idUsuMod,dFechaReg,dFechaMod,idTipoPago);
        }

        public clsDBResp InsertarOrden(clsOrdenCompra objOrdenCompra)
        {
            List<clsOrdenCompra> lstOrdenCompra = new List<clsOrdenCompra>();
            lstOrdenCompra.Add(objOrdenCompra);
            string xmlOrdenCompra = lstOrdenCompra.GetXml<clsOrdenCompra>();
            clsDBResp objDbResp = new clsDBResp();
            DataTable dtResult = objEjeSp.EjecSP("LOG_InsertarOrdenes_SP", xmlOrdenCompra);
            objDbResp.nMsje = Convert.ToInt16(dtResult.Rows[0]["nMsje"]);
            objDbResp.cMsje = Convert.ToString(dtResult.Rows[0]["cMsje"]);
            objDbResp.idGenerado = Convert.ToInt16(dtResult.Rows[0]["idGenerado"]);
            return objDbResp;
        }

        public DataTable ListarTipoOrden()
        {
            return objEjeSp.EjecSP("LOG_ListarTipoOrden_SP");
        }

        public List<clsDetalleOrdenCompra> ListarDetalleOrden(int idOrden)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListarDetalleOrdenesidOrden_SP", idOrden, false);
            List<clsDetalleOrdenCompra> lstDetalleOrdenCompra  = MapeaTablaEntidadDetalleOrdenCompra(dtResult);
            return lstDetalleOrdenCompra;
        }

        private List<clsOrdenCompra> MapeaTablaEntidadOrdenCompra(DataTable dtResult)
        {
            List<clsOrdenCompra> lstOrdenCompra = new List<clsOrdenCompra>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsOrdenCompra objOrdenCompra = new clsOrdenCompra();

                objOrdenCompra.idOrden = Convert.ToInt32(row["idOrden"]);
                objOrdenCompra.idTipoOrden = Convert.ToInt32(row["idTipoOrden"]);
                objOrdenCompra.idTipoProceso = row["idTipoProceso"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idTipoProceso"]);
                objOrdenCompra.idEstadoLog = Convert.ToInt32(row["idEstadoLog"]);
                objOrdenCompra.idProceso = row["idProceso"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idProceso"]);
                objOrdenCompra.idProveedor = Convert.ToInt32(row["idProveedor"]);
                objOrdenCompra.cProveedor = Convert.ToString(row["cProveedor"]);
                objOrdenCompra.idMoneda = Convert.ToInt32(row["idMoneda"]);
                objOrdenCompra.cSimbolo = Convert.ToString(row["cSimbolo"]);
                objOrdenCompra.cMoneda = Convert.ToString(row["cMoneda"]);
                objOrdenCompra.dFechaEmision = Convert.ToDateTime(row["dFechaEmision"]);
                objOrdenCompra.nSubTotal = Convert.ToDecimal(row["nSubTotal"]);
                objOrdenCompra.nMontoTotal = Convert.ToDecimal(row["nMontoTotal"]);
                objOrdenCompra.nMontoIGV = Convert.ToDecimal(row["nMontoIGV"]);
                objOrdenCompra.nMonConvertido = Convert.ToDecimal(row["nMonConvertido"]);
                objOrdenCompra.nTipoCambio = Convert.ToDecimal(row["nTipoCambio"]);
                objOrdenCompra.idFormaPago = row["idFormaPago"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idFormaPago"]);
                objOrdenCompra.cLugarEntrega = Convert.ToString(row["cLugarEntrega"]);
                objOrdenCompra.cObservacion = Convert.ToString(row["cObservacion"]);
                objOrdenCompra.idUsuReg = Convert.ToInt32(row["idUsuReg"]);
                objOrdenCompra.dFechaReg = Convert.ToDateTime(row["dFechaReg"]);
                objOrdenCompra.idUsuMod = row["idUsuMod"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idUsuMod"]);
                objOrdenCompra.dFechaMod = row["dFechaMod"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["dFechaMod"]);
                objOrdenCompra.idTipoPago = Convert.ToInt32(row["idTipoPago"]);
                objOrdenCompra.idAgencia = Convert.ToInt32(row["idAgencia"]);
                objOrdenCompra.idAlmacenEntrega = Convert.ToInt32(row["idAlmacenEntrega"]);
                objOrdenCompra.lVigente = Convert.ToBoolean(row["lVigente"]);
                objOrdenCompra.idCli = Convert.ToInt32(row["idCli"]);
                objOrdenCompra.lIncluIGV = Convert.ToBoolean(row["lIncluIGV"]);
                objOrdenCompra.idNotaEntrada = Convert.ToInt32(row["idNotaEntrada"]);
                objOrdenCompra.cSustento = Convert.ToString(row["cSustento"]);
                lstOrdenCompra.Add(objOrdenCompra);
            }

            return lstOrdenCompra;
        }

        private List<clsDetalleOrdenCompra> MapeaTablaEntidadDetalleOrdenCompra(DataTable dtResult)
        {
            List<clsDetalleOrdenCompra> lstDetalleOrdenCompra = new List<clsDetalleOrdenCompra>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsDetalleOrdenCompra objDetalleOrdenCompra = new clsDetalleOrdenCompra();

                objDetalleOrdenCompra.nNum = Convert.ToInt16(row["nNum"]);
                objDetalleOrdenCompra.idOrden = Convert.ToInt32(row["idOrden"]);
                objDetalleOrdenCompra.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objDetalleOrdenCompra.cProducto = Convert.ToString(row["cProducto"]);
                objDetalleOrdenCompra.nCantidad = Convert.ToDecimal(row["nCantidad"]);
                objDetalleOrdenCompra.nPrecioUnitario = Convert.ToDecimal(row["nPrecioUnitario"]);
                objDetalleOrdenCompra.nSubTotal = Convert.ToDecimal(row["nSubTotal"]);
                objDetalleOrdenCompra.nPorEntregar = Convert.ToDecimal(row["nPorEntregar"]);
                objDetalleOrdenCompra.nCantidadEntrega = Convert.ToDecimal(row["nCantidadEntrega"]);
                objDetalleOrdenCompra.lIncluImpuesto = Convert.ToBoolean(row["lIncluImpuesto"]);
                objDetalleOrdenCompra.idNotaEntrada = Convert.ToInt32(row["idNotaEntrada"]);
                objDetalleOrdenCompra.nTotal = Convert.ToDecimal(row["nTotal"]);
                objDetalleOrdenCompra.cDesTipoUniMed = Convert.ToString(row["cDesTipoUniMed"]);
                objDetalleOrdenCompra.idTipoBien = Convert.ToInt16(row["idTipoBien"]);
                objDetalleOrdenCompra.idUnidad = Convert.ToInt16(row["idUnidad"]);

                lstDetalleOrdenCompra.Add(objDetalleOrdenCompra);
            }

            return lstDetalleOrdenCompra;
        }

        public DataTable ADListaOrdenComp(int nidorden)
        {
            return objEjeSp.EjecSP("LOG_RptListaOrdenCompra_SP", nidorden);
        }
        public DataTable ADListaDatosEmp(int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_ListaDatosEmpresa_SP", idAgencia);
        }
        public DataTable ADListarDetalleOrden(int idOrden, bool lFaltante)
        {
            return objEjeSp.EjecSP("LOG_ListarDetalleOrdenesidOrden_SP", idOrden, lFaltante);            
        }

        public DataTable ADProveedorBuenaPro(int idProceso)
        {
            return objEjeSp.EjecSP("LOG_ListarProveedorGanador_SP", idProceso);
        }

        public DataTable ADExisteOrdenCompraProceso(int idProceso, int idGrupo)
        {
            return objEjeSp.EjecSP("LOG_ExisteOrdenCompraProceso_SP", idProceso, idGrupo);
        }

        public DataTable ADExisteOrdenCompraNotaEntrada(int idOrden)
        {
            return objEjeSp.EjecSP("LOG_ValidarOrdenPedidoNotaEntrada_SP", idOrden);
        }

        public DataTable ADProveedorBuenaPro3Nivel(int idProceso)
        {
            return objEjeSp.EjecSP("LOG_ListarProveedorGanador3Nivel_SP", idProceso);
        }

        public clsDBResp ADAnularOrdenCompra(int idOrden, string cSustento)
        {
            clsDBResp objDbResp = new clsDBResp();
            DataTable dtResult = objEjeSp.EjecSP("LOG_AnularOrdenCompra_SP", idOrden, cSustento, clsVarGlobal.User.idUsuario);
            objDbResp.nMsje = Convert.ToInt16(dtResult.Rows[0]["nMsje"]);
            objDbResp.cMsje = Convert.ToString(dtResult.Rows[0]["cMsje"]);
            return objDbResp;
        }
    }
}
