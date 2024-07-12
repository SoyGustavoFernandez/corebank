using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using System.Data.SqlClient;
using SolIntEls.GEN.Helper;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using GEN.AccesoDatos;
using GEN.Funciones;

namespace GEN.CapaNegocio
{
    public class clsAutenticacion
    {
        ArrayList arlConexion = new ArrayList();
        clsADUsuario usuario = new clsADUsuario();

        private clsCNUsuarioSistema Usuario = new clsCNUsuarioSistema();

        public bool Autenticar(string cUsu,string cPass)
        {            
            bool res=false;
            clsVarGlobal.lisVars.Clear();
            //Set Variables
            clsPassword.cUsuDB = cUsu;
            clsPassword.cPassUsuDB = clsPassword.parsearClave(cPass);            
            clsPassword.cRole = "App_Fin";
            clsPassword.cPassRole = "123456789";

            //Read XML
            arlConexion = clsGENConexion.leeXML();
            clsVarGlobal.cConexString=(string)arlConexion[0];
            clsVarGlobal.nIdAgencia = 0;//Convert.ToInt32(arlConexion[3]);
            clsVarGlobal.nTipoAute=Convert.ToInt32(arlConexion[4]);
            clsVarGlobal.cRutPathApp = Path.GetDirectoryName(Application.ExecutablePath);
            clsVarGlobal.idCanal = 1;
            //Autenticación Windows
            if (clsVarGlobal.nTipoAute == 1)
            {
                Usuario.CodigoAD = cUsu;
                Usuario.clave = cPass;
                if (Usuario.ValiUsuDA() == 1)
                {
                    if (new clsCNSeguridad().VerUsuEqui(cUsu))
                    {
                        if (new clsCNUsuario().ValidarUsuario(cUsu))
                        {
                            res = true;
                        }
                        else
                        {
                            MessageBox.Show("El Usuario ingresado no pertenece al sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Ingresado es Distinto al que inicio el Equipo:", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no válido, o error al digitar su clave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //Autenticación SQL
            else if (clsVarGlobal.nTipoAute == 2)
            {
                if (Usuario.ValiUsuSQL(cUsu,cPass, true))
                {
                    if (new clsCNUsuario().ValidarUsuario(cUsu))
                    {
                        res = true;
                        clsVarGlobal.User.cPassword = cPass;
                    }
                    else
                    {
                        MessageBox.Show("El Usuario ingresado no pertenece al sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            clsVarGlobal.lEstLogeado = res;
            return res;
        }

        public bool validarLicencia()
        {
            bool lValor = false;

            var cLicencia = usuario.retornarLicencia();

            var cLicenciaBD = clsVarApl.dicVarGen["cLicencia"];

            var cLicenciaCrp = clsCriptografia.EncriptarPassword(cLicencia);

            if (cLicenciaBD.Trim() == cLicenciaCrp.Trim())
            {
                lValor = true;
            }

            return lValor;
        }

        public bool AutenticarUsuActualiza(string cUsu, string cPass)
        {
            bool res = false;
            clsVarGlobal.lisVars.Clear();
            //Set Variables
            clsPassword.cUsuDB = cUsu;            
            clsPassword.cPassUsuDB = clsPassword.parsearClave(cPass);
            clsPassword.cRole = "App_Fin";
            clsPassword.cPassRole = "123456789";

            //Read XML
            arlConexion = clsGENConexion.leeXML();
            clsVarGlobal.cConexString = (string)arlConexion[0];
            clsVarGlobal.nIdAgencia = Convert.ToInt32(arlConexion[3]);
            clsVarGlobal.nTipoAute = Convert.ToInt32(arlConexion[4]);
            clsVarGlobal.cRutPathApp = Path.GetDirectoryName(Application.ExecutablePath);
            clsVarGlobal.idCanal = 1;
            //Autenticación Windows
            if (clsVarGlobal.nTipoAute == 1)
            {
                if (Usuario.ValiUsuDA() == 1)
                {
                    if (new clsCNSeguridad().VerUsuEqui(cUsu))
                    {
                        res = true;
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Ingresado es Distinto al que inicio el Equipo:", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no válido, o error al digitar su clave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //Autenticación SQL
            else if (clsVarGlobal.nTipoAute == 2)
            {
                if (Usuario.ValiUsuSQL(cUsu, cPass))
                {
                    res = true;
                }
                else
                {
                    MessageBox.Show("Ingrese un Usuario y Contraseña Válidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            clsVarGlobal.lEstLogeado = res;
            return res;
        }

        public bool ValidarCredenciales(string cUsu, string cPass)
        {
            bool res = false;
            //Set Variables
            clsPassword.cUsuDB = cUsu;            
            clsPassword.cPassUsuDB = clsPassword.parsearClave(cPass);
            clsPassword.cRole = "App_Fin";
            clsPassword.cPassRole = "123456789";

            //Read XML
            arlConexion = clsGENConexion.leeXML();
            string cConexString = Convert.ToString(arlConexion[0]);
            int nIdAgencia = Convert.ToInt32(arlConexion[3]);
            int nTipoAute = Convert.ToInt32(arlConexion[4]);
            string cRutPathApp = Path.GetDirectoryName(Application.ExecutablePath);
            //Autenticación Windows
            if (nTipoAute == 1)
            {
                if (Usuario.ValiUsuDA() == 1)
                {
                    if (new clsCNUsuario().ValidarUsuarioGen(cUsu))
                    {
                        res = true;
                    }
                    else
                    {
                        MessageBox.Show("El usuario ingresado no pertenece al sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no válido, o error al digitar su clave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            //Autenticación SQL
            else if (clsVarGlobal.nTipoAute == 2)
            {
                if (Usuario.ValiUsuSQL(cUsu, cPass))
                {
                    if (new clsCNUsuario().ValidarUsuarioGen(cUsu))
                    {
                        res = true;
                    }
                    else
                    {
                        MessageBox.Show("El Usuario ingresado no pertenece al sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un Usuario y Contraseña Válidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return res;
        }

        public bool AutenticarWeb(string cUsuario, string cClave,ref clsUsuario user)
        {
            bool res = false;
            clsVarGlobal.lisVars.Clear();
            //Set Variables
            clsPassword.cUsuDB = cUsuario;
            clsPassword.cPassUsuDB = clsPassword.parsearClave(cClave);
            clsPassword.cRole = "App_Fin";
            clsPassword.cPassRole = "123456789";

            //Read XML
            arlConexion = clsGENConexion.leeXML();
            clsVarGlobal.IConectionGen.SetConnectionString((string)arlConexion[0]);
            //clsVarGlobal.cConexString = (string) arlConexion[0];
            clsVarGlobal.nIdAgencia = 0;
            clsVarGlobal.nTipoAute = Convert.ToInt32(arlConexion[4]);
            clsVarGlobal.cRutPathApp = Path.GetDirectoryName(Application.ExecutablePath);
            clsVarGlobal.idCanal = 1;
            //Autenticación Windows
            if (clsVarGlobal.nTipoAute == 1)
            {
                if (Usuario.ValiUsuDA() == 1)
                {
                    if (new clsCNSeguridad().VerUsuEqui(cUsuario))
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    res = false;
                }
            }

            //Autenticación SQL
            else if (clsVarGlobal.nTipoAute == 2)
            {
                if (Usuario.ValiUsuSQL(cUsuario, cClave))
                {
                    if (new clsCNUsuario().ValidarUsuario(cUsuario, ref user))
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    res = false;
                }
            }
            return res;
        }

        public bool AutenticarWCF(string cUsuario, string cClave,ref clsUsuario user)
        {
            bool res = false;
            clsVarGlobal.lisVars.Clear();
            //Set Variables
            clsPassword.cUsuDB = cUsuario;            
            clsPassword.cPassUsuDB = clsPassword.parsearClave(cClave);
            clsPassword.cRole = "App_Fin";
            clsPassword.cPassRole = "123456789";

            //Read XML
            arlConexion = clsGENConexion.leeXML_WCF();
            clsVarGlobal.IConectionGen.SetConnectionString((string)arlConexion[0]);
            //clsVarGlobal.cConexString = (string) arlConexion[0];
            clsVarGlobal.nIdAgencia = 0;
            clsVarGlobal.nTipoAute = Convert.ToInt32(arlConexion[4]);
            //clsVarGlobal.cRutPathApp = Path.GetDirectoryName(Application.ExecutablePath);
       
            clsEnvironment objEnviroment = new clsEnvironment();
            clsConexionWcf objCon = objEnviroment.CargarArchivoEnvironment();

            clsVarGlobal.cRutPathApp = objCon.obtenerPath();
            clsVarGlobal.idCanal = 1;
            //Autenticación Windows
            if (clsVarGlobal.nTipoAute == 1)
            {
                if (Usuario.ValiUsuDA() == 1)
                {
                    if (new clsCNSeguridad().VerUsuEqui(cUsuario))
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    res = false;
                }
            }

            //Autenticación SQL
            else if (clsVarGlobal.nTipoAute == 2)
            {
                if (Usuario.ValiUsuSQLWCF(cUsuario, cClave))
                {
                    if (new clsCNUsuario().ValidarUsuarioWCF(cUsuario, ref user))
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    res = false;
                }
            }
            return res;
        }
    }
}
