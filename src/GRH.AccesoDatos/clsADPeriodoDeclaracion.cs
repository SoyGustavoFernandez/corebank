using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADPeriodoDeclaracion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarPeriodosDeclaracionVigente()
        {
            return objEjeSp.EjecSP("GRH_ListarPeriodoDeclaracionVigente_SP");
        }

        public DataTable ADListarPeriodosDeclaracion()
        {
            return objEjeSp.EjecSP("GRH_ListarPeriodosDeclarativos_SP");
        }

        public DataTable ADActualizarPeriodoDeclaracion(int idPeriodo, string cDenominacion, DateTime dFechaInicio, DateTime dFechaFin,
                                                        int idEstadoPeriodo, int idMes, int lVigente)
        {
            return objEjeSp.EjecSP("GRH_ActElimPeriodoDeclarativo_SP", idPeriodo, cDenominacion, dFechaInicio, dFechaFin,
                                                     idEstadoPeriodo, idMes, lVigente);
        }
        public DataTable ADGuardarPeriodoDeclaracion(string cDenominacion, DateTime dFechaInicio, DateTime dFechaFin,
                                                     int idEstadoPeriodo, int idMes)
        {
            return objEjeSp.EjecSP("GRH_GuardarPeriodoDeclarativo_SP", cDenominacion, dFechaInicio, dFechaFin,
                                                     idEstadoPeriodo, idMes);
        }
    }
}
