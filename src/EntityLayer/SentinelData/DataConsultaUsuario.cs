using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataConsultaUsuario
    {
        [DataMember]
        public int Success { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<DataErrorApiSentinel> Errors { get; set; }
        [DataMember]
        public List<DataUsuariosUltimaConsulta> Data { set; get; }
        [DataMember]
        public string cTicket { get; set; }
    }
}
