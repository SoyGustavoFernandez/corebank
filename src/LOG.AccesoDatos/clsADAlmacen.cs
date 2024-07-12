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
    public class clsADAlmacen
    {

        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarAlmacenes()
        {
            return objEjeSp.EjecSP("LOG_ListaAlmacenes_SP");
        }

        //Lista Almecenes existentes por agencia
        public DataTable ListaAlmacenesxAgencia(int idAgencia)
        {
            return objEjeSp.EjecSP("LOG_ListarAlmacenxAgencia_SP", idAgencia);
        }

        public DataTable ADListarAlmacenAgencia(int idAgencia)
        {
            return objEjeSp.EjecSP("LOG_ListarAlmacenAgencia_SP", idAgencia);
        }

        public DataTable ADInsertarAlmacen(string cNombreAlmacen, int idAgencia, int IdEstablecimiento)
        {
            return objEjeSp.EjecSP("LOG_InsertarAlmacen_SP", cNombreAlmacen, idAgencia, IdEstablecimiento);
        }

        public DataTable ADActualizarAlmacen(int idAlmacen, string cNombreAlmacen, int idAgencia, int IdEstablecimiento)
        {
            return objEjeSp.EjecSP("LOG_ActualizarAlmacen_SP", idAlmacen, cNombreAlmacen, idAgencia, IdEstablecimiento);
        }

        public DataTable ADEliminarAlmacen(int idAlmacen)
        {
            return objEjeSp.EjecSP("LOG_EliminarAlmacen_SP", idAlmacen);
        }

        public DataTable ListaTransferenciasAlmacen(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("LOG_ListaTransferenciasAlmacen_SP", dFecIni, dFecFin);
        }

        //Lista Solicitud de Transferencias de Almecen de un usuario en determinada fecha
        public List<clsTransferenciaAlmacen> ListaSolicitudTransferencia(DateTime dFecIni, DateTime dFecFin,int idAlmacenOri,
                                                                            int idAlmacenDes,int idEstado)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_LisSolicitudTransAlmacen_SP", dFecIni, dFecFin,idAlmacenOri,idAlmacenDes,idEstado);
            List<clsTransferenciaAlmacen> lstTransferencias = MapeaTablaEntidadTransfAlmacen(dtResult);
            return lstTransferencias;
        }

        public clsDBResp ADGuardaTransferenciaAlmacen(clsTransferenciaAlmacen objTransfAlmacen)
        {
            List<clsTransferenciaAlmacen> lstTransfAlmacen = new List<clsTransferenciaAlmacen>();
            lstTransfAlmacen.Add(objTransfAlmacen);
            string xmlTransferencia = lstTransfAlmacen.GetXml<clsTransferenciaAlmacen>();
            DataTable dtResult = objEjeSp.EjecSP("LOG_GuardaTransferenciaAlmacen_SP", xmlTransferencia);
            clsDBResp objDbResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]), Convert.ToString(dtResult.Rows[0]["cMsje"]));
            return objDbResp;
        }

        public clsDBResp ActualizaTransferenciaAlmacen(clsTransferenciaAlmacen objTransferencia)
        {
            int idTrasferencias = objTransferencia.idTrasferencias;
            DateTime dFecTrans = clsVarGlobal.dFecSystem;
            int idUsuTranf = clsVarGlobal.User.idUsuario;
            int idEstado = objTransferencia.idEstado;
            DataTable dtResult = objEjeSp.EjecSP("LOG_ActualizaTransferenciaAlmacen_SP", idTrasferencias,dFecTrans,idUsuTranf,idEstado);
            clsDBResp objDbResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]), Convert.ToString(dtResult.Rows[0]["cMsje"]));
            return objDbResp;
        }

        public clsDBResp ExtornaTransferenciaAlmacen(int idKardex, DateTime dFecExtorno, int idUsuExtorno)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ExtornoTransferenciaAlmacen_SP", idKardex, dFecExtorno, idUsuExtorno);
            clsDBResp objDbResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]), Convert.ToString(dtResult.Rows[0]["cMsje"]));
            return objDbResp;
        }

        public List<clsDetTranfAlmacen> ListaDetalleTransferencia(int idTrasferencias)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListaDetalleTransferencia_SP", idTrasferencias);
            List<clsDetTranfAlmacen> lstDetTransferencias = MapeaTablaEntidadDetTranfAlmacen(dtResult);
            return lstDetTransferencias;
        }

        public List<clsDetTranfAlmacen> ListarDetTransfIngresoAlmacen(int idTrasferencias)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListarDetTransfIngresoAlmacen_SP", idTrasferencias);
            List<clsDetTranfAlmacen> lstDetTransferencias = MapeaTablaEntidadDetTranfAlmacen(dtResult);
            return lstDetTransferencias;        
        }

        //Lista Activos existentes en Almacen
        public DataTable ADListaActAlmacen(String cProducto, int idAlmacen)
        {
            return objEjeSp.EjecSP("LOG_ListaActivoxAlmacen_SP", cProducto, idAlmacen);
        }

        private List<clsTransferenciaAlmacen> MapeaTablaEntidadTransfAlmacen(DataTable dtResult)
        {
            List<clsTransferenciaAlmacen> lstTransferencias = new List<clsTransferenciaAlmacen>();
            foreach (DataRow row in dtResult.Rows)
            {
                var objTransf = new clsTransferenciaAlmacen();
                objTransf.idTrasferencias = Convert.ToInt32(row["idTrasferencias"]);
                objTransf.nItem = Convert.ToInt32(row["idTrasferencias"]);
                objTransf.dFechaRegistro = Convert.ToDateTime(row["dFechaRegistro"]);
                objTransf.cWinUser = Convert.ToString(row["cWinUser"]);
                objTransf.cAlmacenOri = Convert.ToString(row["cAlmacenOri"]);
                objTransf.cAlmacenDes = Convert.ToString(row["cAlmacenDes"]);
                objTransf.idEstado = Convert.ToInt16(row["idEstado"]);
                objTransf.cEstado = Convert.ToString(row["cEstado"]);
                objTransf.idAlmacenOri = Convert.ToInt32(row["idAlmacenOri"]);
                objTransf.idAlmacenDes = Convert.ToInt32(row["idAlmacenDes"]);
                objTransf.idAgenciaOri = Convert.ToInt32(row["idAgenciaOri"]);
                objTransf.idAgenciaDes = Convert.ToInt32(row["idAgenciaDes"]);
                objTransf.idUsuarioOri = Convert.ToInt32(row["idUsuarioOri"]);
                objTransf.idUsuarioDes = row["idUsuarioDes"] == DBNull.Value ? (int?) 0 : Convert.ToInt32(row["idUsuarioDes"]);
                objTransf.idMoneda = (row["idMoneda"] == DBNull.Value)?  0 : Convert.ToInt32(row["idMoneda"]);
                objTransf.cUsuDest = Convert.ToString(row["cUsuDest"]);
                lstTransferencias.Add(objTransf);
            }

            return lstTransferencias;
        }

        private List<clsDetTranfAlmacen> MapeaTablaEntidadDetTranfAlmacen(DataTable dtResult)
        {
            List<clsDetTranfAlmacen> lstDetTrans = new List<clsDetTranfAlmacen>();
            foreach (DataRow row in dtResult.Rows)
            {
                var objDetTrans = new clsDetTranfAlmacen();
                objDetTrans.nItem = Convert.ToInt16(row["nItem"]);
                objDetTrans.idTrasferencia = Convert.ToInt32(row["idTrasferencia"]);
                objDetTrans.objCatalogo = new clsCatalogo();
                objDetTrans.objCatalogo.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objDetTrans.objCatalogo.cProducto = Convert.ToString(row["cProducto"]);
                objDetTrans.objCatalogo.idUnidadAlmacenaje = Convert.ToInt32(row["idUnidadMedida"]);
                objDetTrans.objCatalogo.cUnidAlmacenaje = Convert.ToString(row["cUnidad"]);
                objDetTrans.nCantidad = Convert.ToDecimal(row["nCantidad"]);
                objDetTrans.objCatalogo.nCantidadVirtual = Convert.ToDecimal(row["nCantidadVirtual"]);
                objDetTrans.objCatalogo.idTipoBien = Convert.ToInt16(row["idTipoBien"]);
                objDetTrans.nCantidadEntrega = Convert.ToDecimal(row["nCantidadEntrega"]);
                objDetTrans.nPorEntregar = Convert.ToDecimal(row["nPorEntregar"]);
                objDetTrans.nPrecUni = Convert.ToDecimal(row["nPrecioUnitario"]);

                lstDetTrans.Add(objDetTrans);
            }
            return lstDetTrans;
        }

        public List<clsDetTransferenciasActivo> ADListaActivosPorUsuarioResponsable(string cSerie, int idAgencia, int idCatalogo, int idUsuario, int idMoneda)
        {
            DataTable dtResp = objEjeSp.EjecSP("LOG_ActivosPorResponsable_SP", cSerie, idAgencia, idCatalogo, idUsuario, idMoneda);
            List<clsDetTransferenciasActivo> obj = DataTableToList.ConvertTo<clsDetTransferenciasActivo>(dtResp) as List<clsDetTransferenciasActivo>;
            return obj;
        }

        public List<clsDetTransferenciasActivo> ADListaDetalleTransActivos(int idTransferencia)
        {
            DataTable dtResp = objEjeSp.EjecSP("LOG_ListaDetalleTransActivos_SP", idTransferencia);
            List<clsDetTransferenciasActivo> obj = DataTableToList.ConvertTo<clsDetTransferenciasActivo>(dtResp) as List<clsDetTransferenciasActivo>;
            return obj;
        }

        public List<clsActivo> ADObtenerActivosxTransferencia(int idTransferencia)
        {
            DataTable dtResp = objEjeSp.EjecSP("LOG_ObtenerActivosxTransferencia_SP", idTransferencia);
            List<clsActivo> obj = DataTableToList.ConvertTo<clsActivo>(dtResp) as List<clsActivo>;
            return obj;
        }

        public DataTable ADGetTransferencia(int idTransferencia)
        {
            return objEjeSp.EjecSP("LOG_ListaTransferenciasAlmacen_SP", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), idTransferencia);
        }

        public DataTable ADGetDetTransferencia(int idTransferencia)
        {
            return objEjeSp.EjecSP("LOG_ListaDetalleTransferencia_SP", idTransferencia);
        }

        public DataTable ADObtenerStockParaTransferir(string xmlCatalogo, int idAlmacen, int idMoneda)
        {
            return objEjeSp.EjecSP("LOG_ObtenerStockParaTransferencia_SP", xmlCatalogo, idAlmacen, idMoneda);
        }
    }
}
