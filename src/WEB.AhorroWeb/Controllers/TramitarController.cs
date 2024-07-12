using DEP.CapaNegocio;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WEB.AhorroWeb.Models;
using WEB.AhorroWeb.Utilities;
using EntityLayer;
using ADM.CapaNegocio;
using DEP.CapaNegocio.AhorroWeb;
using GEN.CapaNegocio;
using System.Text.RegularExpressions;

namespace WEB.AhorroWeb.Controllers
{
    public class TramitarController : Controller
    {
        #region Variables Privadas
        private Services objServices = new Services(true);
        private clsCNAWGeneral objCNAWGeneral = new clsCNAWGeneral(true);
        private clsCNAWPreApertura objCNAWPreApertura;
        private clsCNAWApertura objCNAWApertura;        

        private DateTime dFechaSistema = DateTime.Now;
        #endregion        
    
        #region Métodos Públicos
        [RequireHttps]
        public JsonResult IdentificarPersona(clsAWTramite objAWTramite)
        {            
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            this.objCNAWGeneral.setearDatosToken(ref objAWTramite);
            objAWRespuesta = this.objCNAWGeneral.registrarLog(objAWTramite, Request);            
            try
            {                
                this.objCNAWPreApertura = new clsCNAWPreApertura(true, objAWTramite);

                Captcha objCaptcha = new Captcha(objAWTramite.cCaptcha);
                objAWRespuesta = this.objCNAWPreApertura.captchaValido(objCaptcha.captchaValido());
                if (objAWRespuesta.idRespuesta == 0)
                    return Json(objAWRespuesta);                

                objAWRespuesta = this.objServices.consultarPersona(objAWTramite);                
                if (objAWRespuesta.idRespuesta == 0)                
                    return Json(objAWRespuesta);
                this.objCNAWPreApertura.objAWPersonaReniec = objAWRespuesta.datos;

                objAWRespuesta = this.objCNAWPreApertura.dniValido();
                if (objAWRespuesta.idRespuesta == 0)
                    return Json(objAWRespuesta);

                this.objCNAWPreApertura.objAWCliente = this.objCNAWGeneral.buscarCliente(0, objAWTramite.cDocumentoID);
                objAWRespuesta = this.objCNAWPreApertura.personaBaseNegativa();
                if (objAWRespuesta.idRespuesta == 0)
                    return Json(objAWRespuesta);

                objAWRespuesta = this.objCNAWPreApertura.personaPEP();
                if (objAWRespuesta.idRespuesta == 0)
                    return Json(objAWRespuesta);

                clsAWDireccion objAWDireccion = this.objCNAWGeneral.obtenerDireccionReniec(objAWTramite.cDocumentoID);
                Regex pattern = new Regex("^[A-Za-zñÑ]+( [A-Za-zñÑ]+)*$");
                objAWRespuesta.datos = new
                {
                    cDireccion = objAWDireccion.cDireccion,
                    cSexo = this.objCNAWPreApertura.objAWPersonaReniec.cSexo,
                    lDepNacimiento = pattern.IsMatch(this.objCNAWPreApertura.objAWPersonaReniec.cNomDepNac.Trim()),
                    lProNacimiento = pattern.IsMatch(this.objCNAWPreApertura.objAWPersonaReniec.cNomProvNac.Trim()),
                    lDisNacimiento = pattern.IsMatch(this.objCNAWPreApertura.objAWPersonaReniec.cNomDistNac.Trim()),
                    lNombrePadre = pattern.IsMatch(this.objCNAWPreApertura.objAWPersonaReniec.cNomPadre.Trim()),
                    lNombreMadre = pattern.IsMatch(this.objCNAWPreApertura.objAWPersonaReniec.cNomMadre.Trim()),
                };                
            }
            catch (Exception e)
            {
                objAWRespuesta.respuestaFallida("interno");
                this.objCNAWPreApertura.registrarFallo("Excepción Identificar Persona: " + e.ToString());                
            }
            return Json(objAWRespuesta);
        }

        [RequireHttps]
        public JsonResult ValidarCuenta(clsAWTramite objAWTramite)
        {            
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            this.objCNAWGeneral.setearDatosToken(ref objAWTramite);
            this.objCNAWPreApertura = new clsCNAWPreApertura(true, objAWTramite);            
            try
            {
                this.objCNAWPreApertura.objAWCliente = this.objCNAWGeneral.buscarCliente(0, objAWTramite.cDocumentoID);

                objAWRespuesta = this.objCNAWPreApertura.cuentaVigente();
                if (objAWRespuesta.idRespuesta == 0)
                    return Json(objAWRespuesta);
            }
            catch (Exception e)
            {
                objAWRespuesta.respuestaFallida("interno");
                this.objCNAWPreApertura.registrarFallo("Excepción Validar Cuenta: " + e.ToString());                
            }
            return Json(objAWRespuesta);
        }

