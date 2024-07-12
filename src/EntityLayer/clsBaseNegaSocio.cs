using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{
    /// <summary>
    /// entidad base negativa de  socio
    /// </summary>    
    [Serializable]
    public class clsBaseNegaSocio
    {

        public int idBaseNegSoc { get; set; }
        public int idCli { get; set; }
        public string cMotivo { get; set; }
        public int idAgencia { get; set; }
        public int idUsuReg { get; set; }        
        public int idUsuMod { get; set; }
        public int idEstado { get; set; }
        public string cSustento { get; set; }
        public DateTime dFechaReg { get; set; }
        public DateTime dFechaMod { get; set; }
        public string serializar()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, this);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }
    }

    /// <summary>
    /// coleccion base negativa de  socio
    /// </summary>
    public class clsListBaseNegaSocio : List<clsBaseNegaSocio>
    {
    }
     
}
