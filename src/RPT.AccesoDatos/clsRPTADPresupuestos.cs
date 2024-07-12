using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADPresupuestos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarVariacionMensual(int idPeriodo, string cTipoEstructura, int nTipoModificacion)
        {
            return objEjeSp.EjecSP("PRE_ListarVariacionPresMensual_SP", idPeriodo, cTipoEstructura, nTipoModificacion);
        }
        public DataTable listarVariacionAcuMensual(int idPeriodo, string cTipoEstructura, int nTipoModificacion)
        {
            return objEjeSp.EjecSP("PRE_ListarVariacionPresAcuMensual_SP", idPeriodo, cTipoEstructura, nTipoModificacion);
        }
        public DataTable listarVariacionDetalle(int idPeriodo, string cTipoEstructura, int nTipoModificacion)
        {
            return objEjeSp.EjecSP("PRE_ListarDetallePres_SP", idPeriodo, cTipoEstructura, nTipoModificacion);
        }
        public DataTable listarSaldosMensuales(int idPeriodo, string cTipoEstructura, int idMesInicio, int idMesFin)
        {
            return objEjeSp.EjecSP("PRE_SaldoMesEjecucionPres_SP", idPeriodo, cTipoEstructura, idMesInicio, idMesFin);
        }
        public DataTable listarSaldosAcumulado(int idPeriodo, string cTipoEstructura, int idMesFin)
        {
            return objEjeSp.EjecSP("PRE_SaldoAcumuladoEjecucPres_SP", idPeriodo, cTipoEstructura, idMesFin);
        }
        //Lista detalle de partidas presupuestales
        public DataTable listarDetallePartida(int idPeriodo, string cEstructura, int idCriterioValor, int idMes)
        {
            return objEjeSp.EjecSP("PRE_ListaPartidasYValores_SP", idPeriodo, cEstructura, idCriterioValor, idMes);
        }
        
    }
}
