using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using GEN.Funciones;

namespace LOG.AccesoDatos
{
    public class clsADNotaEntrada
    {

        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public List<clsNotaEntrada> ListaNotasEntradaAlmacen(int idAmacen, DateTime dFecIni, DateTime dFecFin)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListaNotasEntradaAlmacen_SP", idAmacen, dFecIni, dFecFin);
            List<clsNotaEntrada> lstNotaEntrada = MapeaTablaEntidadNotaEntrada(dtResult);
            return lstNotaEntrada;
        }

        public List<clsNotaEntrada> ListaNotasEntradaAgencia(int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListaNotasEntradaAgencia_SP", idAgencia, dFecIni, dFecFin);
            List<clsNotaEntrada> lstNotaEntrada = MapeaTablaEntidadNotaEntrada(dtResult);
            return lstNotaEntrada;
        }

        public List<clsNotaEntrada> ListaNotasEntradaxOrdenCompra(int idOrden)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListaNotasEntradaxOrdenCompra_SP", idOrden);
            List<clsNotaEntrada> lstNotaEntrada = MapeaTablaEntidadNotaEntrada(dtResult);
            return lstNotaEntrada;
        }

        public List<clsNotaEntrada> ListaNotasEntradaxMovimiento(int idMovimiento, int idTipIngNotaEntrada)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListaNotasEntradaxMovimiento_SP", idMovimiento, idTipIngNotaEntrada);
            List<clsNotaEntrada> lstNotaEntrada = MapeaTablaEntidadNotaEntrada(dtResult);
            return lstNotaEntrada;
        }

        public List<clsDetalleNotaEntrada> ListDetalleNotaEntrada(int idNotaEntrada)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ListDetalleNotaEntrada_SP", idNotaEntrada);
            List<clsDetalleNotaEntrada> lstDetalleNotaEntrada = MapeaTablaEntidadDetalleNotaEntrada(dtResult);
            return lstDetalleNotaEntrada;
        }

        public DataTable ListarTipoIngresoNotaEntrada()
        {
            return objEjeSp.EjecSP("LOG_ListarTipIngNotaEntrada_SP");
        }

        public clsDBResp InsertarActualizarNotaEntrada(clsNotaEntrada objNotaEntrada)
        {
            List<clsNotaEntrada> lstNotaEntrada = new List<clsNotaEntrada>();
            lstNotaEntrada.Add(objNotaEntrada);
            string xmlNotaEntrada = lstNotaEntrada.GetXml<clsNotaEntrada>();
            string xml = xmlNotaEntrada;
            clsDBResp objDbResp = new clsDBResp();
            DataTable dtResult = objEjeSp.EjecSP("LOG_InsertarNotaEntrada_SP", xmlNotaEntrada);
            objDbResp.nMsje = Convert.ToInt16(dtResult.Rows[0]["nMsje"]);
            objDbResp.cMsje = Convert.ToString(dtResult.Rows[0]["cMsje"]);
            return objDbResp;
        }

        public clsDBResp ExtornarNotaEntrada(int idNotaEntrada, DateTime dFecExtorno,int idUsuExtorno)
        {
            DataTable dtResult = objEjeSp.EjecSP("LOG_ExtornoEntradaAlmacen_SP", idNotaEntrada, dFecExtorno, idUsuExtorno);
            clsDBResp objDbResp = new clsDBResp(Convert.ToInt16(dtResult.Rows[0]["nMsje"]),Convert.ToString(dtResult.Rows[0]["cMsje"]));
            return objDbResp;
        }

        private List<clsNotaEntrada> MapeaTablaEntidadNotaEntrada(DataTable dtResult)
        {
            List<clsNotaEntrada> lstNotaEntrada = new List<clsNotaEntrada>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsNotaEntrada objNotaEntrada = new clsNotaEntrada();

                objNotaEntrada.idOrden = row["idOrden"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idOrden"]);
                objNotaEntrada.idNotaEntrada = Convert.ToInt32(row["idNotaEntrada"]);
                objNotaEntrada.nNroDocumento = Convert.ToString(row["nNroDocumento"]);
                objNotaEntrada.idAgencia = Convert.ToInt16(row["idAgencia"]);
                objNotaEntrada.idAlmacen = Convert.ToInt32(row["idAlmacen"]);
                objNotaEntrada.idUsuario = Convert.ToInt32(row["idUsuario"]);
                objNotaEntrada.idProveedor = Convert.ToInt32(row["idProveedor"]);
                objNotaEntrada.idEstadoLog = Convert.ToInt32(row["idEstadoLog"]);
                objNotaEntrada.idTipIngNotaEntrada = Convert.ToInt32(row["idTipIngNotaEntrada"]);
                objNotaEntrada.nTotal = Convert.ToDecimal(row["nTotal"]);
                objNotaEntrada.nNroNotaEntrada = Convert.ToInt32(row["nNroNotaEntrada"]);
                objNotaEntrada.dFechaReg = Convert.ToDateTime(row["dFechaReg"]);
                objNotaEntrada.dFechaMod = row["dFechaMod"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["dFechaMod"]);
                objNotaEntrada.cMotivo = Convert.ToString(row["cMotivo"]);
                objNotaEntrada.cProveedor = Convert.ToString(row["cProveedor"]);
                objNotaEntrada.idComprobantePago = Convert.ToInt32(row["idComprobantePago"]);
                objNotaEntrada.idTrasferencias = row["idTrasferencias"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["idTrasferencias"]);
                objNotaEntrada.nSubTotal = Convert.ToDecimal(row["nSubTotal"]);
                objNotaEntrada.nMontoIGV = Convert.ToDecimal(row["nMontoIGV"]);
                objNotaEntrada.lIncluIGV = Convert.ToBoolean(row["lIncluIGV"]);

                lstNotaEntrada.Add(objNotaEntrada);
            }
            return lstNotaEntrada;
        }

        private List<clsDetalleNotaEntrada> MapeaTablaEntidadDetalleNotaEntrada(DataTable dtResult)
        {
            List<clsDetalleNotaEntrada> lstDetalleNotaEntrada = new List<clsDetalleNotaEntrada>();
            foreach (DataRow row in dtResult.Rows)
            {
                bool lIncluIGV = Convert.ToBoolean(row["lIncluIGV"]);
                clsDetalleNotaEntrada objDetalleNotaEntrada = new clsDetalleNotaEntrada();

                objDetalleNotaEntrada.nNum = Convert.ToInt32(row["nNum"]);
                objDetalleNotaEntrada.idNotaEntrada = Convert.ToInt32(row["idNotaEntrada"]);
                objDetalleNotaEntrada.nTotal = lIncluIGV ? Convert.ToDecimal(row["nSubTotal"]) * (1 + clsVarApl.dicVarGen["nIGV"]) : Convert.ToDecimal(row["nSubTotal"]);
                objDetalleNotaEntrada.idCatalogo = Convert.ToInt32(row["idCatalogo"]);
                objDetalleNotaEntrada.cProducto = Convert.ToString(row["cProducto"]);
                objDetalleNotaEntrada.cUnidad = Convert.ToString(row["cUnidad"]);
                objDetalleNotaEntrada.nCantidad = Convert.ToDecimal(row["nCantidad"]);
                objDetalleNotaEntrada.nPrecioUnitario = Convert.ToDecimal(row["nPrecioUnitario"]);
                objDetalleNotaEntrada.nSubTotal = Convert.ToDecimal(row["nSubTotal"]);

                lstDetalleNotaEntrada.Add(objDetalleNotaEntrada);
            }
            return lstDetalleNotaEntrada;
        }    

    }
}
