using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsParamScore
    {
        public string cNumDocuId { get; set; }
	    public string cNumDocuIdConyuge{ get; set; }
	    public string cUbigeo	{ get; set; }
	    public int idAgencia	{ get; set; }
        public int idSolicitud { get; set; }
        public int idTipoScore { get; set; }
        public int idUsuario { get; set; }
        public int idDestino { get; set; }

    }
}
