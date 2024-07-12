using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsResponseSMS
    {
        public int idRespuesta { get; set; }
        public string cMensaje { get; set; }
        public clsResponseSMS(int _idRespuesta, string _cMensaje)
        {
            this.idRespuesta = _idRespuesta;
            this.cMensaje = _cMensaje;
        }
    }
}
