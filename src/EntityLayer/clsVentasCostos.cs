using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsVentasCostos
    {
        public int idVentasCostos { get; set; }
        public int idEvalCred { get; set; }
        public int idTipoActividad { get; set; }
        public string cDescripcion { get; set; }
        public int idDescripcion { get; set; }
        public int idMoneda { get; set; }
        public int idUnidMedida { get; set; }
        public string cUnidMedida { get; set; }
        public decimal nCantidad { get; set; }
        public virtual decimal nPUnitVenta { get; set; }
        public virtual decimal nPUnitCosto { get; set; }

        public decimal nTotalVentas
        {
            get { return (nCantidad * nPUnitVenta); }
        }

        public decimal nTotalCostos
        {
            get { return (nCantidad * nPUnitCosto); }
        }

        public int idMonedaMA { get; set; }

        public decimal nTotalVentasMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nTotalVentas, nTipoCambio);
            }
        }

        public decimal nTotalCostosMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nTotalCostos, nTipoCambio);
            }
        }

        public decimal nUtilidadBruta
        {
            get { return nTotalVentas - nTotalCostos; }
        }

        public decimal nMargenVentas
        {
            get
            {
                if (nTotalVentas == 0) return 0;
                else
                    return (1 - (nTotalCostos / nTotalVentas));
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
        
        public decimal nTipoCambio { get; set; }

        public List<clsCosteo> listCosteo { get; set; }
        public bool lAgricola { get; set; }
        public string cGUID { get; set; }

        public clsVentasCostos()
        {
            idVentasCostos = 0;
            idEvalCred = 0;
            idTipoActividad = 0;
            cDescripcion = "";
            idDescripcion = 9999999;
            idMoneda = 1;
            idUnidMedida = 9999999;
            nCantidad = 0;
            nPUnitVenta = 0;
            nPUnitCosto = 0;

            idMonedaMA = 1;

            nFrecuencia = 1;
            nMesVenta = 1;
            nTipoCambio = 1;

            listCosteo = new List<clsCosteo>();
            lAgricola = false;
            cGUID = System.Guid.NewGuid().ToString();
        }
    }
}
