using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WCF.Authorization.Helper;
using WCF.Authorization.Interfaces;
using WCF.Authorization.Modelo;
using WCF.Authorization.Negocio;

namespace WCF.Authorization.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Authentication" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Authentication.svc or Authentication.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CRAndes : ICRAndes
    {
        public ResAuth Authenticate(ReqAuth objReqAuth)
        {
            if (objReqAuth == null && WebOperationContext.Current != null)
            {
                return null;
            }

            //------------------------
            //Ejecuta Evento
            //------------------------

            clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);
            DataTable dtRegReqTransLogKasNet = new DataTable();
            DataTable dtValCredenciales = new DataTable();

            int idAPIUsuarioAuth;
            string cToken;
            int idApiEmpresa = 1; //Por Empresa Caja los Andes

            dtValCredenciales = objCNCredencialTokenValidador.CNValidarCredenciales(objReqAuth.cUsuario, clsHash.ComputeSha256Hash(objReqAuth.cPassword), idApiEmpresa);

            ResAuth objResAuth = new ResAuth();

            if (dtValCredenciales.Rows.Count > 0)
            {
                idAPIUsuarioAuth = Convert.ToInt32(dtValCredenciales.Rows[0]["idAPIUsuarioAuth"]);
                cToken = clsJwt.GetJwt(objReqAuth.cUsuario, objReqAuth.cPassword, idAPIUsuarioAuth);

                dtValCredenciales = objCNCredencialTokenValidador.CNGuardarToken(idAPIUsuarioAuth, cToken);

                objResAuth.cCodigo = "00";
                objResAuth.cMensaje = "success";
                objResAuth.cExpiresIn = string.Empty;
                objResAuth.cRefreshToken = string.Empty;
                objResAuth.cToken = cToken;
            }
            else
            {
                objResAuth.cCodigo = "0099";
                objResAuth.cMensaje = "Error... validación incorrecta";
                objResAuth.cExpiresIn = string.Empty;
                objResAuth.cRefreshToken = string.Empty;
                objResAuth.cToken = string.Empty;
            }
            //------------------------

            return objResAuth;
        }

        public ResOnOffServicio EncenderServicio(ReqOnOffServicio objReqOnOffServicio)
        {
            var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            var cToken = cAuthorization.Substring(7);
            var varToken = new JwtSecurityToken(jwtEncodedString: cToken);

            //------------------------
            //Ejecuta Evento
            //------------------------
            clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);
            DataTable dtOnOffServicio = new DataTable();
            int idPDPUsuarioAuth = Convert.ToInt32(varToken.Claims.First(c => c.Type == "EmpId").Value);
            bool lEncendido = true;

            dtOnOffServicio = objCNCredencialTokenValidador.CNOnOffServicio(objReqOnOffServicio.idApiEmpresa, idPDPUsuarioAuth, lEncendido);

            ResOnOffServicio objResOnOffServicio = new ResOnOffServicio();
            objResOnOffServicio.EstRpt = new EstadoRespuesta();


            if (dtOnOffServicio.Rows.Count > 0)
            {
                objResOnOffServicio.EstRpt.lResultado = (Convert.ToInt32(dtOnOffServicio.Rows[0]["lResultado"]) == 1) ? true : false;                
                objResOnOffServicio.EstRpt.cEstCode = dtOnOffServicio.Rows[0]["cEstCode"].ToString();
                objResOnOffServicio.EstRpt.cMensaje = dtOnOffServicio.Rows[0]["cMensaje"].ToString();                
            }
            else
            {
                objResOnOffServicio.EstRpt.lResultado = false;
                objResOnOffServicio.EstRpt.cEstCode = "9999";
                objResOnOffServicio.EstRpt.cMensaje = "Error interno";
            }
            //------------------------

            return objResOnOffServicio;
        }

        public ResOnOffServicio ApagarServicio(ReqOnOffServicio objReqOnOffServicio)
        {
            var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            var cToken = cAuthorization.Substring(7);
            var varToken = new JwtSecurityToken(jwtEncodedString: cToken);

            //------------------------
            //Ejecuta Evento
            //------------------------
            clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);
            DataTable dtOnOffServicio = new DataTable();
            int idPDPUsuarioAuth = Convert.ToInt32(varToken.Claims.First(c => c.Type == "EmpId").Value);
            bool lEncendido = false;

            dtOnOffServicio = objCNCredencialTokenValidador.CNOnOffServicio(objReqOnOffServicio.idApiEmpresa, idPDPUsuarioAuth, lEncendido);

            ResOnOffServicio objResOnOffServicio = new ResOnOffServicio();
            objResOnOffServicio.EstRpt = new EstadoRespuesta();

            if (dtOnOffServicio.Rows.Count > 0)
            {
                objResOnOffServicio.EstRpt.lResultado = (Convert.ToInt32(dtOnOffServicio.Rows[0]["lResultado"]) == 1) ? true : false;
                objResOnOffServicio.EstRpt.cEstCode = dtOnOffServicio.Rows[0]["cEstCode"].ToString();
                objResOnOffServicio.EstRpt.cMensaje = dtOnOffServicio.Rows[0]["cMensaje"].ToString();
            }
            else
            {
                objResOnOffServicio.EstRpt.lResultado = false;
                objResOnOffServicio.EstRpt.cEstCode = "9999";
                objResOnOffServicio.EstRpt.cMensaje = "Error interno";
            }
            //------------------------

            return objResOnOffServicio;
        }

        public ResObtenerEstServ ObtenerEstServ(ReqObtenerEstServ objReqObtenerEstServ)
        {            
            //------------------------
            //Ejecuta Evento
            //------------------------
            clsCNCredencialTokenValidador objCNCredencialTokenValidador = new clsCNCredencialTokenValidador(true);
            DataTable dtObtenerEstServ = new DataTable();

            dtObtenerEstServ = objCNCredencialTokenValidador.CNObtenerEstadoServicio(objReqObtenerEstServ.idApiEmpresa);

            ResObtenerEstServ objResObtenerEstServ = new ResObtenerEstServ();
            objResObtenerEstServ.EstRpt = new EstadoRespuesta();

            if (dtObtenerEstServ.Rows.Count > 0)
            {
                objResObtenerEstServ.EstRpt.lResultado = true;
                objResObtenerEstServ.EstRpt.cEstCode = "0001";
                objResObtenerEstServ.EstRpt.cMensaje = "Success";
                objResObtenerEstServ.cEmpresa = dtObtenerEstServ.Rows[0]["cEmpresa"].ToString();
                objResObtenerEstServ.cUsuario = dtObtenerEstServ.Rows[0]["cUsuario"].ToString();
                objResObtenerEstServ.dFechaReg = Convert.ToDateTime(dtObtenerEstServ.Rows[0]["dFechaReg"]).ToString("MM/dd/yyyy HH:mm:ss");
                objResObtenerEstServ.dFechaAct = (string.IsNullOrWhiteSpace(dtObtenerEstServ.Rows[0]["dFechaAct"].ToString())) ? string.Empty : Convert.ToDateTime(dtObtenerEstServ.Rows[0]["dFechaAct"]).ToString("MM/dd/yyyy HH:mm:ss");
                objResObtenerEstServ.lEstado = Convert.ToBoolean(dtObtenerEstServ.Rows[0]["lEstado"]);
            }
            else
            {
                objResObtenerEstServ.EstRpt.lResultado = false;
                objResObtenerEstServ.EstRpt.cEstCode = "9999";
                objResObtenerEstServ.EstRpt.cMensaje = "Error interno";
            }
            //------------------------

            return objResObtenerEstServ;
        }
    }
}
