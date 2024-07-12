using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenConBasSBSMicr
    {
        [DataMember]
        public int ano { get; set; }
        [DataMember]
        public int mes { get; set; }
        [DataMember]
        public List<DataSenConBasDetSBSMicr> Detalle { set; get; }
    }
}
