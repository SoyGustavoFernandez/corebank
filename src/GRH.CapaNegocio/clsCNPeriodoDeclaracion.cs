using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNPeriodoDeclaracion
    {
        clsADPeriodoDeclaracion objPeriodoDeclaracion = new clsADPeriodoDeclaracion();

        public DataTable CNListarPeriodosDeclaracionVigente()
        {
            return objPeriodoDeclaracion.ADListarPeriodosDeclaracionVigente();
        }

        public DataTable CNListarPeriodosDeclaracion()
        {
            return objPeriodoDeclaracion.ADListarPeriodosDeclaracion();
        }

        public DataTable CNActualizarPeriodoDeclaracion(int idPeriodo, string cDenominacion, DateTime dFechaInicio, DateTime dFechaFin,
                                                   int idEstadoPeriodo, int idMes, int lVigente)
        {
            return objPeriodoDeclaracion.ADActualizarPeriodoDeclaracion(idPeriodo, cDenominacion, dFechaInicio, dFechaFin,
                                                                      idEstadoPeriodo, idMes, lVigente);
        }

        public int CNGuardarPeriodoDeclaracion(string cDenominacion, DateTime dFechaInicio, DateTime dFechaFin,
                                             int idEstadoPeriodo, int idMes)
        {
            DataTable dtResul = objPeriodoDeclaracion.ADGuardarPeriodoDeclaracion(cDenominacion, dFechaInicio, dFechaFin,
                                                                                idEstadoPeriodo, idMes);
            int idNuevo = Convert.ToInt32(dtResul.Rows[0][0]);
            return idNuevo;
        }
    }
}
