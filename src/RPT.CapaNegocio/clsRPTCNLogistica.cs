using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPT.AccesoDatos;
using System.Data;
namespace RPT.CapaNegocio
{
    public class clsRPTCNLogistica
    {
        clsRPTADLogistica adlogistica = new clsRPTADLogistica();
        public DataTable CNBuenaPro(int idProceso, DateTime dFechaBuenaPro)
        {
            return adlogistica.ADReporteBuenaPro(idProceso, dFechaBuenaPro);
        }

        public DataTable CNReporteNotaEntrada(int idNotaEntrada)
        {
            return adlogistica.ADCNReporteNotaEntrada(idNotaEntrada);
        }

        public DataTable CNKardexBienPorAlmacen(DateTime dFechaInicio, DateTime dFechaFin, int idAlmacen, int idTipoBien, int idGrupo, int idSubGrupo, int idRubro, int idCatalogo)
        {
            return adlogistica.ADKardexBienPorAlmacen(dFechaInicio, dFechaFin, idAlmacen, idTipoBien, idGrupo, idSubGrupo, idRubro, idCatalogo);
        }

        public DataTable CNKardexPorTipoOperacionTipoMovimiento(DateTime dFechaInicio, DateTime dFechaFin, int idTipoOperacion, int idTipoMovimiento)
        {
            return adlogistica.ADKardexPorTipoOperacionTipoMovimiento(dFechaInicio, dFechaFin, idTipoOperacion, idTipoMovimiento);
        }

        public DataTable CNHistoricoSaldoCatalogoPorAlmacen(DateTime dFecha, int idAlmacen, int idMoneda, int idTipoBien, int idGrupo, int idSubGrupo, int idRubro)
        {
            return adlogistica.ADHistoricoSaldoCatalogoPorAlmacen(dFecha, idAlmacen, idMoneda, idTipoBien, idGrupo, idSubGrupo, idRubro);
        }

        public DataTable CNTipoCambioFijo(DateTime dFecha)
        {
            return adlogistica.CATipoCambioFijo(dFecha);
        }

        public DataTable CNSaldoCatalogoPorAlmacen(DateTime dFecha, int idAlmacen, int idMoneda, int idTipoBien, int idGrupo, int idSubGrupo, int idRubro)
        {
            return adlogistica.ADSaldoCatalogoPorAlmacen(dFecha, idAlmacen, idMoneda, idTipoBien, idGrupo, idSubGrupo, idRubro);
        }

        public DataTable CNHistoricoStockBienPorAgencia(DateTime dFecha, int idAgencia, int idCatalogo)
        {
            return adlogistica.ADHistoricoStockBienPorAgencia(dFecha, idAgencia, idCatalogo);
        }

        public DataTable CNStockBienPorAgencia(int idAgencia, int idCatalogo)
        {
            return adlogistica.ADStockBienPorAgencia(idAgencia, idCatalogo);
        }

        public DataTable CNDataAtencionNotaSalida(int idNotaSalida)
        {
            return adlogistica.ADDataAtencionNotaSalida( idNotaSalida);
        }

        public DataTable CNDetalleAtencionNotaSalida(int idNotaSalida)
        {
            return adlogistica.ADDetalleAtencionNotaSalida(idNotaSalida);
        }

        public DataTable CNCargarGrupoSubGrupoRubro(int idPadre, int idTipoBien)
        {
            return adlogistica.ADCargarGrupoSubGrupoRubro(idPadre, idTipoBien);
        }

        public DataTable CNHistoricoStockBienesAlmacen(DateTime dFecha, int idAgencia, int idAlmacen, int idRubro)
        {
            return adlogistica.ADHistoricoStockBienesAlmacen(dFecha, idAgencia, idAlmacen, idRubro);
        }

        public DataTable CNStockBienesAlmacen(DateTime dFecha, int idAgencia, int idAlmacen, int idRubro)
        {
            return adlogistica.ADStockBienesAlmacen(dFecha, idAgencia, idAlmacen, idRubro);
        }

        public DataTable CNKardexBienAlmacen(int idAlmacen, DateTime dFechaIni, DateTime dFechaFin)
        {
            return adlogistica.ADKardexBienAlmacen(idAlmacen, dFechaIni, dFechaFin);
        }

        public DataTable CNNotaPedido(int idNotaPedido)
        {
            return adlogistica.ADNotaPedido(idNotaPedido);
        }
        public DataTable CNDetalleNotaPedido(int idNotaPedido)
        {
            return adlogistica.ADDetalleNotaPedido(idNotaPedido);
        }
        
        public DataTable CNRegBuenaPro(string xmlBuenaPro)
        {
            return adlogistica.ADRegBuenaPro(xmlBuenaPro);
        }

        public DataTable CNImpresionBuenaPro(int idProceso)
        {
            return adlogistica.ADImpresionBuenaPro(idProceso);
        }

        public DataTable CNGetBienesEntregadosColab(DateTime dFechaInicio, DateTime dFechaFin, int idAlmacen)
        {
            return adlogistica.ADGetBienesEntregadosColab(dFechaInicio, dFechaFin, idAlmacen);
        }

        public DataTable CNGetIngresoEgresoSaldoCatalogo(int idAlmacen, DateTime dFecha)
        {
            return adlogistica.ADGetIngresoEgresoSaldoCatalogo(idAlmacen, dFecha);
        }
    }
}
