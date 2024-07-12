using DEP.AccesoDatos.AhorroWeb;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;

namespace DEP.CapaNegocio.AhorroWeb
{
    public class clsCNAWPreApertura
    {
        #region Variables Privadas
        private clsADAWPreApertura objADAWPreApertura;
        private clsCNAWGeneral objCNAWGeneral;
        #endregion

        #region Variables Públicas
        public clsAWLog objAWLog;
        public clsAWPersonaReniec objAWPersonaReniec;
        public clsAWCliente objAWCliente;
        public clsAWTramite objAWTramite;
        #endregion

        #region Constructores
        public clsCNAWPreApertura(bool lConexion, clsAWTramite objAWTramite)
        {
            this.objAWTramite = objAWTramite;

            this.objADAWPreApertura = new clsADAWPreApertura(true);
            this.objCNAWGeneral = new clsCNAWGeneral(true, objAWTramite);
            this.objAWLog = this.objCNAWGeneral.obtenerLog(this.objAWTramite.cDocumentoID);
        }
        #endregion

        #region Métodos Públicos
        public void registrarFallo(string cEstado)
        {
            this.objAWLog.cEstado = "FALLO PRE_APERTURA => " + cEstado;
            this.objCNAWGeneral.registrarLog("update", this.objAWLog);
        }

        public List<clsAWBaseNegativa> buscarBaseNegativa(string cDocumentoID)
        {            
            DataTable dt = this.objADAWPreApertura.buscarBaseNegativa(cDocumentoID);
            return dt.ToList<clsAWBaseNegativa>().ToList<clsAWBaseNegativa>();
        }

        public clsAWRespuesta captchaValido(bool lValido)
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            if (!lValido)
            {
                objAWRespuesta.respuestaFallida("captcha");
                this.registrarFallo("Captcha");
            }
            return objAWRespuesta;
        }

