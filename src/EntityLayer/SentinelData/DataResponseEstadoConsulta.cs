using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataResponseEstadoConsulta
    {
        [DataMember]
        public int nEstado { set; get; }
        [DataMember]
        public string cMensaje { set; get; }
    }

}
