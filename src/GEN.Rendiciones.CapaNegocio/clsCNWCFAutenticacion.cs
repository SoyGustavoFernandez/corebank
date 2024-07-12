using EntityLayer;
using GEN.CapaNegocio;
using GEN.Rendiciones.AccesoDatos;
using Rendiciones.EntityLayer;
using clsWCFUsuario_R = Rendiciones.EntityLayer.clsWCFUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using System.Collections;
using SolIntEls.GEN.Helper;
using System.Data.SqlClient;
using System.Data;

namespace GEN.Rendiciones.CapaNegocio
{
    public class clsCNWCFAutenticacion
    {
        #region propiedades privadas
        private clsCNUsuarioSistema objCNUsuarioSistema;
        private clsCNFuenteDatos objCNFuenteDatos;
        private clsADWCFAutenticacion objADWCFAutenticacion;
        private clsCNUsuario objCNUsuario;
        private DateTime dFechaSistema;
        #endregion

        public clsCNWCFAutenticacion()
        {
            this.objCNUsuarioSistema = new clsCNUsuarioSistema();
            this.objADWCFAutenticacion = new clsADWCFAutenticacion();
            this.objCNFuenteDatos = new clsCNFuenteDatos();
            this.objCNUsuario = new clsCNUsuario();
            this.dFechaSistema = Convert.ToDateTime(this.objCNFuenteDatos.obtenerVariable("dFechaAct").cValVar);
        }

        #region metodos publicos
        public clsWCFUsuario_R obtenerDatosUsuario(string cToken)
        {
            clsDatosToken objDatosToken = this.obtenerDatosToken(cToken);
            DataTable dt = this.objADWCFAutenticacion.obtenerDatosUsuario(
                objDatosToken.idUsuario,
                objDatosToken.idAgencia,
                objDatosToken.idPerfil
            );
            clsWCFUsuario_R obj = dt.Rows[0].ToObject<clsWCFUsuario_R>();
            obj.dFechaSistema = objDatosToken.dFechaSistema;
            return obj;
        }

        public clsDatosToken obtenerDatosToken(string cToken)
        {
            return this.objCNUsuarioSistema.obtenerDatosToken(cToken);            
        }

        public bool validarToken(string cToken)
        {
            return this.objCNUsuarioSistema.validaToken(cToken);
        }

        public clsWCFUsuario_R identificarUsuario(clsWCFUsuario_R objWCFUsuario)
        {            
            clsWCFAutenticacionUsuario objWCFAutenticacionUsuario = this.autenticarUsuarioSQLWCF(objWCFUsuario.cWinUser, objWCFUsuario.cPassword);
            if (!objWCFAutenticacionUsuario.lAutenticado)
            {
                objWCFUsuario.lIdentificado = false;
                objWCFUsuario.cRespuesta = objWCFAutenticacionUsuario.cError;
                return objWCFUsuario;
            }

            clsUsuario objUsuario = new clsUsuario();
            if (!this.objCNUsuario.ValidarUsuarioWCF(objWCFUsuario.cWinUser, ref objUsuario))
            {
                objWCFUsuario.lIdentificado = false;
                objWCFUsuario.cRespuesta = "Falló Validar Login";
                return objWCFUsuario;
            }
            
            this.obtenerAgenciasPerfiles(ref objWCFUsuario, objUsuario.idUsuario);
            if (objWCFUsuario.lstAgencia.Count == 0)
            {
                objWCFUsuario.lIdentificado = false;
                objWCFUsuario.cRespuesta = "El usuario no tiene agencias asignadas.";
                return objWCFUsuario;
            }
            if (objWCFUsuario.lstPerfil.Count == 0)
            {
                objWCFUsuario.lIdentificado = false;
                objWCFUsuario.cRespuesta = "El usuario no tiene perfiles asignados.";
                return objWCFUsuario;
            }
            objWCFUsuario.lIdentificado = true;
            objWCFUsuario.cRespuesta = "Identificación Exitosa";
            return objWCFUsuario;
        }

