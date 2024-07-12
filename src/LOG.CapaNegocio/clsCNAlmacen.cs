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
   
    public class clsCNAlmacen
    {
        clsADAlmacen adAlmacen = new clsADAlmacen();
        
        public DataTable ListarAlmacenes()
        {
            return adAlmacen.ListarAlmacenes();
        }

        public DataTable CNListarAlmacenAgencia(int idAgencia)
        {
            return adAlmacen.ADListarAlmacenAgencia(idAgencia);
        }

        public DataTable CNInsertarAlmacen(string cNombreAlmacen, int idAgencia, int IdEstablecimiento)
        {
            return adAlmacen.ADInsertarAlmacen(cNombreAlmacen, idAgencia,IdEstablecimiento);
        }

        public DataTable CNActualizarAlmacen(int idAlmacen, string cNombreAlmacen, int idAgencia, int IdEstablecimiento)
        {
            return adAlmacen.ADActualizarAlmacen(idAlmacen, cNombreAlmacen, idAgencia,IdEstablecimiento);
        }

        public DataTable CNEliminarAlmacen(int idAlmacen)
        {
            return adAlmacen.ADEliminarAlmacen(idAlmacen);
        }

        public DataTable ListaTransferenciasAlmacen(DateTime dFecIni, DateTime dFecFin)
        {
            return adAlmacen.ListaTransferenciasAlmacen(dFecIni, dFecFin);
        }

        public List<clsDetTranfAlmacen> ListaDetalleTransferencia(int idTrasferencias)
        {
            return adAlmacen.ListaDetalleTransferencia(idTrasferencias);
        }

        public List<clsDetTranfAlmacen> ListarDetTransfIngresoAlmacen(int idTrasferencias)
        {
            return adAlmacen.ListarDetTransfIngresoAlmacen(idTrasferencias);
        }

        public clsDBResp CNGuardaTransferenciaAlmacen(clsTransferenciaAlmacen objTransfAlmacen)
        {
            return adAlmacen.ADGuardaTransferenciaAlmacen(objTransfAlmacen);
        }

        public clsDBResp ActualizaTransferenciaAlmacen(clsTransferenciaAlmacen objTransferencia)
        {
            return adAlmacen.ActualizaTransferenciaAlmacen(objTransferencia);
        }

        public clsDBResp ExtornaTransferenciaAlmacen(int idKardex, DateTime dFecExtorno, int idUsuExtorno)
        {
            return adAlmacen.ExtornaTransferenciaAlmacen(idKardex, dFecExtorno, idUsuExtorno);
        }

        //Lista Almecenes existentes por agencia
        public DataTable CNListaAlmacenesxAgencia(int idAgencia)
        {
            return adAlmacen.ListaAlmacenesxAgencia(idAgencia);
        }

        //Lista Solicitud de Transferencias de Almecen de un usuario en determinada fecha
        public List<clsTransferenciaAlmacen> CNListaSolicitudTransferencia(DateTime dFecIni, DateTime dFecFin, int idAlmacenOri, 
                                                                            int idAlmacenDes, int idEstado)
        {
            return adAlmacen.ListaSolicitudTransferencia(dFecIni, dFecFin, idAlmacenOri,idAlmacenDes, idEstado);
        }

        //Lista Activos existentes en Almacen
        public DataTable CNListaActAlmacen(String cProducto, int idAlmacen)
        {
            return adAlmacen.ADListaActAlmacen(cProducto, idAlmacen);
        }

        public List<clsDetTransferenciasActivo> CNListaActivosPorUsuarioResponsable(string cSerie, int idAgencia, int idCatalogo, int idUsuario, int idMoneda)
        {
            return adAlmacen.ADListaActivosPorUsuarioResponsable(cSerie, idAgencia, idCatalogo, idUsuario, idMoneda);
        }

        public List<clsDetTransferenciasActivo> CNListaDetalleTransActivos(int idTransferencia)
        {
            return adAlmacen.ADListaDetalleTransActivos(idTransferencia);
        }

        public List<clsActivo> CNObtenerActivosxTransferencia(int idTransferencia)
        {
            return adAlmacen.ADObtenerActivosxTransferencia(idTransferencia);
        }

        public DataTable CNGetTransferencia(int idTransferencia)
        {
            return adAlmacen.ADGetTransferencia(idTransferencia);
        }

        public DataTable CNGetDetTransferencia(int idTransferencia)
        {
            return adAlmacen.ADGetDetTransferencia(idTransferencia);
        }

        public DataTable CNObtenerStockParaTransferir(string xmlCatalogo, int idAlmacen, int idMoneda)
        {
            return adAlmacen.ADObtenerStockParaTransferir(xmlCatalogo, idAlmacen, idMoneda);
        }
        
    }
}
