using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.SentinelData
{
    [DataContract]
    public class DataAutenticador
    {
        [DataMember]
        public int Success { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<DataErrorApiSentinel> Errors { get; set; }
        [DataMember]
        public DataTocken Data { set; get; }
        [DataMember]
        public DataSenEvalSabio Sabio { set; get; }
        [DataMember]
        public string cTicket { get; set; }

        public DataAutenticador()
        {
            Success = 0;
            Message = String.Empty;
            Errors = new List<DataErrorApiSentinel>();
            Data = new DataTocken();
            Sabio = new DataSenEvalSabio();
            cTicket = String.Empty;
        }
    }
}
