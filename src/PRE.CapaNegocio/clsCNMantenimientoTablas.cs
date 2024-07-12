using PRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRE.CapaNegocio
{
    public class clsCNMantenimientoTablas
    {
        clsADMantenimientoTablas clsadmantenimientotablas = new clsADMantenimientoTablas();
        public DataTable ListarTiposModificacion()
        {
            return clsadmantenimientotablas.ListarTiposModificacion();
        }
        public DataTable ActualizarTiposModificacion(int idTipoModificacion, string cDescripcion, int idUsuMod, DateTime dFechaMod)
        {
            return clsadmantenimientotablas.ActualizarTiposModificacion(idTipoModificacion, cDescripcion, idUsuMod, dFechaMod);
        }

        public DataTable ListarEstadosPeriodo()
        {
            return clsadmantenimientotablas.ListarEstadosPeriodo();
        }
        public DataTable ActualizarEstadosPeriodo(int idEstadoPresupuesto, string cDescripcion, int idUsuMod, DateTime dFechaMod)
        {
            return clsadmantenimientotablas.ActualizarEstadosPeriodo(idEstadoPresupuesto, cDescripcion, idUsuMod, dFechaMod);
        }

        public DataTable ListarTiposAfectacion()
        {
            return clsadmantenimientotablas.ListarTiposAfectacion();
        }
        public DataTable ActualizarTiposAfectacion(int idLimAplicacion, string cDescripcion, string cAbreviatura, string cMesInicio, string cMesFin, int idUsuMod, DateTime dFechaMod)
        {
            return clsadmantenimientotablas.ActualizarTiposAfectacion(idLimAplicacion, cDescripcion, cAbreviatura, cMesInicio, cMesFin, idUsuMod, dFechaMod);
        }
    }
}
