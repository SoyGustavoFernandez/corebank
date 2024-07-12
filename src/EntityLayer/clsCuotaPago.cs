using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCuotaPago
    {
        public int idDeudasEval { get; set; }
        //public int idEvalCred { get; set; }
        public int nContador { get; set; }
        public int nMes { get; set; }
        public decimal nMonto { get; set; }
        public int nFrecuencia { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime dFecha
        {
            get
            {
                return dFechaInicio.AddMonths(nMes);
            }
        }

        public string cGUID { get; set; }

        public int idMoneda { get; set; }
        public int idMonedaMA { get; set; }
        public decimal nTipoCambio { get; set; }
        public decimal nMontoMA
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, idMonedaMA, nMonto, nTipoCambio);
            }
            set { }
        }

        public decimal nMontoMN
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, 1, nMonto, nTipoCambio);
            }
            //set;
        }

        public decimal nMontoME
        {
            get
            {
                return clsMathFinanciera.Convertir(idMoneda, 2, nMonto, nTipoCambio);
            }
            //set;
        }

        public clsCuotaPago()
        {
            nContador = 1;
            nMes = 1;
            nMonto = 0;
            nFrecuencia = 1;
            cGUID = "";
        }
    }
}