        public clsAWRespuesta ubigeoPilotoValido()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            if (this.objAWPersonaReniec.cNomDist != "PUNO")
            {
                objAWRespuesta.respuestaFallida("piloto");
                this.registrarFallo("Ubigeo Piloto");
            }
            return objAWRespuesta;
        }

        public clsAWRespuesta dniValido()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            string dFechaEmision = objAWTramite.dFechaEmision.ToString("yyyyMMdd");            
            clsAWRestriccionPersona objAWRestriccionPersona = this.objCNAWGeneral.obtenerRestriccionPersona(this.objAWTramite.cDocumentoID);
            Regex pattern = new Regex("^[A-Za-zñÑ]+( [A-Za-zñÑ]+)*$");
            if (objAWRestriccionPersona != null && objAWRestriccionPersona.lRestringido)
            {
                objAWRespuesta.respuestaFallida("restriccionreniec");
                objAWRespuesta.idCodigo = objAWRestriccionPersona.idCodigo;
                this.registrarFallo("Restricción / Observación RENIEC");
            }
            else if (
                String.IsNullOrEmpty(this.objAWPersonaReniec.cFechaExpe.Trim())
                || !pattern.IsMatch(this.objAWPersonaReniec.cNomDistNac.Trim())
                || !pattern.IsMatch(this.objAWPersonaReniec.cNomProvNac.Trim())
                || !pattern.IsMatch(this.objAWPersonaReniec.cNomDepNac.Trim())
            )
            {
                objAWRespuesta.respuestaFallida("datos-incompletos");
                this.registrarFallo("Datos RENIEC Incompletos");
            }
            else if (!this.objAWPersonaReniec.cDigitoVerif.Equals(objAWTramite.nDigitoVerificador.ToString()))
            {
                objAWRespuesta.respuestaFallida("dni-digito");
                this.registrarFallo("Digito Verificador");
            }
            else if (!this.objAWPersonaReniec.cFechaExpe.Equals(dFechaEmision))
            {
                objAWRespuesta.respuestaFallida("dni-emision");
                this.registrarFallo("Fecha de Emisión");
            }
            return objAWRespuesta;
        }        

        public clsAWRespuesta personaBaseNegativa()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();            
            List<clsAWBaseNegativa> lstAWBaseNegativa = this.buscarBaseNegativa(this.objAWTramite.cDocumentoID);
            if (lstAWBaseNegativa.Count == 0)
                return objAWRespuesta;
            else
            {
                objAWRespuesta.respuestaFallida("basenegativa");
                this.registrarFallo("Base Negativa de Clientes");
            }            
            return objAWRespuesta;            
        }

        public clsAWPersonaPEP buscarPersonaPEP(int idTipoDocumento, string cNumeroDoc, int idCliente)
        {
            clsAWPersonaPEP objAWPersonaPEP = null;
            DataTable dt = this.objADAWPreApertura.buscarPersonaPEP(idTipoDocumento, cNumeroDoc, idCliente);
            if (dt.Rows.Count == 0)
                return null;
            objAWPersonaPEP = dt.Rows[0].ToObject<clsAWPersonaPEP>();             
            return objAWPersonaPEP;
        }

        public clsAWRespuesta personaPEP()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            clsAWPersonaPEP objAWPersonaPEP = this.buscarPersonaPEP(1, objAWTramite.cDocumentoID, 0);
            if (objAWPersonaPEP != null)
            {
                objAWRespuesta.respuestaFallida("pep");
                this.registrarFallo("Persona PEP");
            }
            return objAWRespuesta;
        }

        public List<clsAWCuenta> buscarCuentasVigentes(int idCli, int idProducto)
        {            
            DataTable dt = this.objADAWPreApertura.buscarCuentasVigentes(idCli, idProducto);
            return dt.SoftToList<clsAWCuenta>().ToList<clsAWCuenta>();            
        }

        public clsAWRespuesta cuentaVigente()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            if (this.objAWCliente == null)
                return objAWRespuesta;
            List<clsAWCuenta> lstCuentasVigentes = this.buscarCuentasVigentes(this.objAWCliente.idCli, this.objAWTramite.idProducto);
            if (lstCuentasVigentes.Count > 0)
            {
                objAWRespuesta.respuestaFallida("cuentavigente");
                this.registrarFallo("Cuenta Vigente");
            }
            return objAWRespuesta;
        }

        public clsAWPersonaReniec obtenerPersonaReniec(string cDni, string cNomPadre, string cNomMadre, string cNomDepNac, string cNomProvNac, string cNomDistNac)
        {
            clsAWPersonaReniec objAWPersonaReniec = null;
            DataTable dt = this.objADAWPreApertura.obtenerPersonaReniec(cDni, cNomPadre, cNomMadre, cNomDepNac, cNomProvNac, cNomDistNac);
            if (dt.Rows.Count == 0)
                return null;
            objAWPersonaReniec = dt.Rows[0].ToObject<clsAWPersonaReniec>();
            return objAWPersonaReniec;            
        }

        public clsAWRespuesta validarPersonaReniec()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            clsAWPersonaReniec objAWPersonaReniec = this.obtenerPersonaReniec(
                this.objAWTramite.cDocumentoID,
                this.objAWTramite.cNombrePadre,
                this.objAWTramite.cNombreMadre,
                this.objAWTramite.cDepNacimiento,
                this.objAWTramite.cProNacimiento,
                this.objAWTramite.cDisNacimiento
            );
            objAWRespuesta.datos = objAWPersonaReniec;
            if (
                Convert.ToInt32(objAWPersonaReniec.lNombreMadre) +
                Convert.ToInt32(objAWPersonaReniec.lNombrePadre) +
                Convert.ToInt32(objAWPersonaReniec.lDepartamentoNacimiento) +
                Convert.ToInt32(objAWPersonaReniec.lProvinciaNacimiento) +
                Convert.ToInt32(objAWPersonaReniec.lDistritoNacimiento) >= 3
            )
            {                
            }
            else
            {
                objAWRespuesta.respuestaFallida("identidad");
                this.registrarFallo("Validación de Identidad");
            }
            return objAWRespuesta;
        }

        public clsAWRespuesta rutaArchivos()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            clsAWVariable objAWVariable = this.objCNAWGeneral.obtenerVariable("cRutaArchivosAhorroWeb");
            if (objAWVariable == null)
            {
                objAWRespuesta.respuestaFallida("rutaarchivos");
                this.registrarFallo("Ruta Archivos");
            }
            objAWRespuesta.datos = objAWVariable.cValVar;
            return objAWRespuesta;
        }
        #endregion
    }
}
