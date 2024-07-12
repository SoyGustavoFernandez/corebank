using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsWCFAutenticacionUsuario
    {
        public int idError { get; set; }
        public string cError { get; set; }
        public Exception ex { get; set; }
        public bool lAutenticado{ get; set; }
    }
}
