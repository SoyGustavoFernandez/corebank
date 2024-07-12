using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Bus.Response
{
    [DataContract]
    public class clsBusLogin
    {
        [DataMember]
        public string error_description { get; set; }
        [DataMember]
        public string error { get; set; }
        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string scope { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [DataMember]
        public int expires_in { set; get; }
    }
}
