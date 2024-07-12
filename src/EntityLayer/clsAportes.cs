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
    [Serializable]
    public class clsAporte
    {
        public int idAporte { get; set; }
        public int idTipoPago { get; set; }
        public int idAgencia { get; set; }
        public int idMoneda { get; set; }
        public int idUsuRegSoc { get; set; }
        public int idUsuModSoc { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaAporte { get; set; }
        public DateTime? dFecCancela { get; set; }
        public DateTime dFecRegSoc { get; set; }
        public DateTime? dFecModSoc { get; set; }
        public bool lAfectaCta { get; set; }
        public decimal nMonTotApor { get; set; }
        public decimal nUtilidad { get; set; }
        public decimal nMonAporte { get; set; }
        public decimal nMonAporteDevuelto { get; set; }

        [XmlIgnore]
        public clslisDetalleAporte objDetalleAportes { get; set; }

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
    ///
    /// </summary>
    public class clslisAporte : List<clsAporte>
    {
    }

    /// <summary>
    ///
    /// </summary>
    public class clsDetalleAporte
    {
        public int idDetAporte { get; set; }
        public int idAporte { get; set; }
        public int idEstado { get; set; }
        public DateTime dFecVenApo { get; set; }
        public decimal nMonApoPac { get; set; }//Es el monto pendiente
        public decimal nMonApoPag { get; set; }
        public decimal nMonApoPac1 { get; set; }//Es el monto pactado
        public string cPeriodo { get; set; }

        public bool lPago { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisDetalleAporte : List<clsDetalleAporte>
    {
    }
}
