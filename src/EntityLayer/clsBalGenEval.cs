using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsBalGenEval
    {
        public int idBalGenEval { get; set; }
        public string cDescripcion { get; set; }
        
        public int idMonedaUltEv { get; set; }
        public decimal nTotalUltEv { get; set; }
        public int idMonedaMA { get; set; }
        public decimal nTotalUltEvMA { get; set; }
        public decimal nTotalMA { get; set; }

        /// <summary>
        /// Campo Resultante de una formula
        /// </summary>
        /// 
        public decimal nAnalisisVertiAndy { get; set; }
        public decimal nAnalisisVerti
        {
            get
            {
                if (nTotalActivos == 0) 
                    return 0;
                else
                    return (nTotalMA / nTotalActivos);
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

        public decimal nTotalActivos { get; set; }
        public int idEEFF { get; set; }
        public int idEEFFPadre { get; set; }
        public bool lEditable { get; set; }
        public int idItemBalGen { get; set; }

        public bool lConsumo = false;
        /*public clsBalGenEval()
        {
            idBalGenEval = 0;
            
            cDescripcion = "";
            
            idMonedaUltEv = 1;
            nTotalUltEv = 0;
            idMonedaMA = 1;
            nTotalUltEvMA = 0;
            nTotalMA = 0;

            nTotalActivos = 0;
            //nTotalPasivPatrim = 0;
        }*/
    }

}
