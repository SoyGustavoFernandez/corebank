using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRE.AccesoDatos
{
    public class clsADMantenimientoTablas
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarTiposModificacion()
        {
            return objEjeSp.EjecSP("PRE_ListarMantenimientoTipoMod_SP");
        }
        public DataTable ActualizarTiposModificacion(int idTipoModificacion, string cDescripcion, int idUsuMod, DateTime dFechaMod)
        {
            return objEjeSp.EjecSP("PRE_ActualizarMantenimientoTipoMod_SP", idTipoModificacion, cDescripcion, idUsuMod, dFechaMod);
        }

        public DataTable ListarEstadosPeriodo()
        {
            return objEjeSp.EjecSP("PRE_ListarMantenimientoEstPeriodo_SP");
        }
        public DataTable ActualizarEstadosPeriodo(int idEstadoPresupuesto, string cDescripcion, int idUsuMod, DateTime dFechaMod)
        {
            return objEjeSp.EjecSP("PRE_ActualizarMantenimientoEstPeriodo_SP", idEstadoPresupuesto, cDescripcion, idUsuMod, dFechaMod);
        }

        public DataTable ListarTiposAfectacion()
        {
            return objEjeSp.EjecSP("PRE_ListarMantenimientoTipoAfec_SP");
        }
        public DataTable ActualizarTiposAfectacion(int idLimAplicacion, string cDescripcion, string cAbreviatura, string cMesInicio, string cMesFin, int idUsuMod, DateTime dFechaMod)
        {
            return objEjeSp.EjecSP("PRE_ActualizarMantenimientoTipoAfec_SP", idLimAplicacion, cDescripcion, cAbreviatura, cMesInicio, cMesFin, idUsuMod, dFechaMod);
        }
    }
}
