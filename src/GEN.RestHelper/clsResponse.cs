using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.RestHelper
{
    public class clsResponse<T>
    {
        public int StatusCode { get; set; }
        public string Response { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
    }
}
