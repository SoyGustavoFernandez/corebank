using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;

namespace RCP.AccesoDatos
{
    public class clsADPlanTrabajo
    {
        #region Variables
        private clsGENEjeSP objEjeSP { get; set; }
        #endregion

        #region Constructores
        public clsADPlanTrabajo()
        {
            objEjeSP = new clsGENEjeSP();
        }
        #endregion

        #region Metodos

        public DataTable ADListarPlanTrabajoSolicitado(int idUsuario, int idPerfil)
        {
            return objEjeSP.EjecSP("RCP_ListarPlanTrabajoSolicitado_SP", idUsuario, idPerfil);
        }

        public DataTable ADListarPlanTrabajoElaborador(int idUsuario)
        {
            return objEjeSP.EjecSP("RCP_ListarPlanTrabajoElaborador_SP", idUsuario);
        }

        public DataTable ADObtenerPlanTrabajoRecuperacion(int idUsuario, int idAgencia, DateTime dFechasistema)
        {
            return objEjeSP.EjecSP("RCP_ObtenerPlanTrabajoRecuperacion_SP", idUsuario, idAgencia, dFechasistema);
        }

        public DataSet ADObtenerPlanTrabajoRecuperacionCompleto(int idPlanTrabajoRecuperacion)
        {
            return objEjeSP.DSEjecSP("RCP_ObtenerPlanTrabajoRecuperacionCompleto_SP", idPlanTrabajoRecuperacion);
        }

        public DataTable ADListarObjetivoTipo()
        {
            return objEjeSP.EjecSP("RCP_ListarObjetivoTipo_SP");
        }

        public DataTable ADListarNombreSemana()
        {
            return objEjeSP.EjecSP("RCP_ListarNombreSemana_SP");
        }

        public DataTable ADRegistrarPlanTrabajoRecuperacion(int idUsuario, int idPerfil, int idAgencia, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_RegistrarPlanTrabajoRecuperacion_SP", idUsuario, idPerfil, idAgencia, dFechaSistema);
        }

        public DataTable ADListarObjetivoResumen(int idResumenObjetivoPadre, int idObjetivoTipo)
        {
            return objEjeSP.EjecSP("RCP_ListarObjetivoResumen_SP", idResumenObjetivoPadre, idObjetivoTipo);
        }

        public DataTable ADListarAccion()
        {
            return objEjeSP.EjecSP("RCP_ListarPlanTrabajoAccion_SP");
        }

        public DataTable ADObtenerDatosUsuarioZona(int idUsuario)
        {
            return objEjeSP.EjecSP("RCP_ObtenerDatosUsuarioZona_SP", idUsuario);
        }

        public DataTable ADListarDatosCreditoClienteCartera(int idUsuario)
        {
            return objEjeSP.EjecSP("RCP_ListarDatosCreditoClienteCartera_SP", idUsuario);
        }

        public DataTable ADObtenerResumenPlanTrabajo(int idPlanTrabajoRecuperacion)
        {
            return objEjeSP.EjecSP("RCP_ObtenerResumenPlanTrabajo_SP", idPlanTrabajoRecuperacion);
        }
        public DataTable ADObtenerPlanTrabajoDetalle(int idPlanTrabajoRecuperacion)
        {
            return objEjeSP.EjecSP("RCP_ObtenerDetallePlanTrabajo_SP", idPlanTrabajoRecuperacion);
        }

