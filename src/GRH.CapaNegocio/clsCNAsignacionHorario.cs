using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNAsignacionHorario
    {
        clsADAsignacionHorario LitaHorarios = new clsADAsignacionHorario();
        public DataTable DatosAsigHorario(int idPersonal)
        {
            return LitaHorarios.DatosAsigHorario(idPersonal);

        }
        public int GuardaAsigHorario(int idPersonal, int idHorario, DateTime tdFechInicio, DateTime tdFechaFin)
        {
            DataTable tbResul=LitaHorarios.GuardaAsigHorario(idPersonal, idHorario, tdFechInicio, tdFechaFin);
            int idAsig;
            return idAsig = Convert.ToInt32(tbResul.Rows[0][0]);
        }
        public void ActualizarAsigHorario(int idAsigancion, int idHorario, DateTime tdFechInicio, DateTime tdFechaFin,
                                            int lVigente)
        {
            LitaHorarios.ActualizarAsigHorario(idAsigancion, idHorario, tdFechInicio, tdFechaFin,
                                               lVigente);

        }
    }
}
