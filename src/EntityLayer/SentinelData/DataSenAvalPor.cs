using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenAvalPor
    {
        [DataMember]
        public string TDoc { set; get; }
        [DataMember]
        public string NDoc { set; get; }
        [DataMember]
        public string RazSoc { set; get; }
        [DataMember]
        public string SemAct { set; get; }
        [DataMember]
        public string SemPre { set; get; }
        [DataMember]
        public string Sem12Mes { set; get; }
        [DataMember]
        public List<DataSenAvalDetPor> Acreedor { set; get; }
    }
}