        public DataTable ADEnviarPlanTrabajoRecuperacion(int idPlanTrabajoRecuperacion, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_EnviarPlanTrabajoCompleto_SP", idPlanTrabajoRecuperacion, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable ADAprobarPlanTrabajoRecuperacion(int idPlanTrabajoRecuperacion, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_AprobarPlanTrabajoCompleto_SP", idPlanTrabajoRecuperacion, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable ADDenegarPlanTrabajoRecuperacion(int idPlanTrabajoRecuperacion, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_DenegarPlanTrabajoCompleto_SP", idPlanTrabajoRecuperacion, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable ADObtenerPlanTrabajoElaboradoReporte(int nMes, int nAnio)
        {
            return objEjeSP.EjecSP("RCP_ObtenerPlanTrabajoElaboradoReporte_SP", nMes, nAnio);
        }

        public DataTable ADObtenerPlanTrabajoEstadoReporte(int nMes, int nAnio)
        {
            return objEjeSP.EjecSP("RCP_ObtenerPlanTrabajoEstadoReporte_SP", nMes, nAnio);
        }

        public DataTable ADObtenerUbigeoPadreUbicacion(int idUbigeo)
        {
            return objEjeSP.EjecSP("RCP_ObtenerUbigeoPadreUbicacion_SP", idUbigeo);
        }

        public DataTable ADObtenerResumenObjetivoSemana()
        {
            return objEjeSP.EjecSP("RCP_ObtenerResumenObjetivoSemana_SP");
        }

        public DataTable ADListarDatosCreditoClienteTramoObjetivo(int idUsuario, int idAgencia, int idResumenObjetivoGeneral, int idResumenObjetivoEspecifico)
        {
            return objEjeSP.EjecSP("RCP_ListarDatosCreditoClienteTramoObjetivo_SP", idUsuario, idAgencia, idResumenObjetivoGeneral, idResumenObjetivoEspecifico);
        }

        public DataTable ADObtenerPlanTrabajoVistoBueno(int idPlanTrabajoRecuperacion)
        {
            return objEjeSP.EjecSP("RCP_ObtenerPlanTrabajoVistoBueno_SP", idPlanTrabajoRecuperacion);
        }

        public DataTable ADRegistrarActualizarObjetivoGeneralPlanTrabajo(string xmlPlanTrabajoObjetivoGeneral, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_RegistrarActualizarObjetivoGeneralPlanTrabajo_SP", xmlPlanTrabajoObjetivoGeneral, idUsuario, dFechaSistema);
        }

        public DataTable ADEliminarObjetivoGeneralPlanTrabajo(int idPlanTrabajoRecuperacion, int idPlanTrabajoObjetivo)
        {
            return objEjeSP.EjecSP("RCP_EliminarObjetivoGeneralPlanTrabajo_SP", idPlanTrabajoRecuperacion, idPlanTrabajoObjetivo);
        }

        public DataTable ADRegistrarObjetivoEspecificoPlanTrabajoCompleto(  int idPlanTrabajoRecuperacion       , int idPlanTrabajoObjetivoGeneral  , string xmlPlanTrabajoObjetivoEspecifico   ,
                                                                            string xmlPlanTrabajoDetalleAccion  , string xmlPlanTrabajoZonaVisita   , string xmlPlanTrabajoCliente              ,
                                                                            DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_RegistrarObjetivoEspecificoPlanTrabajoCompleto_SP", idPlanTrabajoRecuperacion   , idPlanTrabajoObjetivoGeneral  , xmlPlanTrabajoObjetivoEspecifico  ,
                                                                                            xmlPlanTrabajoDetalleAccion , xmlPlanTrabajoZonaVisita      , xmlPlanTrabajoCliente             ,
                                                                                            dFechaSistema);
        }

        public DataTable ADActualizarObjetivoEspecificoPlanTrabajo(int idPlanTrabajoObjetivoGeneral, string xmlPlanTrabajoObjetivoEspecifico, int idPlanTrabajoObjetivoEspecifico)
        {
            return objEjeSP.EjecSP("RCP_ActualizarObjetivoEspecificoPlanTrabajo_SP", idPlanTrabajoObjetivoGeneral, xmlPlanTrabajoObjetivoEspecifico , idPlanTrabajoObjetivoEspecifico);
        }

        public DataTable ADEliminarObjetivoEspecificoPlanTrabajo(int idPlanTrabajoObjetivoEspecifico, int idPlanTrabajoRecuperacion)
        {
            return objEjeSP.EjecSP("RCP_EliminarObjetivoEspecificoPlanTrabajo_SP", idPlanTrabajoObjetivoEspecifico, idPlanTrabajoRecuperacion);
        }

        public DataTable ADRegistrarActualizarDetalleAccionPlanTrabajo(int idPlanTrabajoRecuperacion, int idPlanTrabajoObjetivoEspecifico, string xmlPlanTrabajoDetalleAccion, string xmlPlanTrabajoCliente, int idPlanTrabajoDetalleAccion, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_RegistrarActualizarDetalleAccionPlanTrabajo_SP", idPlanTrabajoRecuperacion, idPlanTrabajoObjetivoEspecifico, xmlPlanTrabajoDetalleAccion, xmlPlanTrabajoCliente, idPlanTrabajoDetalleAccion, dFechaSistema);
        }

        public DataTable ADEliminarDetalleAccionPlanTrabajo(int idPlanTrabajoObjetivoEspecifico, int idPlanTrabajoDetalleAccion, int idPlanTrabajoRecuperacion)
        {
            return objEjeSP.EjecSP("RCP_EliminarDetalleAccionPlanTrabajo_SP", idPlanTrabajoObjetivoEspecifico, idPlanTrabajoDetalleAccion, idPlanTrabajoRecuperacion);
        }

        public DataTable ADRegistrarActualizarZonaVisitaPlanTrabajo(int idPlanTrabajoZonaVisita, int idPlanTrabajoRecuperacion, int idPlanTrabajoObjetivoEspecifico, string xmlPlanTrabajoZonaVisita, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("RCP_RegistrarActualizarZonaVisitaPlanTrabajo_SP", idPlanTrabajoZonaVisita, idPlanTrabajoRecuperacion, idPlanTrabajoObjetivoEspecifico, xmlPlanTrabajoZonaVisita, dFechaSistema);
        }

        public DataTable ADEliminarZonaVisitaPlanTrabajo(int idPlanTrabajoObjetivoEspecifico, int idPlanTrabajoRecuperacion, int idPlanTrabajoZonaVisita)
        {
            return objEjeSP.EjecSP("RCP_EliminarZonaVisitaPlanTrabajo_SP", idPlanTrabajoObjetivoEspecifico, idPlanTrabajoRecuperacion, idPlanTrabajoZonaVisita);
        }


        #endregion

    }
}
