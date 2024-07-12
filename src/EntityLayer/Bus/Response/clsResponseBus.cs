using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EntityLayer.Bus.Response
{
    [DataContract]
    public class clsResponseBus
    {
        [DataMember]
        public int success { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public dynamic errors { get; set; }
        [DataMember]
        public dynamic data { set; get; }
    }
}
