using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.KasNet.Modelo
{
    [DataContract]
    public class ResCreate
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
        public decimal? montoDeudaConvertido = null; //{ get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? comisionConvertido = null; //{ get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<clsConceptosAdicionales> conceptosAdicionales;

        [DataMember(EmitDefaultValue = false)]
        public decimal? montoTotalConceptoConv = null; //{ get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal? montoTotalConvertido = null; //{ get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string numOperacionEmpresa { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string glosa { get; set; }

        public class clsConceptosAdicionales
        {
            public string nombreConcepto { get; set; }

            public decimal montoConceptoConvertido { get; set; }
        }
    }
}