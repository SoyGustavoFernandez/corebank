using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.KasNet.Modelo
{
    [DataContract]
    public class ResAuth
    {
        [DataMember(EmitDefaultValue = false)]
        public string codigo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string mensaje { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? expires_in = null; // { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string token { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string refresh_token { get; set; }
    }
}