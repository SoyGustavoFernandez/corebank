using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Linq;
using WCF.Authorization.Negocio;
using WCF.Authorization.Interfaces;
using WCF.Authorization;
using WCF.Authorization.Extensions;
using System.Data;
using WCF.Authorization.Modelo;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace WCF.Authorization.Behaviors
{
    public class TokenValidationInspector : IDispatchMessageInspector
    {
        public static readonly string AllowAnonymousSvcPages = "AllowAnonymousSvcPages";
        public static readonly string AllowAnonymousSvcHelpPages = "AllowAnonymousSvcHelpPages";
        private clsCredencialTokenValidador objCredencialValidador = new clsCredencialTokenValidador();

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Return BadRequest if request is null
            if (WebOperationContext.Current == null) { throw new WebFaultException(HttpStatusCode.BadRequest); }

            if (IsAnonymousAllowed(request.Headers.To.AbsolutePath))
                return null;
            //

            var cServicio = request.Headers.To.Segments[1];
            var cApi = request.Headers.To.Segments[request.Headers.To.Segments.Length - 2];
            var cMetodo = request.Headers.To.Segments[request.Headers.To.Segments.Length - 1];

            switch(cServicio)
            {
                case "CRAndes.svc/":
                    const int idApiCajaLosAndes = 1;

                    switch (cMetodo)
                    {
                        case "Authenticate":
                            break;
                        case "EncenderServicio":
                        case "ApagarServicio":
                        case "ObtenerEstServ":
                            var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

                            if (string.IsNullOrWhiteSpace(cAuthorization))
                            {
                                throw new WebFaultException(HttpStatusCode.Forbidden);
                            }

                            var cToken = cAuthorization.Substring(7);
                            var varToken = new JwtSecurityToken(jwtEncodedString: cToken);

                            clsUsuario objUsuario = new clsUsuario();
                            objUsuario.idPDPUsuarioAuth = Convert.ToInt32(varToken.Claims.First(c => c.Type == "EmpId").Value);
                            objUsuario.cUsuario = Convert.ToString(varToken.Claims.First(c => c.Type == "Email").Value);
                            objUsuario.cPassword = Convert.ToString(varToken.Claims.First(c => c.Type == "Password").Value);
                            objUsuario.dFecReg = DateTime.Now;

                            ValidateTokenJWT(objUsuario.idPDPUsuarioAuth, idApiCajaLosAndes, cToken);
                            break;
                        default:
                            throw new WebFaultException(HttpStatusCode.Forbidden);
                    }
                    break;
                case "CallCenter.svc/":
                    const int idApiEmpresaCallCenter = 2;

                    break;
                case "KasNet.svc/":
                    const int idApiEmpresaKasNet = 3;

                    switch (cMetodo)
                    {
                        case "auth":
                            break;
                        case "debtconsult":
                        case "create":
                        case "cancel":
                            var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
                            
                            if (string.IsNullOrWhiteSpace(cAuthorization))
                            {
                                throw new WebFaultException(HttpStatusCode.Forbidden);
                            }                            
                            
                            var cToken = cAuthorization.Substring(7);                            
                            var varToken = new JwtSecurityToken(jwtEncodedString: cToken);
                            
                            clsUsuario objUsuario = new clsUsuario();
                            objUsuario.idPDPUsuarioAuth = Convert.ToInt32(varToken.Claims.First(c => c.Type == "EmpId").Value);
                            objUsuario.cUsuario = Convert.ToString(varToken.Claims.First(c => c.Type == "Email").Value);
                            objUsuario.cPassword = Convert.ToString(varToken.Claims.First(c => c.Type == "Password").Value);
                            objUsuario.dFecReg = DateTime.Now;

                            ValidateTokenJWT(objUsuario.idPDPUsuarioAuth, idApiEmpresaKasNet, cToken);
                            break;                            
                    }
                    break;
                case "Bim.svc/":
                    const int idApiEmpresaPdp = 4;

                    switch (cMetodo)
                    {
                        case "auth":
                            break;
                        case "debtconsult":
                        case "create":
                        case "cancel":
                            var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

                            if (string.IsNullOrWhiteSpace(cAuthorization))
                            {
                                throw new WebFaultException(HttpStatusCode.Forbidden);
                            }

                            var cToken = cAuthorization.Substring(7);
                            var varToken = new JwtSecurityToken(jwtEncodedString: cToken);

                            clsUsuario objUsuario = new clsUsuario();
                            objUsuario.idPDPUsuarioAuth = Convert.ToInt32(varToken.Claims.First(c => c.Type == "EmpId").Value);
                            objUsuario.cUsuario = Convert.ToString(varToken.Claims.First(c => c.Type == "Email").Value);
                            objUsuario.cPassword = Convert.ToString(varToken.Claims.First(c => c.Type == "Password").Value);
                            objUsuario.dFecReg = DateTime.Now;

                            ValidateTokenJWT(objUsuario.idPDPUsuarioAuth, idApiEmpresaPdp, cToken);
                            break;
                    }
                    break;
                default:
                    return null;
            }
            
            return true;
        }

        private static bool IsAnonymousAllowed(string absolutePath)
        {
            return (ConfigurationManager.AppSettings.Get(AllowAnonymousSvcPages, true)
                    && absolutePath.EndsWith(".svc"))
                   || (ConfigurationManager.AppSettings.Get(AllowAnonymousSvcHelpPages, true)
                       && absolutePath.Contains("/help"));
        }

        private static void ValidateToken(int idAPIUsuarioAuth, int idApiEmpresa, string cToken)
        {
            clsToken objToken = new clsToken();

            if (!(new clsTokenValidador().TokenValido(ref objToken, idAPIUsuarioAuth, idApiEmpresa, cToken)))
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }            

            WebOperationContext.Current.IncomingRequest.Headers.Add("idUsuario", objToken.idPDPUsuarioAuth.ToString());
            WebOperationContext.Current.IncomingRequest.Headers.Add("dFecCrea", objToken.dFecCrea.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private static void ValidateTokenJWT(int idAPIUsuarioAuth, int idApiEmpresa, string cToken)
        {
            if (!(new clsTokenValidador().TokenValido(idAPIUsuarioAuth, idApiEmpresa, cToken)))
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }

        private static void ValidateBasicAuthentication()
        {
            var authorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(authorization))
            {
                throw new WebFaultException(HttpStatusCode.Forbidden);
            }

            var basicAuth = new BasicAuth(authorization);            
        }

        private static void ValidateJWTAuthentication()
        {
            var cAuthorization = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            var cToken = cAuthorization.Substring(7);
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}