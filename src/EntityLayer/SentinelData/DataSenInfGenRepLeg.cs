using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenInfGenRepLeg
    {
        [DataMember]
        public string TDOC { get; set; }
        [DataMember]
        public string NDOC { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string FecIniCar { get; set; }
        [DataMember]
        public string Cargo { get; set; }
    }
}
