using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEstResEval
    {

        public int idEstResEval { get; set; }

        public string cDescripcion { get; set; }

        public int idMonedaUltEv { get; set; }
        public decimal nTotalUltEv { get; set; }
        public int idMonedaMA { get; set; }
        public decimal nTotalUltEvMA { get; set; }
        public decimal nTotalMA { get; set; }
        public int nOrden { get; set; }
        public int idItemEstRes { get; set; }

        /// <summary>
        /// Campo Resultante de una formula
        /// </summary>
        public decimal nAnalisisVertiAndy { get; set; }
        public decimal nAnalisisVerti
        {
            get
            {
                if (nVentasNetas == 0) return 0;
                else
                    return (nTotalMA / nVentasNetas);
            }
        }

        /// <summary>
        /// Campo Resultante de una formula
        /// </summary>
        public decimal nAnalisisHoriz
        {
            get 
            {
                if (nTotalUltEvMA == 0) return 0;
                else
                    return ((nTotalMA - nTotalUltEvMA) / nTotalUltEvMA);
            }
        }

        public decimal nVentasNetas { get; set; }
        public int idEEFF { get; set; }

        public int nTipoTrans { get; set; }
        public decimal nTotalMN { get; set; }
        public decimal nTotalME { get; set; }
        public int idEvalCred { get; set; }
        public bool lEditable { get; set; }

        public clsEstResEval()
        {
            idEstResEval = 0;

            cDescripcion = "";

            idMonedaUltEv = 1;
            nTotalUltEv = 0;
            idMonedaMA = 1;
            nTotalUltEvMA = 0;
            nTotalMA = 0;

            nVentasNetas = 0;
            idEvalCred = 0;
            lEditable = false;
        }
    }
}
