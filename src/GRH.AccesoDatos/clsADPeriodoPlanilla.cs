using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADPeriodoPlanilla
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarPeriodosVigenteTipoPlanilla(int idTipoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ListarPeriodoVigenteTipoPlanilla_SP", idTipoPlanilla);
        }

        public DataTable ADListarTodosPeriodoTipoPlanilla(int idTipoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ListarTodosPeriodos_SP", idTipoPlanilla);
        }

        public DataTable ADListarPeriodosPlanilla(int idTipoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ListarPeriodosPlanillas_SP", idTipoPlanilla);
        }

        public DataTable ADActualizarPeriodoPlanila(int idPeriodo, string cDenominacion, DateTime dFechaInicio, DateTime dFechaFin,
                                                  int idEstadoPeriodo, int lVigente)
        {
            return objEjeSp.EjecSP("GRH_ActElimPeriodoPlanilla_SP", idPeriodo, cDenominacion, dFechaInicio, dFechaFin,
                                                    idEstadoPeriodo, lVigente);
        }

        public DataTable ADGuardarPeriodoPlanilla(int idTipoPlanilla, string cDenominacion, DateTime dFechaInicio, DateTime dFechaFin,
                                                   int idEstadoPeriodo)
        {
            return objEjeSp.EjecSP("GRH_GuardarPeriodoPlanilla_SP", idTipoPlanilla, cDenominacion, dFechaInicio, dFechaFin,
                                                     idEstadoPeriodo);
        }
    }
}
