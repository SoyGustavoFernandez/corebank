using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsCreditoDesembolsoCuentaParametro : ICloneable
    {
        public int idOperacion { get; set; }
        public int idModalidadDesembolso { get; set; }
        public int idTipoPersona { get; set; }
        public decimal nValor { get; set; }
        public bool lCargaSeguroDesgravamen { get; set; }
        public decimal nMontoBloqueo { get; set; }
        public bool lAplicaBloqueoCuenta { get; set; }
        public clsDepositoCuentaParametro objDepositoCuentaParametro { get; set; }

        public clsCreditoDesembolsoCuentaParametro()
        {
            objDepositoCuentaParametro      = new clsDepositoCuentaParametro();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string SerializeToString()
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { System.Xml.XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(this.GetType());
            var settings = new System.Xml.XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new System.IO.StringWriter())
            using (var writer = System.Xml.XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, this, emptyNamepsaces);
                return stream.ToString();
            }
        }
    }
}
