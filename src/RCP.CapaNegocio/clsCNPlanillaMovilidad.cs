using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCP.AccesoDatos;
using EntityLayer;
using System.Data;
using GEN.Funciones;

namespace RCP.CapaNegocio
{
    public class clsCNPlanillaMovilidad
    {
        #region Variables
        private clsADPlanillaMovilidad objADPlanillaMovilidad { get; set; }
        #endregion


        public clsCNPlanillaMovilidad()
        {
            objADPlanillaMovilidad = new clsADPlanillaMovilidad();
        }


        #region Metodos
        public clsPlanTrabajoRecuperacion CNObtenerPlanTrabajoAprobado(int idUsuario)
        {
            DataTable dtPlanTrabajo = objADPlanillaMovilidad.ADObtenerPlanTrabajoAprobado(idUsuario);

            return (dtPlanTrabajo.Rows.Count > 0) ? (dtPlanTrabajo.ToList<clsPlanTrabajoRecuperacion>() as List<clsPlanTrabajoRecuperacion>)[0] : new clsPlanTrabajoRecuperacion();
        }

        public List<clsFlujoPlanillaMovilidad> CNListarPlanillaMovilidadSolicitado(int idUsuario, int idPerfil)
        {
            DataTable dtPlanillaMovilidad = objADPlanillaMovilidad.ADListarPlanillaMovilidadSolicitado(idUsuario, idPerfil);

            return (dtPlanillaMovilidad.Rows.Count > 0) ? dtPlanillaMovilidad.ToList<clsFlujoPlanillaMovilidad>() as List<clsFlujoPlanillaMovilidad> : new List<clsFlujoPlanillaMovilidad>();
        }

        public DataTable CNAprobarPlanillaMovilidad(int idPlanillaMovilidad, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objADPlanillaMovilidad.ADAprobarPlanillaMovilidad(idPlanillaMovilidad, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable CNEnviarPlanillaMovilidad(int idPlanillaMovilidad, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objADPlanillaMovilidad.ADEnviarPlanillaMovilidad(idPlanillaMovilidad, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable CNDenegarPlanillaMovilidad(int idPlanillaMovilidad, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objADPlanillaMovilidad.ADDenegarPlanillaMovilidad(idPlanillaMovilidad, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable CNRegistrarPlanillaMovilidad(string xmlPlanillaMovilidad, int idUsuario, int idPerfil, DateTime dFechaSistema)
        {
            return objADPlanillaMovilidad.ADRegistrarPlanillaMovilidad(xmlPlanillaMovilidad, idUsuario, idPerfil, dFechaSistema);
        }

        public DataTable CNActualizarPlanillaMovilidad(int idPlanillaMovilidad, string xmlPlanillaMovilidad, int idUsuario, int idPerfil, int idUsuarioActualiza, DateTime dFechaSistema)
        {
            return objADPlanillaMovilidad.ADActualizarPlanillaMovilidad(idPlanillaMovilidad, xmlPlanillaMovilidad, idUsuario, idPerfil, idUsuarioActualiza, dFechaSistema);
        }

        public clsPlanillaMovilidad CNObtenerDatosPlanillaMovilidadCompleto(int idPlanillaMovilidad, int idPlanTrabajoRecuperacion)
        {
            clsPlanillaMovilidad _objPlanillaMovilidad = new clsPlanillaMovilidad();
            List<clsPlanillaMovilidadResumen> lstResumenPlanillaMovilidad = new List<clsPlanillaMovilidadResumen>();

            DataSet dsPlanillaMovilidad = objADPlanillaMovilidad.ADObtenerDatosPlanillaMovilidadCompleto(idPlanillaMovilidad, idPlanTrabajoRecuperacion);

            _objPlanillaMovilidad = (dsPlanillaMovilidad.Tables[0].Rows.Count > 0) ? (dsPlanillaMovilidad.Tables[0].ToList<clsPlanillaMovilidad>() as List<clsPlanillaMovilidad>)[0] : new clsPlanillaMovilidad(); ;
            lstResumenPlanillaMovilidad = (dsPlanillaMovilidad.Tables[1].Rows.Count > 0) ? (dsPlanillaMovilidad.Tables[1].ToList<clsPlanillaMovilidadResumen>() as List<clsPlanillaMovilidadResumen>) : new List<clsPlanillaMovilidadResumen>();

            _objPlanillaMovilidad.lstPlanillaMovilidadResumen = lstResumenPlanillaMovilidad;

            return _objPlanillaMovilidad;
        }

        public DataTable CNObtenerPlanillaMovilidadDetalle(int idPlanillaMovilidad)
        {
            return objADPlanillaMovilidad.ADObtenerPlanillaMovilidadDetalle(idPlanillaMovilidad);
        }
        public DataTable CNObtenerResumenPlanillaMovilidad(int idPlanillaMovilidad)
        {
            return objADPlanillaMovilidad.ADObtenerResumenPlanillaMovilidad(idPlanillaMovilidad);
        }

        public DataTable CNObtenerVistoBuenoPlanillaMovilidad(int idPlanillaMovilidad)
        {
            return objADPlanillaMovilidad.ADObtenerVistoBuenoPlanillaMovilidad(idPlanillaMovilidad);
        }

        public DataTable CNObtenerPlanillaMovilidadElaborador(int nMes, int nAnio)
        {
            return objADPlanillaMovilidad.ADObtenerPlanillaMovilidadElaborador(nMes, nAnio);
        }

        public clsFlujoPlanillaMovilidad CNListarPlanillaMovilidadElaborador(int idUsuario)
        {
            DataTable dtPlanillaMovilidad = objADPlanillaMovilidad.ADListarPlanillaMovilidadElaborador(idUsuario);
            return (dtPlanillaMovilidad.Rows.Count > 0) ? (dtPlanillaMovilidad.ToList<clsFlujoPlanillaMovilidad>() as List<clsFlujoPlanillaMovilidad>)[0] : new clsFlujoPlanillaMovilidad();
        }

        #endregion

        #region Eventos
        #endregion




    }
}
