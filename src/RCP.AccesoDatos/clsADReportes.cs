using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADReportes
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarRecuperacionesEfectivas(DateTime dtFecha)
        {
            return objEjeSp.EjecSP("RCP_ListarRecuperacionesEfectivas_SP", dtFecha);
        }

        public DataTable HistoricoRecuperacionesEfectivas(DateTime dtFecha)
        {
            return objEjeSp.EjecSP("RCP_HistListarRecuperacionesEfectivas_SP", dtFecha);
        }

        public DataTable AvanceRecuperaciones(string cPeriodo, int idPerfil, DateTime dFecha)
        {
            return objEjeSp.EjecSP("RCP_ListarAvanceRecuperaciones_SP", cPeriodo, idPerfil, dFecha);
        }

        public DataTable AsignacionTramosCredGestorRecuperaciones(string cPeriodo, DateTime dFecha, bool lInicioMeta, int idPerfil)
        {
            return objEjeSp.EjecSP("RCP_ListarCredTramosGestoresRecuperaciones_SP", cPeriodo, dFecha, lInicioMeta, idPerfil);
        }

        public DataTable CreditosRecuperados(int idComisionRecuperador, string cPeriodo, int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_ListarCuentasRecuperadas_SP", idComisionRecuperador, cPeriodo, idUsuario);
        }

        public DataTable CuadroIncentivosRecuperaciones(string cPeriodo, int idPerfil)
        {
            return objEjeSp.EjecSP("RCP_VerComisionesRecuperadores_SP", cPeriodo, idPerfil);
        }

        public DataTable SeguimientoRecuperadores()
        {
            return objEjeSp.EjecSP("RCP_ListarSeguimientoRecuperadores_SP");
        }

        public DataTable listarCreditosEfectivamenteCastigados(string cPeriodo)
        {
            return objEjeSp.EjecSP("RCP_ListaCreditosCastigadosEfectivos_SP", cPeriodo);
        }

        public DataTable obtenerComisionesRecuperacion(string cPeriodo, int idPerfil)
        {
            return objEjeSp.EjecSP("RCP_ObtenerComisionRecuperador_SP", cPeriodo, idPerfil);
        }

        public DataTable CreditosPropuestosParaCastigo(int idSuperaUmbral, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosPropuestosParaCastigo_SP", idSuperaUmbral, dFechaSis);
        }

        public DataTable listarCreditosPosiblesDevol(int idAgencia)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosPosiblesADevolucion_SP", idAgencia);
        }

        public DataTable MovilidadHojaRuta(int idUsuario, DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("RCP_ListarMovilidadHojaRuta_SP", idUsuario, dFechaIni, dFechaFin);
        }

        public DataTable CreditosParaImpresionMasiva(int idUsuario, int idAgencia, int idUbigeo, Decimal nAtrasoMin, Decimal nAtrasoMax)
        {
            return objEjeSp.EjecSP("RCP_ListarNotificacionesGeneracionMasiva_SP", idUsuario, idAgencia, idUbigeo, nAtrasoMin, nAtrasoMax);
        }

        public DataTable listarResumenCartCast()
        {
            return objEjeSp.EjecSP("RCP_ListarResumenMensualCarteraYCastigos_SP");
        }

        public DataTable listarCreditosCastPorProduc()
        {
            return objEjeSp.EjecSP("RCP_ListarCastigosPorProductos_SP");
        }

        public DataTable listarResumenCastigos()
        {
            return objEjeSp.EjecSP("RCP_ListarResumenCastigos_SP");
        }

        public DataTable listarCreditosSolicitadosDevol(int idAgencia)
        {
            return objEjeSp.EjecSP("RCP_ListarCreditosSolicitadosDevolucion_SP", idAgencia);
        }

        public DataTable ObtenerCreditosConProceso(int idCliente, int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_ObtenerCreditosConProceso_SP", idCliente, idCuenta);
        }

        public DataTable SeguimientoRecuperadoresTodos(DateTime dInicio, DateTime dFin)
        {
            return objEjeSp.EjecSP("RCP_ListarSeguimientoRecuperadores_SP", dInicio, dFin);
        }

        public DataTable SeguimientoRecuperadoresHojaRuta(DateTime dInicio, DateTime dFin)
        {
            return objEjeSp.EjecSP("RCP_ListarSeguimientoRecuperadoresHoRu_SP", dInicio, dFin);
        }

        public DataTable SeguimientoRecuperadoresConCli(DateTime dInicio, DateTime dFin)
        {
            return objEjeSp.EjecSP("RCP_ListarSeguimientoRecContactoCliente_SP", dInicio, dFin);
        }

        public DataTable rptRecuperacionesPrestamos(DateTime dFechaIni,DateTime dFecha, int idZona, int idAgecnia, int idAsesor)
        {
            return objEjeSp.EjecSP("RPT_RecuperacionPrestamo_SP", dFechaIni,dFecha, idZona, idAgecnia, idAsesor);
        }

        public DataTable rptCastigadosTresUit(int nAnio, int nMes)
        {
            return objEjeSp.EjecSP("RCP_RptCreditosCastigadosMayorTresUit_SP", nAnio, nMes);
        }
    }
}
