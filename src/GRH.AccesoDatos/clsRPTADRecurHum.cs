using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
namespace GRH.AccesoDatos
{
    public class clsRPTADRecurHum
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarJustificaciones(DateTime dFecInicio, DateTime dFecFin, int idAge)
        {
            return objEjeSp.EjecSP("RPT_JustificacionInasis_sp", dFecInicio, dFecFin, idAge);
        }
        public DataTable ADListarPermisos(DateTime dFecInicio, DateTime dFecFin, int idAge, int idEstadoPerm)
        {
            return objEjeSp.EjecSP("RPT_Permisos_sp", dFecInicio, dFecFin, idAge, idEstadoPerm);
        }
        public DataTable ADListarFaltasTard(DateTime dFecInicio, DateTime dFecFin, int idAge)
        {
            return objEjeSp.EjecSP("RPT_FaltasTardanzas_sp", dFecInicio, dFecFin, idAge);
        }
        public DataTable ADBoletasRemuner(int idPlanilla)
        {
            return objEjeSp.EjecSP("RPT_BoletaRemXPeriodo_sp", idPlanilla);
        }
        public DataTable ADBoletaRemPorPeriodoDec(int idPeriodoDeclaracion)
        {
            return objEjeSp.EjecSP("GRH_BoletaRemPorPeriodoDec_sp", idPeriodoDeclaracion);
        }
        public DataTable AD6UltRemuner(int idPeriodo)
        {
            return objEjeSp.EjecSP("RPT_6UltRemuneraciones_sp", idPeriodo);
        }
        public DataTable ADListarPlanillas( int idPlanilla)
        {
            return objEjeSp.EjecSP("RPT_ListarPlanillas_sp", idPlanilla);
        }
        public DataTable ADListarVacacionesPend(int idAgencia)
        {
            return objEjeSp.EjecSP("RPT_ListarVacacionesPend_sp", idAgencia);
        }
        public DataTable CNLisPlanillas(int idPeriodo, int idModalidad)
        {
            return objEjeSp.EjecSP("RPT_ListarNroPlanillas_sp", idPeriodo, idModalidad);
        }
        public DataTable ADLisPlanillasDeclarativas(int idTipoPlanilla, int idPeriodo)
        {
            return objEjeSp.EjecSP("RPT_ListarNroPlanillasDeclarativo_sp", idTipoPlanilla, idPeriodo);
        }
        public DataTable ADListaColaboradores(int idAgencia, int idArea, int idCargo, int idEstado)
        {
            return objEjeSp.EjecSP("CLI_RptlisPersonal_Sp", idAgencia, idArea, idCargo, idEstado);
        }
        public DataTable ADRptUsoVacaciones(int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("GRH_ReporteUsoVacaciones_sp", idAgencia, dFecIni, dFecFin);
        }
        public DataTable ADRptCtasContablesPlanilla(int idPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ReporteCtasContablesPlanilla_sp", idPlanilla);
        }
    }
}
