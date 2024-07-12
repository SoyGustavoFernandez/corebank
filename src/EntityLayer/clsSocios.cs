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
    /// entidad socio
    /// </summary>
    [Serializable]
    public class clsSocio
    {
        public int idSocio { get; set; }
        public int idCli { get; set; }
        public int idAporte { get; set; }
        public int idTipoFondoSeguro { get; set; }
        public int idFondo { get; set; }
        public int idInscripcion { get; set; }
        public Decimal nInscripcion { get; set; }
        public int nNumBene { get; set; }
        public int idAgencia { get; set; }
        public int idTipoSocio { get; set; }
        public int idUsuRegSoc { get; set; }
        public int idUsuModSoc { get; set; }
        public int idEstado { get; set; }
        public DateTime dFecRegSoc { get; set; }
        public DateTime? dFecModSoc { get; set; }

        public Boolean lTrabajaAct      { get; set; }
        public int idTipoVinculac       { get; set; }
        public int idActvLab            { get; set; }
        public string cInfOtrasActvEcon { get; set; }

        public int idCliApoderado       { get; set; }

        public string obtenerXml()
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
    /// coleccion de la entidad socio
    /// </summary>
    public class clslisSocio : List<clsSocio>
    {
    }
}
