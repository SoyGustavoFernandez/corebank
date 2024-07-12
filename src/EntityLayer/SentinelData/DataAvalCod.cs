using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataAvalCod
    {
        [DataMember]
        public List<DataSenAvalDe> AvalDe { set; get; }
        [DataMember]
        public List<DataSenAvalPor> QuiAval { set; get; }
        [DataMember]
        public List<DataSenAvalCodDeu> Codeuda { set; get; }
    }
}
