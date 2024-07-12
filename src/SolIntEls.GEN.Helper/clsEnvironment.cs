using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.IO;
using System.Xml;

namespace SolIntEls.GEN.Helper
{
    public class clsEnvironment
    {
        private string cRutaConexion;

        public clsConexionWcf CargarArchivoEnvironment()
        {
            string dir = Directory.GetCurrentDirectory();

            string file = dir + @"\Environment\environment";
            StreamReader objReader = new StreamReader(file);
            cRutaConexion = objReader.ReadLine();
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(@cRutaConexion); 
            return new clsConexionWcf(xDoc);
        }
    }
}
