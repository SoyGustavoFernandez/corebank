using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using EntityLayer;


namespace SolIntEls.GEN.Helper
{
    public class clsGENConexion
    {
        public static ArrayList leeXML()
        {
            ArrayList arlConexion = new ArrayList();

            XmlDocument xDoc = new XmlDocument();

            if (clsVarGlobal.nTipoConexion == 1)
            {
                xDoc.Load(@"conexion_alterno.xml"); //la ubicación del archivo XML con el que vamos a trabajar
            }
            else
            {
                xDoc.Load(@"conexion.xml"); //la ubicación del archivo XML con el que vamos a trabajar
            }

            XmlNodeList conexion = xDoc.GetElementsByTagName("conexion");

            XmlNodeList listaDatos = ((XmlElement)conexion[0]).GetElementsByTagName("datos");

            string cadenaConexion = "";

            foreach (XmlElement nodo in listaDatos) //obtenemos el valor de cada uno de los nodos en la lista
            {

                XmlNodeList cserver = nodo.GetElementsByTagName("server");

                XmlNodeList cdatabase = nodo.GetElementsByTagName("database");

                //XmlNodeList crol = nodo.GetElementsByTagName("rol");

                //XmlNodeList cpassword = nodo.GetElementsByTagName("password");

                //XmlNodeList cagencia = nodo.GetElementsByTagName("agencia");

                XmlNodeList cautenticacion = nodo.GetElementsByTagName("autenticacion");

                //AUTENT. WINDOWS 
                if (Convert.ToInt32(cautenticacion[0].InnerText) == 1)
                {
                    cadenaConexion = string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security = SSPI;Pooling = False; Connection Timeout=30", cserver[0].InnerText, cdatabase[0].InnerText);
                }
                //AUTENT. SQL

                else if (Convert.ToInt32(cautenticacion[0].InnerText) == 2)
                {
                    cadenaConexion = string.Format("Data Source={0}; Initial Catalog={1}; User={2}; Password={3}; Connection Timeout=60", cserver[0].InnerText, cdatabase[0].InnerText, clsPassword.cUsuDB, clsPassword.cPassUsuDB);
                }

                arlConexion.Add(cadenaConexion);
                arlConexion.Add(clsPassword.cRole);
                arlConexion.Add(clsPassword.cPassRole);
                arlConexion.Add(0/*cagencia[0].InnerText*/);
                arlConexion.Add(cautenticacion[0].InnerText);
                //clsVarGlobal.nIdAgencia = Convert.ToInt32(cagencia[0].InnerText);

            }


            return arlConexion;

        }


        public static ArrayList leeXML_WCF()
        {
            clsEnvironment objEnviroment = new clsEnvironment();
            clsConexionWcf objCon = objEnviroment.CargarArchivoEnvironment();

            ArrayList arlConexion = new ArrayList();
            arlConexion.Add(objCon.obtenerConexionPrimera());
            arlConexion.Add(clsPassword.cRole);
            arlConexion.Add(clsPassword.cPassRole);
            arlConexion.Add(0/*cagencia[0].InnerText*/);
            arlConexion.Add(objCon.obtenerAutentication());

            return arlConexion;

        }


    }
}
