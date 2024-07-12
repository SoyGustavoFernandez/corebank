using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF.Pdp.Modelo
{
    public class ReqCancel
    {
        public string nroSumin { get; set; }
        public string numFactura { get; set; }
        public string tracePago { get; set; }
        public string traceConsulta { get; set; }
        public string fechaPago { get; set; }
        public string horaPago { get; set; }
        public decimal montoDeudaConvertido { get; set; }
        public decimal comisionConvertido { get; set; }
        public List<clsConceptosAdicionales> conceptosAdicionales;
        public decimal montoTotalConceptoConv { get; set; }
        public decimal montoTotalConvertido { get; set; }        
        public string codEmpresa { get; set; }
        public string codServicio { get; set; }
        public string codAgencia { get; set; }
        public string codCanal { get; set; }
        public string terminal { get; set; }

        public class clsConceptosAdicionales
        {
            public string nombreConcepto { get; set; }
            public decimal montoConceptoConvertido { get; set; }
        }
    }
}