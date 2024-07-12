using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsRespuestaServidor
    {
        public ResultadoServidor idResultado { get; set; }
        public string cMensaje { get; set; }
        public string cTitulo { get; set; }
        public int idRegistro { get; set; }

        public object objDatos { get; set; }

        public clsRespuestaServidor()
        {
            this.idResultado = ResultadoServidor.Error;
            this.cMensaje = "No existe nigun tipo de respuesta del servidor";
            this.cTitulo = "RESULTADO";
            this.idRegistro = 0;

            this.objDatos = null;
        }
    }
}
