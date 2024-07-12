using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenConBasDetSBSMicr
    {
        [DataMember]
        public string NomEnt { set; get; }
        [DataMember]
        public string Cal { set; get; }
        [DataMember]
        public string SalDeu { set; get; }
        [DataMember]
        public int DiaVen { set; get; }
        [DataMember]
        public string FchPro { set; get; }
        [DataMember]
        public string FchRep { set; get; }
    }
}
