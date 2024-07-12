using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsWCFRespuesta
    {
        public int? idError { get; set; }
        public string cError { get; set; }
        public string cRespuesta { get; set; }
        public int? idRespuesta { get; set; }
    }
}
