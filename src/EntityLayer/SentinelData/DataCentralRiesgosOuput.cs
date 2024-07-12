using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataCentralRiesgosOuput
    {
        [DataMember]
        public DataSenInfBasica InfBas { set; get; }
        [DataMember]
        public DataInfGen InfGen { set; get; }
        [DataMember]
        public DataConRap ConRap { set; get; }
        [DataMember]
        public DataAvalCod AvalCod { set; get; }
        [DataMember]
        public DataSenEvalSabio Sabio { set; get; }
        [DataMember]
        public int nEstado { set; get; }
        [DataMember]
        public string cMensaje { set; get; }
        [DataMember]
        public int idCodigoWS { set; get; }
        [DataMember]
        public string cCodigoWS { set; get; }
    }
    
}
