using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenConBasUtiLinCre
    {
        [DataMember]
        public string Inst { set; get; }
        [DataMember]
        public string LinApr { set; get; }
        [DataMember]
        public string LinNoUti { set; get; }
        [DataMember]
        public string LinUti { set; get; }
        [DataMember]
        public string TipCred { set; get; }
    }
}
