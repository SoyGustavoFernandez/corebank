using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.Rendiciones.AccesoDatos
{
    public class clsADAprobaciones
    {
        #region propiedades privadas
        private IntConexion objEjeSp;
        #endregion

        #region constructores
        public clsADAprobaciones()
        {
            this.objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region métodos públicos
        public DataTable obtenerResumenAprobaciones(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerMisAprobacionesPendientes_SP", parametros);
        }

        public DataTable obtenerAprobacionesEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerSolicitudesPorAprobar_SP", parametros);
        }

        public DataTable registrarAprobacionEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarAprobacionSolicitud_SP", parametros);
        }

        public DataTable obtenerAprobacionesRendicion(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerRendicionesPorAprobar_SP", parametros);
        }

        public DataTable registrarAprobacionRendicion(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarAprobacionRendicion_SP", parametros);
        }
        #endregion
    }
}
