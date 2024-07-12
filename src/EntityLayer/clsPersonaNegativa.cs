using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPersonaNegativa
    {
        public int idPerNegativa { get; set; }
        public int idTipoPersona { get; set; }
        public string cNombres { get; set; }
        public string cApePaterno { get; set; }
        public string cApeMaterno { get; set; }
        public string cApeCasado { get; set; }
        public string cNombre { get; set; }
        public int idEstado { get; set; }
        public int idTipoDoc { get; set; }
        public string cNumDoc { get; set; }
        public int idTipoLista { get; set; }
        public DateTime dFechaRegistro { get; set; }
    }


    public class clsListaPersonaNegativa : List<clsPersonaNegativa>
    {

    }
}
