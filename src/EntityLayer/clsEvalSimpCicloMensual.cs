using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEvalSimpCicloMensual
    {
        public int idEvalSimpCicloMensual { get; set; }
        public int idEvalCred { get; set; }
        public int idSolicitud { get; set; }
        public int idTipoCicloMensual { get; set; }
        public int nTotalMesActivos { get; set; }
        public decimal nPorcentaje { get; set; }
        public decimal nMontoTotal { get; set; }
        public bool lVigente { get; set; }

        public List<clsEvalSimpCicloMensualDetalle> lstDetalleMensual { get; set; }

        public clsEvalSimpCicloMensual()
        {
            idEvalSimpCicloMensual = 0;
            idEvalCred = 0;
            idSolicitud = 0;
            idTipoCicloMensual = 0;
            nTotalMesActivos = 0;
            nPorcentaje = 0;
            nMontoTotal = 0;
            lVigente = false;
            lstDetalleMensual = new List<clsEvalSimpCicloMensualDetalle>();
        }

    }
}
