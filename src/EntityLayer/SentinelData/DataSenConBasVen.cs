using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenConBasVen
    {
        [DataMember]
        public int IdFue { set; get; }
        [DataMember]
        public string NomFue { set; get; }
        [DataMember]
        public string VenTot { set; get; }
        [DataMember]
        public string MaxDiaVen { set; get; }
        [DataMember]
        public List<DataSenConBasDetVen> DetalleVencidos { set; get; }
    }
}
