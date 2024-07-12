using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenConBasInd
    {
        [DataMember]
        public string Indicador { set; get; }
    }
}
