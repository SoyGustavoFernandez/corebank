using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataSenAvalDetPor
    {
        [DataMember]
        public string TDoc { set; get; }
        [DataMember]
        public string NDoc { set; get; }
        [DataMember]
        public string RazSoc { set; get; }
        [DataMember]
        public string Cal { set; get; }
        [DataMember]
        public string SalDeu { set; get; }
        [DataMember]
        public string TipEnt { set; get; }
        [DataMember]
        public string FecRep { set; get; }
    }
}
