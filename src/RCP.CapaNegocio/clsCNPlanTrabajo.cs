#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCP.AccesoDatos;
using GEN.Funciones;
using EntityLayer;
using System.Data;
#endregion

namespace RCP.CapaNegocio
{
    public class clsCNPlanTrabajo
    {
        #region Variables
        private clsADPlanTrabajo objADPlanTrabajo { get; set; }
        #endregion

        public clsCNPlanTrabajo()
        {
            objADPlanTrabajo = new clsADPlanTrabajo();
        }

        #region Metodos

        public List<clsFlujoPlanTrabajoRecuperacion> CNListarPlanTrabajoSolicitado(int idUsuario, int idPerfil)
        {
            DataTable dtPlanTrabajo = objADPlanTrabajo.ADListarPlanTrabajoSolicitado(idUsuario, idPerfil);

            return (dtPlanTrabajo.Rows.Count > 0) ? dtPlanTrabajo.ToList<clsFlujoPlanTrabajoRecuperacion>() as List<clsFlujoPlanTrabajoRecuperacion> : new List<clsFlujoPlanTrabajoRecuperacion>();
        }

        public clsFlujoPlanTrabajoRecuperacion CNListarPlanTrabajoElaborador(int idUsuario)
        {
            DataTable dtPlanTrabajo = objADPlanTrabajo.ADListarPlanTrabajoElaborador(idUsuario);

            return (dtPlanTrabajo.Rows.Count > 0) ? (dtPlanTrabajo.ToList<clsFlujoPlanTrabajoRecuperacion>() as List<clsFlujoPlanTrabajoRecuperacion>)[0] : new clsFlujoPlanTrabajoRecuperacion();
        }

        public clsPlanTrabajoRecuperacion CNObtenerPlanTrabajoRecuperacion(int idUsuario, int idAgencia, DateTime dFechasistema)
        {
            DataTable dtPlanTrabajo = objADPlanTrabajo.ADObtenerPlanTrabajoRecuperacion(idUsuario, idAgencia, dFechasistema);

            return (dtPlanTrabajo.Rows.Count > 0) ? (dtPlanTrabajo.ToList<clsPlanTrabajoRecuperacion>() as List<clsPlanTrabajoRecuperacion>)[0] : new clsPlanTrabajoRecuperacion(); ;
        }

