using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsFlujoCajaRural
    {
        public int nFecha { get; set; }
        public int nCuota { get; set; }
        public string cMesCuota { get; set; }
        public decimal nOtrosIngresos { get; set; }
        public decimal nIngresoCultivos { get; set; }
        public decimal nProductosAlmacenados { get; set; }
        public decimal nEgresosCultivos { get; set; }
        public decimal nDeudaFinanciera { get; set; }
        public decimal nExedPyme { get; set; }
        public decimal nExedMensual { get; set; }
        public decimal nNecesidadCredito { get; set; }
    }
}
