using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenInfGenEsRepLeg
    {
        [DataMember]
        public string TDOC { set; get; }
        [DataMember]
        public string NDOC { set; get; }
        [DataMember]
        public string RazSoc { set; get; }
        [DataMember]
        public string FecIniCar { set; get; }
        [DataMember]
        public string Cargo { set; get; }
        [DataMember]
        public string Estado { set; get; }
    }
}
