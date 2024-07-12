using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAprobacionGestion
    {
        public ResultadoServidor idResultado { get; set; }
        public string cMensaje { get; set; }
        public string cTitulo { get; set; }
        public int idAprobacionNivel { get; set; }
        public int idEtapa { get; set; }
        public int idEstado { get; set; }

        public clsAprobacionGestion()
        {
            this.idResultado = ResultadoServidor.Error;
            this.cMensaje = "No existe respuesta del servidor";
            this.cTitulo = "RESULTADO DE APROBACION";
            this.idAprobacionNivel = 0;
            this.idEtapa = 0;
            this.idEstado = 0;
        }
    }
}