        public clsWCFUsuario_R iniciarSesion(clsWCFUsuario_R objWCFUsuario)
        {            
            clsWCFAutenticacionUsuario objWCFAutenticacionUsuario = this.autenticarUsuarioSQLWCF(objWCFUsuario.cWinUser, objWCFUsuario.cPassword);
            if (!objWCFAutenticacionUsuario.lAutenticado)
            {
                objWCFUsuario.lIdentificado = false;
                objWCFUsuario.cRespuesta = objWCFAutenticacionUsuario.cError;
                return objWCFUsuario;
            }

            clsUsuario objUsuario = new clsUsuario();
            if (!this.objCNUsuario.ValidarUsuarioWCF(objWCFUsuario.cWinUser, ref objUsuario))
            {
                objWCFUsuario.lIdentificado = false;
                objWCFUsuario.cRespuesta = "Falló Validar Login";
                return objWCFUsuario;
            }
            objWCFUsuario.cToken = this.generarToken(objUsuario, objWCFUsuario.idAgencia, objWCFUsuario.idPerfil);
            objWCFUsuario.cNombre= objUsuario.cNomUsu;
            objWCFUsuario.dFechaSistema = this.dFechaSistema;                
            return objWCFUsuario;
        }
        #endregion

        #region metodos privados
        public string generarToken(clsUsuario objUsuario, int idAgencia, int idPerfil)
        {
            clsDatosToken objDatosToken = new clsDatosToken();
            Random rnd = new Random();
            long imei = rnd.Next(100000000, 999999999);
            objDatosToken.cImei = imei.ToString();
            objDatosToken.dFechaSistema = this.dFechaSistema;
            objDatosToken.dInicioSession = DateTime.UtcNow;
            objDatosToken.idUsuario = objUsuario.idUsuario;
            objDatosToken.guidUser = Guid.NewGuid();
            objDatosToken.idPerfil = idPerfil;
            objDatosToken.idAgencia = idAgencia;
            objDatosToken.idEstablecimiento = objUsuario.idEstablecimiento;
            objDatosToken.idTipoEstablecimiento = objUsuario.idTipoEstablec;

            return this.objCNUsuarioSistema.GeneraToken(objDatosToken);
        }

        private clsWCFAutenticacionUsuario autenticarUsuarioSQLWCF(string cWinUser, string cPassword)
        {
            clsWCFAutenticacionUsuario objWCFAutenticacionUsuario = new clsWCFAutenticacionUsuario();
            clsVarGlobal.lisVars.Clear();
            clsPassword.cUsuDB = cWinUser;
            clsPassword.cPassUsuDB = clsPassword.parsearClave(cPassword);
            clsPassword.cRole = "App_Fin";
            clsPassword.cPassRole = "123456789";

            ArrayList arlConexion = new ArrayList();
            arlConexion = clsGENConexion.leeXML_WCF();
            clsVarGlobal.IConectionGen.SetConnectionString((string)arlConexion[0]);
            clsVarGlobal.nIdAgencia = 0;
            clsVarGlobal.nTipoAute = 2;

            clsEnvironment objEnviroment = new clsEnvironment();
            clsConexionWcf objCon = objEnviroment.CargarArchivoEnvironment();

            clsVarGlobal.cRutPathApp = objCon.obtenerPath();
            clsVarGlobal.idCanal = 1;

            try
            {
                using (SqlConnection Conexion = new SqlConnection())
                {
                    Conexion.ConnectionString = clsGENConexion.leeXML_WCF()[0].ToString();
                    Conexion.Open();
                    Conexion.Close();
                    Conexion.Dispose();                    
                }
            }
            catch (Exception ex)
            {
                objWCFAutenticacionUsuario.ex = ex;
                objWCFAutenticacionUsuario.lAutenticado= false;
                if (ex.Message.Contains("The password of the account has expired"))
                {
                    objWCFAutenticacionUsuario.cError = "Su contraseña ha expirado. Solicite el cambio por Mesa de Ayuda";
                }
                else if (ex.Message.Contains("because the account is currently locked out"))
                {
                    objWCFAutenticacionUsuario.cError = "El usuario está actualmente bloqueado.";
                }
                else if (ex.Message.Contains("Login failed"))
                {
                    objWCFAutenticacionUsuario.cError = "Usuario y/o Contraseña no válidos";
                }
                return objWCFAutenticacionUsuario;
            }
            objWCFAutenticacionUsuario.lAutenticado = true;
            return objWCFAutenticacionUsuario;
        }

        private void obtenerAgenciasPerfiles(ref clsWCFUsuario_R objWCFUsuario, int idUsuario)
        {
            DataTable dtAgencia = this.objADWCFAutenticacion.obtenerAgencias(idUsuario);
            objWCFUsuario.lstAgencia = dtAgencia.SoftToList<clsAgencia>().ToList();
            DataTable dtPerfil = this.objADWCFAutenticacion.obtenerPerfiles(idUsuario, DateTime.Now, 0);
            objWCFUsuario.lstPerfil = dtPerfil.SoftToList<clsPerfil>().ToList();
        }
        #endregion
    }
}
