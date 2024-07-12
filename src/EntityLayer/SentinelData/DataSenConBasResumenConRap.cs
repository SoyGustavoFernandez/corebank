using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenConBasResumenConRap
    {
        [DataMember]
        public string Semaforos { get; set; }
        [DataMember]
        public string NroBancos { get; set; }
        [DataMember]
        public string FechaProceso { get; set; }
    }
}
