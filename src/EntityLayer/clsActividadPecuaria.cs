using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsActividadPecuaria
    {
        public int idMovimientoEvalPecuario { get; set; }
        public int idEvaluacionPecuaria { get; set; }
        public int idPadre { get; set; }
        public decimal nRendimientoUni { get; set; }
        public decimal nPrecioUni { get; set; }
        public decimal nCantidad { get; set; }
        public decimal nMontoTotal { get; set; }
        public int idPeriodoCred { get; set; }
        public string cPeriodoCred { get; set; }
        public DateTime dMesInicio { get; set; }
        public int idEtapaPecuario { get; set; }
        public string cEtapaPecuario { get; set; }
        public int idSubEtapaPecuario { get; set; }
        public string cSubEtapaPecuario { get; set; }
        public int idTipMovEvalPecuario { get; set; }
        public string cMesInicio
        {
            get
            {
                return this.dMesInicio.ToString("MMM yyyy");
            }
        }
        public int nNumeroVenta { get; set; }
    }

}
