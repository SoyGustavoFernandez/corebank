using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetEstResEval
    {
        public int idDetEstResEval { get; set; }
        public int idEvalCred { get; set; }
        public int idEEFF { get; set; }
        public string cDescripcion { get; set; }
        public int idDescripcion { get; set; }
        public int idMoneda { get; set; }
        public int idUnidMedida { get; set; }
        public string cUnidMedida { get; set; }
        public int nCantidad { get; set; }
        public virtual decimal nPUnitario { get; set; }
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

        public int nFrecuencia { get; set; }

        public DateTime dFechaInicio { get; set; }
        public int nMesVenta { get; set; }
        public DateTime dMesVenta
        {
            get
            {
                return dFechaInicio.AddMonths(nMesVenta);
            }
        }

        public int idEvalCredAlterna { get; set; }
        public string cGUID { get; set; }
        public string cGUIDCosteo { get; set; }
        public int idVentasCostos { get; set; }
        public bool lAgricola { get; set; }

        public int nOperacion { get; set; }
        public int nOrden { get; set; }
        public int nCodigo { get; set; }

        public clsDetEstResEval()
        {
            idDetEstResEval = 0;
            idEEFF = 9999999;

            idDescripcion = 9999999;
            idMoneda = 1;
            idUnidMedida = 9999999;
            nCantidad = 0;
            nPUnitario = 0;

            idMonedaMA = 1;
            nTipoCambio = 1;

            nMesVenta = 1;
            nFrecuencia = 1;
            idEvalCredAlterna = 0;

            cGUID = System.Guid.NewGuid().ToString();
            cGUIDCosteo = System.Guid.NewGuid().ToString();
            idVentasCostos = 0;
            lAgricola = false;

            nOperacion = 1;
            nOrden = 1;
        }
    }
}