        public clsPlanTrabajoRecuperacion CNObtenerPlanTrabajoRecuperacionCompleto(int idPlanTrabajoRecuperacion)
        {
            clsPlanTrabajoRecuperacion planTrabajoRecuperacion      = new clsPlanTrabajoRecuperacion();
            List<clsPlanTrabajoObjetivo> lstPlanTrabajoObjetivo     = new List<clsPlanTrabajoObjetivo>();
            DataSet dsPlanTrabajo = objADPlanTrabajo.ADObtenerPlanTrabajoRecuperacionCompleto(idPlanTrabajoRecuperacion);

            planTrabajoRecuperacion     = (dsPlanTrabajo.Tables[0].Rows.Count > 0) ? (dsPlanTrabajo.Tables[0].ToList<clsPlanTrabajoRecuperacion>() as List<clsPlanTrabajoRecuperacion>)[0] : new clsPlanTrabajoRecuperacion();

            lstPlanTrabajoObjetivo      = (dsPlanTrabajo.Tables[1].Rows.Count > 0) ? dsPlanTrabajo.Tables[1].ToList<clsPlanTrabajoObjetivo>() as List<clsPlanTrabajoObjetivo> : new List<clsPlanTrabajoObjetivo>();

            List<clsPlanTrabajoObjetivo> _lstObejtivoGeneral                = lstPlanTrabajoObjetivo.Where(item => item.idObjetivoTipo == 1).ToList();
            List<clsPlanTrabajoObjetivo> _lstObejtivoEspecifico             = lstPlanTrabajoObjetivo.Where(item => item.idObjetivoTipo == 2).ToList();
            List<clsPlanTrabajoDetalleAccion> _lstDetalleAccion             = (dsPlanTrabajo.Tables[2].Rows.Count > 0) ? dsPlanTrabajo.Tables[2].ToList<clsPlanTrabajoDetalleAccion>() as List<clsPlanTrabajoDetalleAccion> : new List<clsPlanTrabajoDetalleAccion>();
            List<clsPlanTrabajoZonaVisita> _lstZonaVisita                   = (dsPlanTrabajo.Tables[3].Rows.Count > 0) ? dsPlanTrabajo.Tables[3].ToList<clsPlanTrabajoZonaVisita>() as List<clsPlanTrabajoZonaVisita> : new List<clsPlanTrabajoZonaVisita>();
            List<clsDatosCreditoClientePlanTrabajo> _lstClientePlanTrabajo  = (dsPlanTrabajo.Tables[4].Rows.Count > 0) ? dsPlanTrabajo.Tables[4].ToList<clsDatosCreditoClientePlanTrabajo>() as List<clsDatosCreditoClientePlanTrabajo> : new List<clsDatosCreditoClientePlanTrabajo>();

            _lstDetalleAccion = _lstDetalleAccion.Select(item => { item.lstDatosCreditoCliente = _lstClientePlanTrabajo.Where(item2 => item2.idPlanTrabajoDetalleAccion == item.idPlanTrabajoDetalleAccion).Select(item3 => { return (clsDatosCreditoCliente)item3; }).ToList<clsDatosCreditoCliente>(); return item; }).ToList();

            planTrabajoRecuperacion.lstPlanTrabajoObjetivoGeneral       = _lstObejtivoGeneral;
            planTrabajoRecuperacion.lstPlanTrabajoObjetivoEspecifico    = _lstObejtivoEspecifico;
            planTrabajoRecuperacion.lstPlanTrabajoAccion                = _lstDetalleAccion;
            planTrabajoRecuperacion.lstPlanTrabajoZonaVisita            = _lstZonaVisita;
            planTrabajoRecuperacion.lstClienteVinculadoPlanTrabajo      = _lstClientePlanTrabajo;

            return planTrabajoRecuperacion;
        }

        public DataTable CNListarObjetivoTipo()
        {
            return objADPlanTrabajo.ADListarObjetivoTipo();
        }

        public DataTable CNListarNombreSemana()
        {
            return objADPlanTrabajo.ADListarNombreSemana();
        }

        public DataTable CNRegistrarPlanTrabajoRecuperacion(int idUsuario, int idPerfil, int idAgencia, DateTime dFechaSistema)
        {
            return objADPlanTrabajo.ADRegistrarPlanTrabajoRecuperacion(idUsuario, idPerfil, idAgencia, dFechaSistema);
        }

        public DataTable CNListarObjetivoResumen(int idResumenObjetivoPadre, int idObjetivoTipo)
        {
            return objADPlanTrabajo.ADListarObjetivoResumen(idResumenObjetivoPadre, idObjetivoTipo);
        }

        public DataTable CNListarAccion()
        {
            return objADPlanTrabajo.ADListarAccion();
        }

        public DataTable CNObtenerDatosUsuarioZona(int idUsuario)
        {
            return objADPlanTrabajo.ADObtenerDatosUsuarioZona(idUsuario);
        }

        public List<clsDatosCreditoCliente> CNListarDatosCreditoClienteCartera(int idUsuario)
        {
            DataTable dtDatosClienteCartera = objADPlanTrabajo.ADListarDatosCreditoClienteCartera(idUsuario);

            return (dtDatosClienteCartera.Rows.Count > 0) ? dtDatosClienteCartera.ToList<clsDatosCreditoCliente>() as List<clsDatosCreditoCliente> : new List<clsDatosCreditoCliente>();
        }

