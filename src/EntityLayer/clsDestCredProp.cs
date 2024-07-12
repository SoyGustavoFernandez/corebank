using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDestCredProp
    {
        public int idDestCredProp { get; set; }
        public string cDestinoCredito { get; set; }

        //public int idEvalCred { get; set; }
        public int idTipDestCred { get; set; }
        public int idDetalle { get; set; }
        public decimal nPorcentaje { get; set; }

        public decimal nMontoProp { get; set; }
        public int nCodigo { get; set; }

        /// <summary>
        /// Campo resultante
        /// </summary>
        public decimal nMonto
        {
            get
            {
                return nPorcentaje * nMontoProp;
            }
        }

        public string cDetalle { get; set; }

        public clsDestCredProp()
        {
            idDestCredProp = 0;
            idTipDestCred = 0;
            idDetalle = 0;
            nPorcentaje = 1;

            cDestinoCredito = "";
            cDetalle = "";
        }

        public int idEvalCred { get; set; }
    }
}

