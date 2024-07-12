using DEP.AccesoDatos.AhorroWeb;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using GEN.CapaNegocio;

namespace DEP.CapaNegocio.AhorroWeb
{
    public class clsCNAWGeneral
    {
        #region Variables Privadas
        private clsADAWGeneral objADAWGeneral;
        #endregion

        #region Variables Públicas
        public int idAgencia;
        public int idUsuario;
        public DateTime dFechaSistema;
        public int idTipoPago;
        public int idCanal;
        #endregion

        #region Constructores
        public clsCNAWGeneral()
        {
            this.objADAWGeneral = new clsADAWGeneral();
        }        

        public clsCNAWGeneral(bool lConexion)
        {
            this.objADAWGeneral = new clsADAWGeneral(true);
        }

        public clsCNAWGeneral(bool lConexion, clsAWTramite objAWTramite)
        {
            this.objADAWGeneral = new clsADAWGeneral(true);

            this.idAgencia = objAWTramite.idAgencia;
            this.idUsuario = objAWTramite.idUsuario;
            this.dFechaSistema = objAWTramite.dFechaSistema;
            this.idTipoPago = objAWTramite.idTipoPago;
            this.idCanal = objAWTramite.idCanal;
        }
        #endregion

        #region Métodos Públicos
        public clsAWRespuesta registrarLog(clsAWTramite objAWTramite, dynamic Request)
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            clsAWLog objAWLog = new clsAWLog();
            objAWLog.cAgenteUsuario = Request.UserAgent;
            objAWLog.cDireccionIP = Request.UserHostAddress;
            objAWLog.cDocumentoID = objAWTramite.cDocumentoID;
            objAWLog.cCodigoValidacion = new Random().Next(100000, 999999).ToString();
            objAWLog.cNumeroCelular = objAWTramite.cNumeroCelular1;
            objAWLog.cOperadorCelular = objAWTramite.cOperadorCelular1;
            this.registrarLog("insert", objAWLog);
            return objAWRespuesta;
        }

        public List<clsAWProducto> obtenerProductos(int idAgencia)
        {
            DataTable dt = this.objADAWGeneral.obtenerProductos(idAgencia);
            return dt.SoftToList<clsAWProducto>().ToList<clsAWProducto>();
        }

        public List<clsAWMoneda> obtenerMonedas()
        {
            DataTable dt = this.objADAWGeneral.obtenerMonedas();
            List<clsAWMoneda> lst = dt.SoftToList<clsAWMoneda>().ToList<clsAWMoneda>();
            lst.RemoveAt(0);
            return lst;
        }

        public List<clsAWProfesion> obtenerProfesiones()
        {
            DataTable dt = this.objADAWGeneral.obtenerProfesiones();
            return dt.SoftToList<clsAWProfesion>().ToList<clsAWProfesion>();
        }

        public List<clsAWActividadInterna> obtenerActividadesInternas()
        {
            DataTable dt = this.objADAWGeneral.obtenerActividadesInternas();
            return dt.SoftToList<clsAWActividadInterna>().ToList<clsAWActividadInterna>();
        }

        public clsAWRegistroLog registrarLog(string cSql, clsAWLog objAWLog)
        {
            clsAWRegistroLog objAWRegistroLog = new clsAWRegistroLog();
            List<object> parametros = clsUtils.ObjectToParams(objAWLog);
            parametros.Add(cSql);
            DataTable dt = this.objADAWGeneral.registrarLog(parametros.ToArray());            
            return objAWRegistroLog;
        }

        public clsAWVariable obtenerVariable(string cVariable)
        {
            clsAWVariable objAWVariable = null;
            DataTable dt = this.objADAWGeneral.obtenerVariable(cVariable);
            if (dt.Rows.Count == 1)
                objAWVariable = dt.Rows[0].ToObject<clsAWVariable>();
            return objAWVariable;
        }

        public clsAWLog obtenerLog(string cDocumentoID)
        {
            DataTable dt = this.objADAWGeneral.obtenerLog(cDocumentoID);
            return dt.Rows[0].ToObject<clsAWLog>();
        }

