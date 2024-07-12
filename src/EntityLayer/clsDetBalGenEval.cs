using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetBalGenEval
    {
        public int idDetBalGenEval { get; set; }
        public int idEvalCred { get; set; }
        public int idEEFF { get; set; }
        public int nCodigoInv { get; set; }
        public string cDescripcion { get; set; }
        public int idDescripcion { get; set; }
        public int idMoneda { get; set; }
        public int idUnidMedida { get; set; }
        public string cUnidMedida { get; set; }
        public int nCantidad { get; set; }
        public decimal nPUnitario { get; set; }
        public decimal nTotal
        {
            get { return nCantidad * nPUnitario; }
        }

        public int idMonedaMA { get; set; }
        public decimal nTipoCambio { get; set; }

        public decimal nTotalMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nTotal, nTipoCambio);
            }
        }

        public clsDetBalGenEval()
        {
            idDetBalGenEval = 0;
            idEEFF = 9999999;

            idDescripcion = 9999999;
            idMoneda = 1;
            idUnidMedida = 9999999;
            cUnidMedida = "UNIDAD";
            nCantidad = 0;
            nPUnitario = 0;

            idMonedaMA = 1;
            nTipoCambio = 1;
        }
    }
}
