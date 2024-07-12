using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenAvalCodDeu
    {
        [DataMember]
        public string TDoc { set; get; }
        [DataMember]
        public string NDoc { set; get; }
        [DataMember]
        public string RazSoc { set; get; }
        [DataMember]
        public string IDCred { set; get; }
        [DataMember]
        public string FecPro { set; get; }
        [DataMember]
        public string TipCod { set; get; }
        [DataMember]
        public string MonDeu { set; get; }
        [DataMember]
        public List<DataSenAvalDetCodDeu> codeudor { set; get; }
    }
}
