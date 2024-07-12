using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using GEN.Funciones;

namespace EntityLayer
{
    public class clsConexionWcf
    {
        #region Atributos
        private string cServer;
        private string cDataBase;
        private int idAgencia;
        private int nAutenticacion;
        private string cWinUser;
        private string cPassword;
        private int nTimeOut;
        private string cVersionAndy;
        private string cPathXml;
        #endregion

        #region Métodos públicos
        public clsConexionWcf(XmlDocument cConexion)
        {
            XmlNodeList conexion = cConexion.GetElementsByTagName("conexion");
            XmlNodeList listaDatos = ((XmlElement)conexion[0]).GetElementsByTagName("datos");
            string cadenaConexion = "";
            StringEncryptorDecryptor encryptor = new StringEncryptorDecryptor();

            foreach (XmlElement nodo in listaDatos) //obtenemos el valor de cada uno de los nodos en la lista
            {

                XmlNodeList cserver = nodo.GetElementsByTagName("server");
                XmlNodeList cdatabase = nodo.GetElementsByTagName("database");
                XmlNodeList cAgencia = nodo.GetElementsByTagName("agencia");
                XmlNodeList cUsuario = nodo.GetElementsByTagName("cWinUser");
                XmlNodeList cPass = nodo.GetElementsByTagName("cPassword");
                XmlNodeList cTimeOut = nodo.GetElementsByTagName("nTimeOut");
                XmlNodeList cAutenticacion = nodo.GetElementsByTagName("autenticacion");
                XmlNodeList cVersionAndyColl = nodo.GetElementsByTagName("cVersionAndy");
                XmlNodeList cPath = nodo.GetElementsByTagName("cPathXml");


                this.cServer = cserver[0].InnerText;
                this.cDataBase = cdatabase[0].InnerText;
                this.idAgencia = Convert.ToInt32(cAgencia[0].InnerText);
                this.nAutenticacion = Convert.ToInt32(cAutenticacion[0].InnerText);
                this.cWinUser = encryptor.decryptString(cUsuario[0].InnerText);
                this.cPassword = encryptor.decryptString(cPass[0].InnerText);
                this.nTimeOut = Convert.ToInt32(cTimeOut[0].InnerText);
                this.cVersionAndy = Convert.ToString(cVersionAndyColl[0].InnerText);
                this.cPathXml = Convert.ToString(cPath[0].InnerText);
            }
        }

        public string obtenerConexionPrimera()
        {
            string cadenaConexion = "";
            
            if (nAutenticacion == 1)
            {
                cadenaConexion = string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security = SSPI;Pooling = False; Connection Timeout=30", this.cServer, this.cDataBase);
            }
            //AUTENT. SQL

            else if (nAutenticacion == 2)
            {
                cadenaConexion = string.Format("Data Source={0}; Initial Catalog={1}; User={2}; Password={3}; Connection Timeout=60", this.cServer, this.cDataBase, clsPassword.cUsuDB, clsPassword.cPassUsuDB);
            }

            return cadenaConexion;
        }

        public string obtenerConexionSegunda()
        {
            string cadenaConexion = "";

            cadenaConexion = string.Format("Data Source={0}; Initial Catalog={1}; User={2}; Password={3}; Connection Timeout={4}", this.cServer, this.cDataBase, this.cWinUser, this.cPassword, this.nTimeOut);

            return cadenaConexion;
        }

        public int obtenerAutentication()
        {
            return this.nAutenticacion;
        }

        public string obtenerVersion()
        {
            return this.cVersionAndy;
        }

        public string obtenerPath()
        {
            return this.cPathXml;
        }
        #endregion

    }
}
