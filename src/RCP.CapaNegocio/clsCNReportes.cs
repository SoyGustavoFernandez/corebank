using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNReportes
    {
        clsADReportes adReportes = new clsADReportes();
        public DataTable ListarRecuperacionesEfectivas(DateTime dtFecha)
        {
            return adReportes.ListarRecuperacionesEfectivas(dtFecha);
        }

        public DataTable HistoricoRecuperacionesEfectivas(DateTime dtFecha)
        {
            return adReportes.HistoricoRecuperacionesEfectivas(dtFecha);
        }

        public DataTable AvanceRecuperaciones(string cPeriodo, int idPerfil, DateTime dFecha)
        {
            return adReportes.AvanceRecuperaciones(cPeriodo, idPerfil, dFecha);
        }

        public DataTable AsignacionTramosCredGestorRecuperaciones(string cPeriodo, DateTime dFecha, bool lInicioMeta, int idPerfil)
        {
            return adReportes.AsignacionTramosCredGestorRecuperaciones(cPeriodo, dFecha, lInicioMeta, idPerfil);
        }

        public DataTable CreditosRecuperados(int idComisionRecuperador, string cPeriodo, int idUsuario)
        {
            return adReportes.CreditosRecuperados(idComisionRecuperador, cPeriodo, idUsuario);
        }

        public DataTable CuadroIncentivosRecuperaciones(string cPeriodo, int idPerfil)
        {
            return adReportes.CuadroIncentivosRecuperaciones(cPeriodo, idPerfil);
        }

        public DataTable SeguimientoRecuperadores()
        {
            return adReportes.SeguimientoRecuperadores();
        }

        public DataTable listarCreditosEfectivamenteCastigados(string cPeriodo)
        {
            return adReportes.listarCreditosEfectivamenteCastigados(cPeriodo);
        }

        public DataTable obtenerComisionesRecuperacion(string cPeriodo, int idPerfil)
        {
            return adReportes.obtenerComisionesRecuperacion(cPeriodo, idPerfil);
        }

        public DataTable CreditosPropuestosParaCastigo(int idSuperaUmbral, DateTime dFechaSis)
        {
            return adReportes.CreditosPropuestosParaCastigo(idSuperaUmbral, dFechaSis);
        }

        public DataTable listarCreditosPosiblesDevol(int idAgencia)
        {
            return adReportes.listarCreditosPosiblesDevol(idAgencia);
        }

        public DataTable MovilidadHojaRuta(int idUsuario, DateTime dFechaIni, DateTime dFechaFin)
        {
            return adReportes.MovilidadHojaRuta(idUsuario, dFechaIni, dFechaFin);
        }

        public DataTable CreditosParaImpresionMasiva(int idUsuario, int idAgencia, int idUbigeo, Decimal /*era double*/nAtrasoMin, Decimal /*era double*/nAtrasoMax)
        {
            return adReportes.CreditosParaImpresionMasiva(idUsuario, idAgencia, idUbigeo, nAtrasoMin, nAtrasoMax);
        }

        public DataTable listarResumenCastigos()
        {
            return adReportes.listarResumenCastigos();
        }

        public DataTable listarCreditosCastPorProduc()
        {
            return adReportes.listarCreditosCastPorProduc();
        }

        public DataTable listarResumenCartCast()
        {
            return adReportes.listarResumenCartCast();
        }

        public DataTable listarCreditosSolicitadosDevol(int idAgencia)
        {
            return adReportes.listarCreditosSolicitadosDevol(idAgencia);
        }

        public DataTable ObtenerCreditosConProceso(int idCliente, int idCuenta)
        {
            return adReportes.ObtenerCreditosConProceso(idCliente, idCuenta);
        }

        public DataTable SeguimientoRecuperadoresTodos(DateTime dInicio, DateTime dFin)
        {
            return adReportes.SeguimientoRecuperadoresTodos(dInicio, dFin);
        }

        public DataTable SeguimientoRecuperadoresHojaRuta(DateTime dInicio, DateTime dFin)
        {
            return adReportes.SeguimientoRecuperadoresHojaRuta(dInicio, dFin);
        }

        public DataTable SeguimientoRecuperadoresConCli(DateTime dInicio, DateTime dFin)
        {
            return adReportes.SeguimientoRecuperadoresConCli(dInicio, dFin);
        }

        public DataTable rptRecuperacionesPrestamos(DateTime dFehaIni,DateTime dFecha, int idZona, int idAgecnia, int idAsesor)
        {
            return adReportes.rptRecuperacionesPrestamos(dFehaIni, dFecha, idZona, idAgecnia, idAsesor);
        }

        public DataTable rptCastigadosTresUit(int nAnio, int nMes)
        {
            return adReportes.rptCastigadosTresUit(nAnio, nMes);
        }
    }
}