        public DataTable CNObtenerPlanTrabajoDetalle(int idPlanTrabajoRecuperacion)
        {
            return objADPlanTrabajo.ADObtenerPlanTrabajoDetalle(idPlanTrabajoRecuperacion);
        }
        public DataTable CNObtenerResumenPlanTrabajo(int idPlanTrabajoRecuperacion)
        {
            return objADPlanTrabajo.ADObtenerResumenPlanTrabajo(idPlanTrabajoRecuperacion);
        }

        public DataTable CNEnviarPlanTrabajoRecuperacion(int idPlanTrabajoRecuperacion, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objADPlanTrabajo.ADEnviarPlanTrabajoRecuperacion(idPlanTrabajoRecuperacion, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable CNAprobarPlanTrabajoRecuperacion(int idPlanTrabajoRecuperacion, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objADPlanTrabajo.ADAprobarPlanTrabajoRecuperacion(idPlanTrabajoRecuperacion, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable CNDenegarPlanTrabajoRecuperacion(int idPlanTrabajoRecuperacion, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objADPlanTrabajo.ADDenegarPlanTrabajoRecuperacion(idPlanTrabajoRecuperacion, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable CNObtenerPlanTrabajoElaboradoReporte(int nMes, int nAnio)
        {
            return objADPlanTrabajo.ADObtenerPlanTrabajoElaboradoReporte(nMes, nAnio);
        }
        
        public DataTable CNObtenerPlanTrabajoEstadoReporte(int nMes, int nAnio)
        {
            return objADPlanTrabajo.ADObtenerPlanTrabajoEstadoReporte(nMes, nAnio);
        }

        public DataTable CNObtenerUbigeoPadreUbicacion(int idUbigeo)
        {
            return objADPlanTrabajo.ADObtenerUbigeoPadreUbicacion(idUbigeo);
        }
        public List<clsResumenObjetivoSemana> CNObtenerResumenObjetivoSemana()
        {
            DataTable dtResumenObjetivoSemana = objADPlanTrabajo.ADObtenerResumenObjetivoSemana();

            return (dtResumenObjetivoSemana.Rows.Count > 0) ? dtResumenObjetivoSemana.ToList<clsResumenObjetivoSemana>() as List<clsResumenObjetivoSemana> : new List<clsResumenObjetivoSemana>();
        }

        public List<clsDatosCreditoCliente> CNListarDatosCreditoClienteTramoObjetivo(int idUsuario, int idAgencia, int idResumenObjetivoGeneral, int idResumenObjetivoEspecifico)
        {
            DataTable dtDatosClienteTramoObjetivo = objADPlanTrabajo.ADListarDatosCreditoClienteTramoObjetivo(idUsuario, idAgencia, idResumenObjetivoGeneral, idResumenObjetivoEspecifico);

            return (dtDatosClienteTramoObjetivo.Rows.Count > 0) ? dtDatosClienteTramoObjetivo.ToList<clsDatosCreditoCliente>() as List<clsDatosCreditoCliente> : new List<clsDatosCreditoCliente>();
        }

        public DataTable CNObtenerPlanTrabajoVistoBueno(int idPlanTrabajoRecuperacion)
        {
            return objADPlanTrabajo.ADObtenerPlanTrabajoVistoBueno(idPlanTrabajoRecuperacion);
        }

        public DataTable CNRegistrarActualizarObjetivoGeneralPlanTrabajo(string xmlPlanTrabajoObjetivoGeneral, int idUsuario, DateTime dFechaSistema)
        {
            return objADPlanTrabajo.ADRegistrarActualizarObjetivoGeneralPlanTrabajo(xmlPlanTrabajoObjetivoGeneral, idUsuario, dFechaSistema);
        }
        public DataTable CNEliminarObjetivoGeneralPlanTrabajo(int idPlanTrabajoRecuperacion, int idPlanTrabajoObjetivo)
        {
            return objADPlanTrabajo.ADEliminarObjetivoGeneralPlanTrabajo(idPlanTrabajoRecuperacion, idPlanTrabajoObjetivo);
        }

        public DataTable CNRegistrarObjetivoEspecificoPlanTrabajoCompleto(  int idPlanTrabajoRecuperacion       , int idPlanTrabajoObjetivoGeneral  , string xmlPlanTrabajoObjetivoEspecifico   ,
                                                                            string xmlPlanTrabajoDetalleAccion  , string xmlPlanTrabajoZonaVisita   , string xmlPlanTrabajoCliente              ,
                                                                            DateTime dFechaSistema)
        {
            return objADPlanTrabajo.ADRegistrarObjetivoEspecificoPlanTrabajoCompleto(   idPlanTrabajoRecuperacion   , idPlanTrabajoObjetivoGeneral  , xmlPlanTrabajoObjetivoEspecifico  ,
                                                                                        xmlPlanTrabajoDetalleAccion , xmlPlanTrabajoZonaVisita      , xmlPlanTrabajoCliente             ,
                                                                                        dFechaSistema);
        }

        public DataTable CNActualizarObjetivoEspecificoPlanTrabajo(int idPlanTrabajoObjetivoGeneral, string xmlPlanTrabajoObjetivoEspecifico, int idPlanTrabajoObjetivoEspecifico)
        {
            return objADPlanTrabajo.ADActualizarObjetivoEspecificoPlanTrabajo(idPlanTrabajoObjetivoGeneral, xmlPlanTrabajoObjetivoEspecifico, idPlanTrabajoObjetivoEspecifico);
        }

        public DataTable CNEliminarObjetivoEspecificoPlanTrabajo(int idPlanTrabajoObjetivoEspecifico, int idPlanTrabajoRecuperacion)
        {
            return objADPlanTrabajo.ADEliminarObjetivoEspecificoPlanTrabajo(idPlanTrabajoObjetivoEspecifico, idPlanTrabajoRecuperacion);
        }

        public DataTable CNRegistrarActualizarDetalleAccionPlanTrabajo(int idPlanTrabajoRecuperacion, int idPlanTrabajoObjetivoEspecifico, string xmlPlanTrabajoDetalleAccion, string xmlPlanTrabajoCliente, int idPlanTrabajoDetalleAccion, DateTime dFechaSistema)
        {
            return objADPlanTrabajo.ADRegistrarActualizarDetalleAccionPlanTrabajo(idPlanTrabajoRecuperacion, idPlanTrabajoObjetivoEspecifico, xmlPlanTrabajoDetalleAccion, xmlPlanTrabajoCliente, idPlanTrabajoDetalleAccion, dFechaSistema);
        }

        public DataTable CNEliminarDetalleAccionPlanTrabajo(int idPlanTrabajoObjetivoEspecifico, int idPlanTrabajoDetalleAccion, int idPlanTrabajoRecuperacion)
        {
            return objADPlanTrabajo.ADEliminarDetalleAccionPlanTrabajo(idPlanTrabajoObjetivoEspecifico, idPlanTrabajoDetalleAccion, idPlanTrabajoRecuperacion);
        }

        public DataTable CNRegistrarActualizarZonaVisitaPlanTrabajo(int idPlanTrabajoZonaVisita, int idPlanTrabajoRecuperacion, int idPlanTrabajoObjetivoEspecifico, string xmlPlanTrabajoZonaVisita, DateTime dFechaSistema)
        {
            return objADPlanTrabajo.ADRegistrarActualizarZonaVisitaPlanTrabajo(idPlanTrabajoZonaVisita, idPlanTrabajoRecuperacion, idPlanTrabajoObjetivoEspecifico, xmlPlanTrabajoZonaVisita, dFechaSistema);
        }

        public DataTable CNEliminarZonaVisitaPlanTrabajo(int idPlanTrabajoObjetivoEspecifico, int idPlanTrabajoRecuperacion, int idPlanTrabajoZonaVisita)
        {
            return objADPlanTrabajo.ADEliminarZonaVisitaPlanTrabajo(idPlanTrabajoObjetivoEspecifico, idPlanTrabajoRecuperacion, idPlanTrabajoZonaVisita);
        }


        #endregion

    }
}

