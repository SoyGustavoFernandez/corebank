#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
#endregion

namespace RCP.AccesoDatos
{
    public class clsADPlanillaMovilidad
    {
        #region Variables
        private clsGENEjeSP objEjeSP { get; set; }
        #endregion

        public clsADPlanillaMovilidad()
        {
            objEjeSP = new clsGENEjeSP();
        }

        #region Metodos
        public DataTable ADObtenerPlanTrabajoAprobado(int idUsuario)
        {
            return objEjeSP.EjecSP("RCP_ObtenerPlanTrabajoAprobado_SP", idUsuario);
        }

        public DataTable ADListarPlanillaMovilidadSolicitado(int idUsuario, int idPerfil)
        {
            return objEjeSP.EjecSP("RCP_ObtenerPlanillaMovilidadSolicitado_SP", idUsuario, idPerfil);
        }

        public DataTable ADAprobarPlanillaMovilidad(int idPlanillaMovilidad, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_AprobarPlanillaMovilidad_SP", idPlanillaMovilidad, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable ADEnviarPlanillaMovilidad(int idPlanillaMovilidad, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_EnviarPlanillaMovilidad_SP", idPlanillaMovilidad, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable ADDenegarPlanillaMovilidad(int idPlanillaMovilidad, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_DenegarPlanillaMovilidad_SP", idPlanillaMovilidad, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable ADObtenerDatosPlanillaMovilidad(int idPlanillaMovilidad)
        {
            return objEjeSP.EjecSP("RCP_ObtenerDatosPlanillaMovilidad_SP", idPlanillaMovilidad);
        }

        public DataSet ADObtenerDatosPlanillaMovilidadCompleto(int idPlanillaMovilidad, int idPlanTrabajoRecuperacion)
        {
            return objEjeSP.DSEjecSP("RCP_ObtenerDatosPlanillaMovilidadCompleto_SP", idPlanillaMovilidad, idPlanTrabajoRecuperacion);
        }

        public DataTable ADRegistrarPlanillaMovilidad(string xmlPlanillaMovilidad, int idUsuario, int idPerfil,DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_RegistrarPlanillaMovilidad_SP", xmlPlanillaMovilidad, idUsuario, idPerfil, dFechaSistema); 
        }

        public DataTable ADActualizarPlanillaMovilidad(int idPlanillaMovilidad, string xmlPlanillaMovilidad, int idUsuario, int idPerfil, int idUsuarioActualiza, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_ActualizarPlanillaMovilidad_SP", idPlanillaMovilidad, xmlPlanillaMovilidad, idUsuario, idPerfil, idUsuarioActualiza, dFechaSistema);
        }

        public DataTable ADObtenerPlanillaMovilidadDetalle(int idPlanillaMovilidad)
        {
            return objEjeSP.EjecSP("RCP_ObtenerRPTPlanillaMovilidadDetalle_SP", idPlanillaMovilidad);
        }
        public DataTable ADObtenerResumenPlanillaMovilidad(int idPlanillaMovilidad)
        {
            return objEjeSP.EjecSP("RCP_ObtenerRPTResumenPlanillaMovilidad_SP", idPlanillaMovilidad);
        }

        public DataTable ADObtenerVistoBuenoPlanillaMovilidad(int idPlanillaMovilidad)
        {
            return objEjeSP.EjecSP("RCP_ObtenerRPTPlanillaMovilidadVistoBueno_SP", idPlanillaMovilidad);
        }
        public DataTable ADObtenerPlanillaMovilidadElaborador(int nMes, int nAnio)
        {
            return objEjeSP.EjecSP("RCP_ObtenerRPTPlanillaMovilidadElaborado_SP", nMes, nAnio);
        }

        public DataTable ADListarPlanillaMovilidadElaborador(int idUsuario)
        {
            return objEjeSP.EjecSP("RCP_ListarPlanillaMovilidadElaborador_SP", idUsuario);
        }
        #endregion

        #region Eventos
        #endregion
    }
}
