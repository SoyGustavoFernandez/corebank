using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataInfGen
    {
        [DataMember]
        public List<DataSenInfGenDirecc> Direcc { set; get; }
        [DataMember]
        public List<DataSenInfGenRepLeg> RepLeg { set; get; }
        [DataMember]
        public List<DataSenInfGenEsRepLeg> EsRepLegDe { set; get; }
    }
}
