using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsRPTCNRecurHum
    {
        clsRPTADRecurHum LitaHorarios = new clsRPTADRecurHum();
        public DataTable CNListarJustificaciones(DateTime dFecInicio,DateTime dFecFin,int idAge )
        {
            return LitaHorarios.ADListarJustificaciones(dFecInicio, dFecFin, idAge );
        }
        public DataTable CNListarPermisos(DateTime dFecInicio, DateTime dFecFin, int idAge, int idEstadoPerm)
        {
            return LitaHorarios.ADListarPermisos(dFecInicio, dFecFin, idAge, idEstadoPerm);
        }
        public DataTable CNListarFaltasTard(DateTime dFecInicio, DateTime dFecFin, int idAge)
        {
            return LitaHorarios.ADListarFaltasTard(dFecInicio, dFecFin, idAge);
        }
        public DataTable CNBoletasRemuner( int idPlanilla)
        {
            return LitaHorarios.ADBoletasRemuner(idPlanilla);
        }
        public DataTable CNBoletaRemPorPeriodoDec(int idPeriodoDeclaracion)
        {
            return LitaHorarios.ADBoletaRemPorPeriodoDec(idPeriodoDeclaracion);
        }
        public DataTable CN6UltRemuner(int idPeriodo)
        {
            return LitaHorarios.AD6UltRemuner(idPeriodo);
        }
        public DataTable CNListarPlanillas(int idPlanilla)
        {
            return LitaHorarios.ADListarPlanillas(idPlanilla);
        }
        public DataTable CNListarVacacionesPend(int idAgencia)
        {
            return LitaHorarios.ADListarVacacionesPend(idAgencia);
        }
        public DataTable CNLisPlanillas(int idPeriodo, int idModalidad)
        {
            return LitaHorarios.CNLisPlanillas(idPeriodo, idModalidad);
        }
        public DataTable CNLisPlanillasDeclarativas(int idTipoPlanilla,int idPeriodo)
        {
            return LitaHorarios.ADLisPlanillasDeclarativas(idTipoPlanilla, idPeriodo);
        }
        public DataTable CNListaColaboradores(int idAgencia, int idArea, int idCargo, int idEstado)
        {
            return LitaHorarios.ADListaColaboradores(idAgencia,idArea, idCargo, idEstado);
        }
        public DataTable CNRptUsoVacaciones(int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return LitaHorarios.ADRptUsoVacaciones(idAgencia, dFecIni, dFecFin);
        }
        public DataTable CNRptCtasContablesPlanilla(int idPlanilla)
        {
            return LitaHorarios.ADRptCtasContablesPlanilla(idPlanilla);
        }
    }
}
