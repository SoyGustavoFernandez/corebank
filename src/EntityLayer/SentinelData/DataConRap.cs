using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataConRap
    {
        [DataMember]
        public DataSenConBasResumenConRap Resumen_ConRap { set; get; }
        [DataMember]
        public List<DataSenConBasSBSMicr> DetSBSMicr { set; get; }
        [DataMember]
        public List<DataSenConBasVen> DetVen { set; get; }
        [DataMember]
        public List<DataSenConBasInd> IndCre { set; get; }
        [DataMember]
        public List<DataSenConBasUtiLinCre> UtiLinCre { set; get; }
    }
}
