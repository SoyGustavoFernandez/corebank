using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.KasNet.Modelo
{
    [DataContract]
    public class ResDebtConsult
    {
        [DataMember(EmitDefaultValue = false)]
        public string codigo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string mensaje { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string nombreCliente { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string nroSumin { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ordenPrelacion { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<clsLstdebt> lstdebt;

        public class clsLstdebt
        {
            public string numFactura { get; set; }

            public int tipoMoneda { get; set; }

            public decimal montoTipoCambio { get; set; }

            public decimal montoDeuda { get; set; }

            public decimal montoDeudaConvertido { get; set; }

            public decimal comision { get; set; }

            public decimal comisionConvertido { get; set; }

            public List<clsConceptosAdicionales> conceptosAdicionales;

            public decimal montoTotalConcepto { get; set; }

            public decimal montoTotalConceptoConv { get; set; }

            public decimal montoTotal { get; set; }

            public decimal montoTotalConvertido { get; set; }

            public string formaPago { get; set; }

            public decimal montoMinimo { get; set; }

            public decimal montoMinimoConvertido { get; set; }

            public decimal montoMaximo { get; set; }

            public decimal montoMaximoConvertido { get; set; }

            public string fechaEmision { get; set; }

            public string fechaVencimiento { get; set; }

            public string tipoIntegracion { get; set; }

            public string glosa { get; set; }
            
            public string orden { get; set; }            
        }

        public class clsConceptosAdicionales
        {
            public string nombreConcepto { get; set; }

            public decimal montoConcepto { get; set; }

            public decimal montoConceptoConvertido { get; set; }
        }
    }
}