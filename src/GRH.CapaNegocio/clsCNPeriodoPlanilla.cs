using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNPeriodoPlanilla
    {
        clsADPeriodoPlanilla objPeriodoPlanilla = new clsADPeriodoPlanilla();

        public DataTable CNListarPeriodoVigenteTipoPlanilla(int idTipoPlanilla)
        {
            return objPeriodoPlanilla.ADListarPeriodosVigenteTipoPlanilla(idTipoPlanilla);
        }
        
        public DataTable CNListarTodosPeriodoTipoPlanilla(int idTipoPlanilla)
        {
            return objPeriodoPlanilla.ADListarTodosPeriodoTipoPlanilla(idTipoPlanilla);
        }

        public DataTable CNListarPeriodosPlanilla(int idTipoPlanilla)
        {
            return objPeriodoPlanilla.ADListarPeriodosPlanilla(idTipoPlanilla);
        }

        public DataTable CNActualizarPeriodoPlanila(int idPeriodo, string cDenominacion, DateTime dFechaInicio, DateTime dFechaFin,
                                                  int idEstadoPeriodo, int lVigente)
        {
            return objPeriodoPlanilla.ADActualizarPeriodoPlanila(idPeriodo, cDenominacion, dFechaInicio, dFechaFin, idEstadoPeriodo, lVigente);
        }

        public int CNGuardarPeriodoPlanilla(int idTipoPlanilla, string cDenominacion, DateTime dFechaInicio, DateTime dFechaFin,
                                          int idEstadoPeriodo)
        {
            DataTable dtResul = objPeriodoPlanilla.ADGuardarPeriodoPlanilla(idTipoPlanilla, cDenominacion, dFechaInicio, dFechaFin,
                                                     idEstadoPeriodo);
            int idNuevo = Convert.ToInt32(dtResul.Rows[0][0]);
            return idNuevo;
        }
    }
}
