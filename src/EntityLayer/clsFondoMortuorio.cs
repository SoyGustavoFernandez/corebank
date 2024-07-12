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
    public class clsFondoMortuorio
    {
        public int idFondo { get; set; }
        public int idTipoPago { get; set; }
        public int idAgencia { get; set; }
        public int idMoneda { get; set; }
        public int idUsuRegSoc { get; set; }
        public int idUsuModSoc { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaPago { get; set; }
        public DateTime? dFecCancela { get; set; }
        public DateTime dFecRegSoc { get; set; }
        public DateTime? dFecModSoc { get; set; }
        public bool lAfectaCta { get; set; }
        public decimal nMonTotFon { get; set; }
        public decimal nMonFondo { get; set; }

        [XmlIgnore]
        public clslisDetalleFondo objDetalleFondo { get; set; }

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
    public class clslisFondoMortuorio : List<clsFondoMortuorio>
    {
    }

    /// <summary>
    ///
    /// </summary>
    public class clsDetalleFondo
    {
        public int idDetFondo { get; set; }
        public int idFondo { get; set; }
        public int idEstado { get; set; }
        public DateTime dFecVenApo { get; set; }
        public decimal nMontoPac { get; set; }//MONTO PENDIENTE
        public decimal nMontoPag { get; set; }
        public decimal nMontoPac1 { get; set; }//MONTO PACTADO
        public string cPeriodo { get; set; }
        public bool lPago { get; set; }
        public string cTipoFondoSeguro { get; set; }
        public DateTime? dFechaPagPen { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class clslisDetalleFondo : List<clsDetalleFondo>
    {
    }
}
