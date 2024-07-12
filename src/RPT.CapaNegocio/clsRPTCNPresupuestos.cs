using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using RPT.AccesoDatos;

namespace RPT.CapaNegocio
{
    public class clsRPTCNPresupuestos
    {
        clsRPTADPresupuestos rptcnpresupuestos = new clsRPTADPresupuestos();
        public DataTable listarVariacionMensual(int idPeriodo, string cTipoEstructura, int nTipoModificacion)
        {
            return rptcnpresupuestos.listarVariacionMensual(idPeriodo, cTipoEstructura, nTipoModificacion);
        }
        public DataTable listarVariacionAcuMensual(int idPeriodo, string cTipoEstructura, int nTipoModificacion)
        {
            return rptcnpresupuestos.listarVariacionAcuMensual(idPeriodo, cTipoEstructura, nTipoModificacion);
        }
        public DataTable listarVariacionDetalle(int idPeriodo, string cTipoEstructura, int nTipoModificacion)
        {
            return rptcnpresupuestos.listarVariacionDetalle(idPeriodo, cTipoEstructura, nTipoModificacion);
        }
        public DataTable listarSaldosMensuales(int idPeriodo, string cTipoEstructura, int idMesInicio, int idMesFin)
        {
            return rptcnpresupuestos.listarSaldosMensuales(idPeriodo, cTipoEstructura, idMesInicio, idMesFin);
        }
        public DataTable listarSaldosAcumulado(int idPeriodo, string cTipoEstructura, int idMesFin)
        {
            return rptcnpresupuestos.listarSaldosAcumulado(idPeriodo, cTipoEstructura, idMesFin);
        }
        //Lista detalle de partidas presupuestales
        public DataTable listarDetallePartida(int idPeriodo, string cEstructura, int idCriterioValor, int idMes)
        {
            return rptcnpresupuestos.listarDetallePartida(idPeriodo, cEstructura, idCriterioValor, idMes);
        }
    }
}
