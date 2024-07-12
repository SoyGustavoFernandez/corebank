using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.KasNet.Modelo
{
    [DataContract]
    public class ResCancel
    {
        [DataMember(EmitDefaultValue = false)]
        public string codigo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string mensaje { get; set; }
    }
}