using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsTipoArchivoEscaneado : ICloneable
    {
        public int idTipoArchivo { get; set; }
        public int nOrden { get; set; }
        public string cTipoArchivo { get; set; }
        public int idGrupoArchivo { get; set; }
        public DateTime? dFechaVigencia { get; set; }
        public bool lConFechaVigencia { get; set; }
        public bool lIndefinido { get; set; }
        public int idTipArcOrigen { get; set; }
        public string cTipArcOrigen { get; set; }

        public int idUsuReg { get; set; }
        public DateTime dFecRegistro { get; set; }
        public int? idUsuAct { get; set; }
        public DateTime? dFecAct { get; set; }

        public clsTipoArchivoEscaneado()
        {
            idTipoArchivo = 0;
            lIndefinido = true;

        }
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
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
    public class clsListaTipoArchivoEscaneado : BindingList<clsTipoArchivoEscaneado>
    {
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
}
