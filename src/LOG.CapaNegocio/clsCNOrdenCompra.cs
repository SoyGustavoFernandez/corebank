using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using EntityLayer;

namespace LOG.CapaNegocio
{
    public  class clsCNOrdenCompra
    {
        clsADOrdenCompra adordencompra = new clsADOrdenCompra();

        public List<clsOrdenCompra> ListarOrdenes(DateTime dFecIni, DateTime dFecFin, int idAlmacen)
        {
            return adordencompra.ListarOrdenes(dFecIni, dFecFin, idAlmacen);
        }

        public clsOrdenCompra ListarOrdenesidOrden(int idOrden)
        {
            return adordencompra.ListarOrdenesidOrden(idOrden);
        }

        public DataTable EliminarOrdenes(int idOrden)
        {
            return adordencompra.EliminarOrdenes(idOrden);
        }

        public DataTable ActualizarOrden(int idOrden, int idTipoOrden, int idTipoProceso, int idEstadoLog, int idProceso,
                                        bool lVigente, int idProveedor, int idMoneda, DateTime dFechaEmision, decimal nMontoTotal,
                                        decimal nMontoIGV, decimal nTipoCambio, int idFormaPago, int idAlmacenEntrega, string cLugarEntrega,
                                        string cObservacion, int idUsuReg, int idUsuMod, DateTime dFechaReg, DateTime dFechaMod, int idTipoPago)
        {
            return adordencompra.ActualizarOrden(idOrden, idTipoOrden, idTipoProceso, idEstadoLog, idProceso,
                                        lVigente, idProveedor, idMoneda, dFechaEmision, nMontoTotal,
                                        nMontoIGV, nTipoCambio, idFormaPago, idAlmacenEntrega, cLugarEntrega,
                                        cObservacion, idUsuReg, idUsuMod, dFechaReg, dFechaMod, idTipoPago);
        }

        public clsDBResp InsertarOrden(clsOrdenCompra objOrdenCompra)
        {
            return adordencompra.InsertarOrden(objOrdenCompra);
        }

        public DataTable ListarTipoOrden()
        {
            return adordencompra.ListarTipoOrden();
        }

        public List<clsDetalleOrdenCompra> ListarDetalleOrden(int idOrden)
        {
            return adordencompra.ListarDetalleOrden(idOrden);
        }
        public DataTable CNListaOrdenComp(int nidorden)
        {
            return adordencompra.ADListaOrdenComp(nidorden);
        }
        public DataTable CNListaDatosEmp(int idAgencia)
        {
            return adordencompra.ADListaDatosEmp(idAgencia);
        }
        public DataTable CNListarDetalleOrden(int idOrden, bool lFaltante = false)
        {
            return adordencompra.ADListarDetalleOrden(idOrden, lFaltante);
        }

        public DataTable CNProveedorBuenaPro(int idProceso)
        {
            return adordencompra.ADProveedorBuenaPro(idProceso);
        }

        public DataTable CNExisteOrdenCompraProceso(int idProceso, int idGrupo)
        {
            return adordencompra.ADExisteOrdenCompraProceso(idProceso, idGrupo);
        }

        public DataTable CNExisteOrdenCompraNotaEntrada(int idOrden)
        {
            return adordencompra.ADExisteOrdenCompraNotaEntrada(idOrden);
        }

        public DataTable CNProveedorBuenaPro3Nivel(int idProceso)
        {
            return adordencompra.ADProveedorBuenaPro3Nivel(idProceso);
        }

        public clsDBResp CNAnularOrdenCompra(int idOrden, string cSustento)
        {
            return adordencompra.ADAnularOrdenCompra(idOrden, cSustento);
        }
    }
}
