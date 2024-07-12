using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenInfGenDirecc
    {
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Fuente { get; set; }
    }
}
