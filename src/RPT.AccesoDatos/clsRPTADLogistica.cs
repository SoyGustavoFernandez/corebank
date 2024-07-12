using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using System.Data.SqlTypes;
namespace RPT.AccesoDatos
{
    public class clsRPTADLogistica
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADReporteBuenaPro(int idProceso, DateTime dFechaBuenaPro)
        {
            return objEjeSp.EjecSP("LOG_OtorgarBuenaPro_sp", idProceso, dFechaBuenaPro);
        }

        public DataTable ADCNReporteNotaEntrada(int idNotaEntrada)
        {
            return objEjeSp.EjecSP("RPT_ReporteNotaEntrada_SP", idNotaEntrada);
        }

        public DataTable ADKardexBienPorAlmacen(DateTime dFechaInicio, DateTime dFechaFin, int idAlmacen, int idTipoBien, int idGrupo, int idSubGrupo, int idRubro, int idCatalogo)
        {
            return objEjeSp.EjecSP("LOG_KardexBienPorAlmacen_SP", dFechaInicio, dFechaFin, idAlmacen, idTipoBien, idGrupo, idSubGrupo, idRubro, idCatalogo);
        }

        public DataTable ADKardexPorTipoOperacionTipoMovimiento(DateTime dFechaInicio, DateTime dFechaFin, int idTipoOperacion, int idTipoMovimiento)
        {
            return objEjeSp.EjecSP("LOG_KardexPorTipoOperacionTipoMovimiento_SP", dFechaInicio, dFechaFin, idTipoOperacion, idTipoMovimiento);
        }

        public DataTable ADHistoricoSaldoCatalogoPorAlmacen(DateTime dFecha, int idAlmacen, int idMoneda, int idTipoBien, int idGrupo, int idSubGrupo, int idRubro)
        {
            return objEjeSp.EjecSP("LOG_HistoricoSaldoCatalogoPorAlmacen_SP", dFecha, idAlmacen, idMoneda, idTipoBien, idGrupo, idSubGrupo, idRubro);
        }

        public DataTable CATipoCambioFijo(DateTime dFecha)
        {
            return objEjeSp.EjecSP("LOG_RetornaTipoCambioFijo_SP", dFecha);
        }

        public DataTable ADSaldoCatalogoPorAlmacen(DateTime dFecha, int idAlmacen, int idMoneda, int idTipoBien, int idGrupo, int idSubGrupo, int idRubro)
        {
            return objEjeSp.EjecSP("LOG_SaldoCatalogoPorAlmacen_SP", dFecha, idAlmacen, idMoneda, idTipoBien, idGrupo, idSubGrupo, idRubro);
        }

        public DataTable ADHistoricoStockBienPorAgencia(DateTime dFecha, int idAgencia, int idCatalogo)
        {
            return objEjeSp.EjecSP("LOG_HistoricoStockBienPorAgencia_SP", dFecha, idAgencia, idCatalogo);
        }

        public DataTable ADStockBienPorAgencia(int idAgencia, int idCatalogo)
        {
            return objEjeSp.EjecSP("LOG_StockBienPorAgencia_SP", idAgencia, idCatalogo);
        }

        public DataTable ADDataAtencionNotaSalida(int idNotaSalida)
        {
            return objEjeSp.EjecSP("LOG_ListarNotaSalida_SP", idNotaSalida, SqlDateTime.MinValue.Value, 
                                    SqlDateTime.MaxValue.Value,0, "1,2,3,4",0);
        }

        public DataTable ADDetalleAtencionNotaSalida(int idNotaSalida)
        {
            return objEjeSp.EjecSP("LOG_ListarDetNotasalida_sp", idNotaSalida);
        }

        public DataTable ADCargarGrupoSubGrupoRubro(int idPadre, int idTipoBien)
        {
            return objEjeSp.EjecSP("LOG_CargarGrupoSubGrupoRubro_Sp", idPadre, idTipoBien);
        }

        public DataTable ADHistoricoStockBienesAlmacen(DateTime dFecha, int idAgencia, int idAlmacen, int idRubro)
        {
            return objEjeSp.EjecSP("LOG_HistoricoStockBienesAgencia_SP", dFecha, idAgencia, idAlmacen, idRubro);
        }

        public DataTable ADStockBienesAlmacen(DateTime dFecha, int idAgencia, int idAlmacen, int idRubro)
        {
            return objEjeSp.EjecSP("LOG_StockBienesAgencia_SP", dFecha, idAgencia, idAlmacen, idRubro);
        }

        public DataTable ADKardexBienAlmacen(int idAlmacen, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("LOG_KardexBienAlmacen_SP", idAlmacen, dFechaIni, dFechaFin);
        }

        public DataTable ADNotaPedido(int idNotaPedido)
        {
            return objEjeSp.EjecSP("LOG_RetornaNotaPedidobyId_sp", idNotaPedido);
        }
        public DataTable ADDetalleNotaPedido(int idNotaPedido)
        {
            return objEjeSp.EjecSP("LOG_ListarDetalleNotaPedido_SP", idNotaPedido);
        }
        public DataTable ADRegBuenaPro(string xmlBuenaPro)
        {
            return objEjeSp.EjecSP("LOG_GuardarBuenaProDetalles_SP", xmlBuenaPro);
        }

        public DataTable ADImpresionBuenaPro(int idProceso)
        {
            return objEjeSp.EjecSP("LOG_ImpresionBuenaPro_SP", idProceso);
        }

        public DataTable ADGetBienesEntregadosColab(DateTime dFechaInicio, DateTime dFechaFin, int idAlmacen)
        {
            return objEjeSp.EjecSP("LOG_RptBienesEntregadosColab_SP", dFechaInicio, dFechaFin, idAlmacen);
        }

        public DataTable ADGetIngresoEgresoSaldoCatalogo(int idAlmacen, DateTime dFecha)
        {
            return objEjeSp.EjecSP("LOG_IngresoEgresoSaldoCatalogo_SP", idAlmacen, dFecha);
        }
    }
}