        [RequireHttps]
        public JsonResult ValidarIdentidad(clsAWTramite objAWTramite)
        {            
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            this.objCNAWGeneral.setearDatosToken(ref objAWTramite);
            this.objCNAWPreApertura = new clsCNAWPreApertura(true, objAWTramite);            
            try
            {
                objAWRespuesta = this.objCNAWPreApertura.validarPersonaReniec();
                if (objAWRespuesta.idRespuesta == 0)
                    return Json(objAWRespuesta);
            }
            catch (Exception e)
            {
                objAWRespuesta.respuestaFallida("interno");
                this.objCNAWPreApertura.registrarFallo("Excepción Validar Identidad: " + e.ToString());
            }
            return Json(objAWRespuesta);
        }

        [RequireHttps]
        public JsonResult EnviarCodigoValidacion(clsAWTramite objAWTramite)
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();            
            this.objCNAWPreApertura = new clsCNAWPreApertura(true, objAWTramite);            
            try
            {
                objAWRespuesta = this.objServices.enviarCodigoValidacion(objAWTramite);
                if (objAWRespuesta.idRespuesta == 0)
                    return Json(objAWRespuesta);                
            }
            catch (Exception e)
            {
                objAWRespuesta.respuestaFallida("interno");
                this.objCNAWPreApertura.registrarFallo("Excepción Enviar Código Validación: " + e.ToString());
            }
            return Json(objAWRespuesta);
        }

        [RequireHttps]
        public JsonResult RutaArchivos(clsAWTramite objAWTramite)
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            this.objCNAWGeneral.setearDatosToken(ref objAWTramite);
            this.objCNAWPreApertura = new clsCNAWPreApertura(true, objAWTramite);            
            try
            {
                objAWRespuesta = this.objCNAWPreApertura.rutaArchivos();
                if (objAWRespuesta.idRespuesta == 0)
                    return Json(objAWRespuesta);
            }
            catch (Exception e)
            {
                objAWRespuesta.respuestaFallida("interno");
                this.objCNAWPreApertura.registrarFallo("Excepción Ruta Archivos: " + e.ToString());
            }
            return Json(objAWRespuesta);
        }

        [RequireHttps]
        public JsonResult ContratarCuenta(clsAWTramite objAWTramite)
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            clsAWRegistrarOperacion objAWRegistrarOperacion = new clsAWRegistrarOperacion();
            this.objCNAWGeneral.setearDatosToken(ref objAWTramite);
            objAWTramite.dFechaInscripcion = null;
            clsAWParametrosTramite objAWParametrosTramite = this.objCNAWGeneral.obtenerParametrosTramite();
            if (objAWParametrosTramite != null)
            {
                objAWTramite.idTipoPago = objAWParametrosTramite.idTipoPago; //AHORRO WEB
                objAWTramite.idCanal = objAWParametrosTramite.idCanal; //AHORRO WEB
            }
            else
            {
                objAWTramite.idTipoPago = 1; //EFECTIVO
                objAWTramite.idCanal = 1; //VENTANILLA
            }
            objAWTramite.cMoneda = objAWTramite.idMoneda == 1 ? "SOLES" : "DÓLARES";
            this.objCNAWApertura = new clsCNAWApertura(true, objAWTramite);

            objAWRespuesta = this.objCNAWApertura.validarCodigoValidacion();
            if (objAWRespuesta.idRespuesta == 0)
                return Json(objAWRespuesta);

            objAWRegistrarOperacion = this.objCNAWApertura.registrarOperacion();
            if (objAWRegistrarOperacion.idRespuesta == 0)
                return Json(objAWRegistrarOperacion);
            
            objAWRespuesta = this.objCNAWApertura.registrarCanal();

            objAWRespuesta = this.objServices.enviarMensajeConfirmacion(objAWTramite, objAWRegistrarOperacion);
            if (objAWRespuesta.idRespuesta == 0)
                objAWTramite.lMensajeConfirmacion = false;
            else
                objAWTramite.lMensajeConfirmacion = true;

            objAWRespuesta = this.objCNAWApertura.enviarCorreo();
            if (objAWRespuesta.idRespuesta == 0)
                objAWTramite.lCorreoConfirmacion = false;
            else
                objAWTramite.lCorreoConfirmacion = true;

            objAWRespuesta = this.objCNAWApertura.registrarLog();

            objAWRespuesta = this.objCNAWApertura.registrarTramite();

            this.objCNAWApertura.objAWTramite = objAWTramite;
            objAWRespuesta.datos = new
            {
                cCuenta = objAWRegistrarOperacion.cCuenta,
                cFechaHora = objAWRegistrarOperacion.cFechaHora
            };            
            return Json(objAWRespuesta);
        }
        #endregion
    }
}
