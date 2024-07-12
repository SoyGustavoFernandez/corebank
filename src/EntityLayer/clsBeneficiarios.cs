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
    ///
    /// </summary>
    public class clsBeneficiario
    {
        public int idBeneficiario { get; set; }
        public int idCli { get; set; }
        public int idTipoRela { get; set; }
        public int idUsuRegBen { get; set; }
        public int? idUsuModBen { get; set; }
        public int idMotivBaj { get; set; }
        public int idEstado { get; set; }
        public DateTime dFecRegBen { get; set; }
        public DateTime? dFecModBen { get; set; }
        public DateTime? dFecBajBen { get; set; }
        public decimal nBeneficio { get; set; }
        public string cBeneficiario { get; set; }
        public string cNombres { get; set; }
        public string cApePatBen { get; set; }
        public string cApeMatBen { get; set; }
        public string cApeCasBen { get; set; }
        public string cDocIdeBen { get; set; }
        public string cDireccion { get; set; }
        public int idUbigeo { get; set; }

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
    ///
    /// </summary>
    public class clslisBeneficiario : List<clsBeneficiario>
    {
    }
}
