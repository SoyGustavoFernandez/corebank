using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataResponseMasivaSentinel
    {
        [DataMember]
        public bool lEstado { set; get; }
        [DataMember]
        public string cMensaje { set; get; }
    }
}