        public clsAWPersonaReniec buscarPersonaReniec(string cDniF)
        {
            clsAWPersonaReniec objAWPersonaReniec = null;
            DataTable dt = this.objADAWGeneral.buscarPersonaReniec(cDniF);
            if (dt.Rows.Count == 1)
                objAWPersonaReniec = dt.Rows[0].ToObject<clsAWPersonaReniec>();
            return objAWPersonaReniec;
        }

        public clsAWCliente buscarCliente(int idCli, string cDocumentoID)
        {
            clsAWCliente objAWCliente = null;
            DataTable dt = this.objADAWGeneral.buscarCliente(idCli, cDocumentoID);
            if (dt.Rows.Count == 1)
                objAWCliente = dt.Rows[0].ToObject<clsAWCliente>();
            return objAWCliente;
        }

        public clsAWDireccion obtenerDireccionReniec(string cDocumentoID)
        {
            clsAWDireccion clsAWDireccion = null;
            DataTable dt = this.objADAWGeneral.obtenerDireccionReniec(cDocumentoID);
            if (dt.Rows.Count == 1)
                clsAWDireccion = dt.Rows[0].ToObject<clsAWDireccion>();
            return clsAWDireccion;
        }

        public List<clsAWPerfil> obtenerPerfiles(int idUsuario)
        {
            List<clsAWPerfil> lstAWPerfil = new List<clsAWPerfil>();
            DataTable dt = this.objADAWGeneral.obtenerPerfiles(idUsuario, DateTime.Now, 0);
            lstAWPerfil = dt.SoftToList<clsAWPerfil>().ToList<clsAWPerfil>();
            return lstAWPerfil;
        }

        public List<clsAWAgencia> obtenerAgencias(int idUsuario)
        {
            List<clsAWAgencia> lstAWPerfil = new List<clsAWAgencia>();
            DataTable dt = this.objADAWGeneral.obtenerAgencias(idUsuario);
            lstAWPerfil = dt.SoftToList<clsAWAgencia>().ToList<clsAWAgencia>();
            return lstAWPerfil;
        }

        public void setearDatosToken(ref clsAWTramite objAWTramite)
        {
            clsCNUsuarioSistema objCNUsuarioSistema = new clsCNUsuarioSistema();
            clsDatosToken objDatosToken = new clsDatosToken();
            objDatosToken = objCNUsuarioSistema.obtenerDatosToken(objAWTramite.cToken);
            objAWTramite.idUsuario = objDatosToken.idUsuario;
            objAWTramite.idAgencia = objDatosToken.idAgencia;
            objAWTramite.dFechaSistema = objDatosToken.dFechaSistema;     
        }

        public string obtenerDocumentoAutorizado(int idModulo)
        {
            string cDocumentoID = null;
            DataTable dt = this.objADAWGeneral.obtenerDocumentoAutorizado(idModulo);
            if (dt.Rows.Count == 1)
                cDocumentoID = dt.Rows[0]["cDocumentoID"].ToString();
            return cDocumentoID;
        }

        public clsAWRestriccionPersona obtenerRestriccionPersona(string cDocumentoID)
        {
            clsAWRestriccionPersona objAWRestriccionPersona = null;
            DataTable dt = this.objADAWGeneral.obtenerRestriccionPersona(cDocumentoID);            
            if (dt.Rows.Count == 1)
                objAWRestriccionPersona = dt.Rows[0].ToObject<clsAWRestriccionPersona>();
            return objAWRestriccionPersona;
        }

        public clsAWParametrosTramite obtenerParametrosTramite()
        {
            clsAWParametrosTramite objAWParametrosTramite = null;
            DataTable dt = this.objADAWGeneral.obtenerParametrosTramite();
            if (dt.Rows.Count == 1)
                objAWParametrosTramite = dt.Rows[0].ToObject<clsAWParametrosTramite>();
            return objAWParametrosTramite;
        }

        public List<clsAWObjetivoAhorro> ObtenerObjetosAhorro()
        {
            DataTable dt = this.objADAWGeneral.ObtenerObjetosAhorro();
            return dt.SoftToList<clsAWObjetivoAhorro>().ToList<clsAWObjetivoAhorro>();
        }
        #endregion
    }
}
