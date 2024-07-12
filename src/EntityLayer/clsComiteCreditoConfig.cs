using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsComiteCreditoConfig : ICloneable
    {
        public int idComiteCreditoConfig { get; set; }
        public int idEstablecimiento { get; set; }
        public int nTiempoEvaluacion { get; set; }
        public int nTiempoToleranciaPrev { get; set; }
        public int nTiempoToleranciaPost { get; set; }
        public decimal nMontoMinReqAmpTiempo { get; set; }
        public int nTiempoEsperaAmpliacion { get; set; }
        public bool lVigente { get; set; }

        [XmlIgnore]
        public List<clsComiteCreditoHorario> lstComiteCreditoHorario;

        public clsComiteCreditoConfig()
        {
            this.idComiteCreditoConfig = 0;
            this.idEstablecimiento = 0;
            this.nTiempoEvaluacion = 0;
            this.nTiempoToleranciaPrev = 0;
            this.nTiempoToleranciaPost = 0;
            this.nMontoMinReqAmpTiempo = decimal.Zero;
            this.nTiempoEsperaAmpliacion = 0;
            this.lVigente = true;

            this.lstComiteCreditoHorario = new List<clsComiteCreditoHorario>();

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
