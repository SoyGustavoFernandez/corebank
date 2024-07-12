using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataCentralRiesgoCliente
    {
        [DataMember]
        public string idTipoDocumentoID { set; get; }
        [DataMember]
        public string cDocumentoID { set; get; }
    }
}
