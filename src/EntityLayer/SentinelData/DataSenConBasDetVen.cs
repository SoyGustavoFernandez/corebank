using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenConBasDetVen
    {
        [DataMember]
        public string NomEnt { set; get; }
        [DataMember]
        public string MontDeu { set; get; }
        [DataMember]
        public string DiaVen { set; get; }
        [DataMember]
        public string NumDoc { set; get; }
    }
}
