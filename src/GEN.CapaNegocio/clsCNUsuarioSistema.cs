using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Data.SqlClient;
using SolIntEls.GEN.Helper;
using EntityLayer;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace GEN.CapaNegocio
{
    public class clsCNUsuarioSistema
    {
        #region Variables Globales

        private string claveUs;
        private string CodigoAcDi;
        public static string codPer;
        public static string nomPer;
        public string cCodigoApl = "COR";
        public string cDesCodApl = "";
        public static string cCodigoPer;
        public static string cOficin;
        public static string cCodOfi;
        public static string cCodDesArea;
        public static Dictionary<string, Guid> dicTokens = new Dictionary<string, Guid>();

        public string clave
        {
            get { return claveUs; }
            set { claveUs = value; }
        }
        public string CodigoAD
        {
            get { return CodigoAcDi; }
            set { CodigoAcDi = value; }
        }
        public string CodPerson
        {
            get { return codPer; }
            set { codPer = value; }
        }
        public string CodOficin
        {
            get { return cCodOfi; }
            set { cCodOfi = value; }
        }
        public string NomPerson
        {
            get { return nomPer; }
            set { nomPer = value; }
        }
        public string CodPerfil
        {
            get { return cCodigoPer; }
            set { cCodigoPer = value; }
        }
        public string DesOficin
        {
            get { return cOficin; }
            set { cOficin = value; }
        }
        public string CodDesArea
        {
            get { return cCodDesArea; }
            set { cCodDesArea = value; }

        }

        #endregion

        #region Eventos

        public int ValiUsuDA()
        {
            string user;
            string _Glob = "CAJALOSANDES";//nombre del equipo del dominio
            string _path = "LDAP://" + _Glob;
            string domainAndUsername = CodigoAD;
            AuthenticationTypes atAuthentType = new AuthenticationTypes();
            atAuthentType = AuthenticationTypes.Secure;
            DirectoryEntry deDirEntry = new DirectoryEntry();
            deDirEntry = new DirectoryEntry(_path, domainAndUsername, claveUs, atAuthentType);
            try
            {
                user = deDirEntry.Name;
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool ValiUsuSQL(string UsuSql,string PassUsuSql, bool lMensaje = false)
        {
            try
            {
                if (clsPassword.lCambioClave && clsPassword.cUltimaClave == PassUsuSql)
                {
                    if (lMensaje)
                        MessageBox.Show("Ingrese un Usuario y Contraseña Válidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                using (SqlConnection Conexion = new SqlConnection())
                {                    
                    Conexion.ConnectionString = clsGENConexion.leeXML()[0].ToString();
                    Conexion.Open();                    
                    Conexion.Close();
                    Conexion.Dispose();                    
                    return true;
                }
            } 
            catch (Exception ex)
            {
                if (ex.Message.Contains("The password of the account has expired"))
                {
                    if (lMensaje)
                        MessageBox.Show("Su contraseña ha expirado. Solicite el cambio por Mesa de Ayuda", "Expiración de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (ex.Message.Contains("because the account is currently locked out"))
                {
                    if (lMensaje)
                        MessageBox.Show("El usuario está actualmente bloqueado.", "Usuario Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (ex.Message.Contains("Login failed"))
                {
                    if (lMensaje)
                        MessageBox.Show("Ingrese un Usuario y Contraseña Válidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public bool ValiUsuSQLWCF(string UsuSql, string PassUsuSql)
        {
            try
            {
                using (SqlConnection Conexion = new SqlConnection())
                {
                    Conexion.ConnectionString = clsGENConexion.leeXML_WCF()[0].ToString();
                    Conexion.Open();
                    Conexion.Close();
                    Conexion.Dispose();
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Login failed"))
                {
                    return false;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public string GeneraToken(clsDatosToken datosToken)
        {
            if (datosToken == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, datosToken);
            byte[] bDatos = ms.ToArray();
            if (!dicTokens.ContainsKey(datosToken.cImei))
            {
                dicTokens.Add(datosToken.cImei, datosToken.guidUser);
            }
            else
            {
                dicTokens[datosToken.cImei] = datosToken.guidUser;
            }
            string token = Convert.ToBase64String(bDatos);
            return token;
        }

        public clsDatosToken obtenerDatosToken(string token)
        {
            try
            {
                byte[] datos = Convert.FromBase64String(token);
                return (clsDatosToken)ByteArrayToObject(datos);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        public bool validaToken(string token)
        {
            try
            {
                clsDatosToken objToken = obtenerDatosToken(token);
                if (!dicTokens.ContainsKey(objToken.cImei))
                {
                    return false;
                }
                if(!(dicTokens[objToken.cImei] == objToken.guidUser))
                {
                    return false;
                }
                clsVarAplClone objVarApl = new clsVarAplClone();
                new clsCNVarApl().GetVarApl(objToken.idAgencia, objVarApl);
                int nTiempoExpiraToken = Convert.ToInt32(objVarApl.dicVarGen["nTiempoExpiraToken"]);
                if (objToken.dInicioSession < DateTime.UtcNow.AddMinutes(nTiempoExpiraToken * -1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool validaTokenWCF(string token)
        {
            try
            {
                clsDatosToken objToken = obtenerDatosToken(token);
                if (!dicTokens.ContainsKey(objToken.cImei))
                {
                    return false;
                }
                if (!(dicTokens[objToken.cImei] == objToken.guidUser))
                {
                    return false;
                }
                int nTiempoExpiraToken = 60;
                if (objToken.dInicioSession < DateTime.UtcNow.AddMinutes(nTiempoExpiraToken * -1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
