using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;


namespace GRH.AccesoDatos
{
    public class clsADAsignacionHorario
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable DatosAsigHorario(int idPersonal)
        {
            return objEjeSp.EjecSP("GRH_DatosAsigHorario_SP", idPersonal);
        }
        public DataTable GuardaAsigHorario(int idPersonal, int idHorario, DateTime tdFechInicio, DateTime tdFechaFin)
        {
            return objEjeSp.EjecSP("GRH_GuardarAsigHorario_SP", idPersonal, idHorario, tdFechInicio, tdFechaFin);

        }
        public void ActualizarAsigHorario(int idAsigancion, int idHorario, DateTime tdFechInicio, DateTime tdFechaFin,
                                            int lVigente)
        {
            objEjeSp.EjecSP("GRH_ActualizarAsigHorario_SP", idAsigancion, idHorario, tdFechInicio, tdFechaFin,
                                                            lVigente);
        }
    }
}
