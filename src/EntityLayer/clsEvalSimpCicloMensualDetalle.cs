using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsEvalSimpCicloMensualDetalle
    {
        public int idEvalSimpDetalleCicloMensual { get; set; }
        public int idEvalSimpCicloMensual { get; set; }
        public int idMes { get; set; }
        [XmlIgnore]
        public string cMes { get; set; }
        public int idTipoCicloMensual { get; set; }
        public decimal nPorcentaje { get; set; }
        public decimal nMontoIngreso { get; set; }
        public bool lMesEvaluado { get; set; }
        public bool lVigente { get; set; }

        public clsEvalSimpCicloMensualDetalle()
        {
            idEvalSimpDetalleCicloMensual = 0;
            idEvalSimpCicloMensual = 0;
            idMes = 0;
            idTipoCicloMensual = 0;
            nMontoIngreso = 0;
            lMesEvaluado = false;
            lVigente = false;
        }
    }
}
