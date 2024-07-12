using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenEvalSabio
    {
        [DataMember]
        public string Dictamen { get; set; }
        //public List<DataSenEvalSabioMotivo> Motivos { get; set; } = new List<DataSenEvalSabioMotivo>();
        [DataMember]
        public int ScoreSabio { get; set; }
        [DataMember]
        public string NivelRiesgo { get; set; }
        [DataMember]
        public string Recomendacion { get; set; }
        [DataMember]
        public string CapacidadPago { get; set; }
    }
}
