using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCosteo
    {
        public int idCosteo { get; set; }
        public int idEvalCred { get; set; }
        public int idVentasCostos { get; set; }
        public int idTipoCosteo { get; set; }
        //public int idTipoActividad { get; set; }
        public string cDescripcion { get; set; }
        public int idDescripcion { get; set; }
        public int idMoneda { get; set; }
        public int idUnidMedida { get; set; }
        public string cUnidMedida { get; set; }
        public decimal nCantidad { get; set; }
        public decimal nPUnitario { get; set; }

        public decimal nTotal
        {
            get
            {
                if (String.IsNullOrWhiteSpace(cDescripcion)) return 0;
                else return (nCantidad * nPUnitario);
            }
        }

        public int idMonedaMA { get; set; }

        public decimal nTotalMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nTotal, nTipoCambio);
            }
        }

        public int nFrecuencia { get; set; }
        public DateTime dMesVenta { get; set; }
        public int nMesVenta { get; set; }
        public decimal nTipoCambio { get; set; }

        public string cGUID { get; set; }
        public int idDetEstResEval { get; set; }
        public bool lAgricola { get; set; }

        public clsCosteo()
        {
            idCosteo = 0;
            idEvalCred = 0;
            idTipoCosteo = 1;
            cDescripcion = "";
            idDescripcion = 999999999;
            idMoneda = 1;
            idUnidMedida = 999999999;
            nCantidad = 0;
            nPUnitario = 0;
            idMonedaMA = 1;

            nFrecuencia = 1;
            nMesVenta = 1;

            cGUID = System.Guid.NewGuid().ToString();
            idDetEstResEval = 0;
            lAgricola = false;
        }

        public clsCosteo GetObject()
        {
            return (new clsCosteo()
            {
                idCosteo = this.idCosteo,
                idEvalCred = this.idEvalCred,
                idVentasCostos = this.idVentasCostos,
                idTipoCosteo = this.idTipoCosteo,
                cDescripcion = this.cDescripcion,
                idDescripcion = this.idDescripcion,
                idMoneda = this.idMoneda,
                idUnidMedida = this.idUnidMedida,
                nCantidad = this.nCantidad,
                nPUnitario = this.nPUnitario,
                idMonedaMA = this.idMonedaMA,
                nFrecuencia = this.nFrecuencia,
                dMesVenta = this.dMesVenta,
                nMesVenta = this.nMesVenta,
                nTipoCambio = this.nTipoCambio,
                cGUID = this.cGUID,
                idDetEstResEval = this.idDetEstResEval,
                lAgricola = this.lAgricola
            });
        }
    }
}
