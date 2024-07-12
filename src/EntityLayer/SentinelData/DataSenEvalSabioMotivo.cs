using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenEvalSabioMotivo
    {
        [DataMember]
        public string Motivos { get; set; }
        [DataMember]
        public int ScoreSabio { get; set; }
        [DataMember]
        public string NivelRiesgo { get; set; }
    }
}
