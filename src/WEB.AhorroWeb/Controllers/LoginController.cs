using DEP.CapaNegocio.AhorroWeb;
using EntityLayer;
using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.AhorroWeb.Controllers
{
    public class LoginController : Controller
    {
        #region Variables Privadas
        private clsCNAWGeneral objCNAWGeneral = new clsCNAWGeneral(); 
        private clsCNUsuarioSistema objCNUsuarioSistema = new clsCNUsuarioSistema();
        #endregion

        #region Métodos Públicos
        public ActionResult Index()
        {
            return View();
        }

        [RequireHttps]
        public JsonResult ValidarUsuario(string cToken)
        {
            bool lUsuarioValido = true;
            if (!this.objCNUsuarioSistema.validaTokenWCF(cToken))
                lUsuarioValido = false;
            return Json(new { lUsuarioValido });
        }

        [RequireHttps]
        public JsonResult AgenciaPerfilUsuario(clsAWUsuario objAWUsuario)
        {
            clsAWRespuestaLogin objAWRespuestaLogin = new clsAWRespuestaLogin();
            try
            {                
                clsVarGlobal.IConectionGen = new ConnectionWeb();
                clsAutenticacion autenticacion = new clsAutenticacion();
                objCNUsuarioSistema.CodigoAD = objAWUsuario.cWinUser.Trim();
                objCNUsuarioSistema.clave = objAWUsuario.cPassword.Trim();
                clsUsuario user = null;
                IList<clsPerfilUsu> lstPerfiles = null;
                clsVarGlobalClone objVarGlobal = null;

                if (autenticacion.AutenticarWCF(objCNUsuarioSistema.CodigoAD, objCNUsuarioSistema.clave, ref user))
                {                    
                    objVarGlobal = new clsVarGlobalClone();
                    lstPerfiles = new clsCNPerfilUsu().ListarPerUsu(user.idUsuario);
                    new clsCNVarGen().GetVarGlobal(1, objVarGlobal);

                    string cListados = String.Empty;

                    if (lstPerfiles.Count == 0)
                    {
                        objAWRespuestaLogin.lIdentificado = false;
                        objAWRespuestaLogin.cMensaje = "El usuario no tiene perfiles asignados";
                    }
                    else
                    {
                        objAWRespuestaLogin.lIdentificado = true;                            
                        objAWUsuario.cPerfil = lstPerfiles.First().cPerfil;
                        objAWUsuario.dFechaSistema = objVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
                        objAWRespuestaLogin.lstAgencias = objCNAWGeneral.obtenerAgencias(user.idUsuario);
                        objAWRespuestaLogin.lstPerfiles = objCNAWGeneral.obtenerPerfiles(user.idUsuario);
                    }
                }
                else
                {
                    objAWRespuestaLogin.lIdentificado = false;
                    objAWRespuestaLogin.cMensaje = "Usuario y/o contraseña no son correctas";
                }
            }
            catch (Exception e)
            {
                objAWRespuestaLogin.lIdentificado = false;
                objAWRespuestaLogin.cMensaje = "Ha ocurrido una excepción";
            }

            return Json(objAWRespuestaLogin);
        }

        [RequireHttps]
        public JsonResult IdentificarUsuario(clsAWUsuario objAWUsuario)
        {
            clsAWRespuestaLogin objAWRespuestaLogin = new clsAWRespuestaLogin();
            try
            {                
                clsVarGlobal.IConectionGen = new ConnectionWeb();
                clsAutenticacion autenticacion = new clsAutenticacion();
                objCNUsuarioSistema.CodigoAD = objAWUsuario.cWinUser.Trim();
                objCNUsuarioSistema.clave = objAWUsuario.cPassword.Trim();
                clsUsuario user = null;
                IList<clsPerfilUsu> lstPerfiles = null;
                clsVarGlobalClone objVarGlobal = null;
                clsDatosToken datosToken = null;


                if (autenticacion.AutenticarWCF(objCNUsuarioSistema.CodigoAD, objCNUsuarioSistema.clave, ref user))
                {
                    objVarGlobal = new clsVarGlobalClone();
                    lstPerfiles = new clsCNPerfilUsu().ListarPerUsu(user.idUsuario);
                    new clsCNVarGen().GetVarGlobal(1, objVarGlobal);

                    datosToken = new clsDatosToken();
                    datosToken.dFechaSistema = objVarGlobal.dFecSystem;
                    datosToken.dInicioSession = DateTime.UtcNow;
                    datosToken.idUsuario = user.idUsuario;
                    datosToken.guidUser = Guid.NewGuid();
                    datosToken.cImei = objAWUsuario.cImei;
                    datosToken.idPerfil = objAWUsuario.idPerfil;
                    datosToken.idAgencia = objAWUsuario.idAgencia;
                    datosToken.idEstablecimiento = user.idEstablecimiento;
                    datosToken.idTipoEstablecimiento = user.idTipoEstablec;

                    string cListados = String.Empty;

                    if (lstPerfiles.Count == 0)
                    {
                        objAWRespuestaLogin.lIdentificado = false;
                        objAWRespuestaLogin.cMensaje = "El usuario no tiene perfiles asignados";
                    }
                    else
                    {
                        objAWRespuestaLogin.lIdentificado = true;

                        clsAWVariable objAWVariable = this.objCNAWGeneral.obtenerVariable("nPerfilValidoAhorroWeb");
                        string[] perfiles = objAWVariable.cValVar.Split(',');
                        foreach (string nPerfil in perfiles)
                        {
                            if (Int32.Parse(nPerfil) == datosToken.idPerfil)
                            {
                                objAWRespuestaLogin.lPerfilValido = true;
                                break;
                            }
                        }
                        if (!objAWRespuestaLogin.lPerfilValido)
                        {                            
                            objAWRespuestaLogin.cMensaje = "Perfil no válido para la aplicación";
                            return Json(objAWRespuestaLogin);
                        }

                        clsAWCliente clsAWCliente = objCNAWGeneral.buscarCliente(user.idCli, "");
                        objAWRespuestaLogin.cNombre = clsAWCliente.cNombre;
                        objAWRespuestaLogin.cToken = objCNUsuarioSistema.GeneraToken(datosToken);
                    }
                }
                else
                {
                    objAWRespuestaLogin.lIdentificado = false;
                    objAWRespuestaLogin.cMensaje = "Usuario y/o contraseña no son correctas";
                }
            }
            catch (Exception e)
            {
                objAWRespuestaLogin.lIdentificado = false;
                objAWRespuestaLogin.cMensaje = "Ha ocurrido una excepción";
            }
            return Json(objAWRespuestaLogin);
        }
        #endregion

    }
}
