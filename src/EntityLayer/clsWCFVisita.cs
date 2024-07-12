using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFVisita
    {
        public int idVisita { get; set; }
        public string dtFechaVisita { get; set; }
        public string cNombre { get; set; }
        public int idEstadoVisita { get; set; }
        public string cEstadoVisita { get;  set; }
        public string cTipoVisita { get; set; }
        public int idTipoVisita { get; set; }
    }

    public class clsWCFTipoVisitaPerfil
    {
        public int idPerfil { get; set; }
        public int idTipoVisita { get; set; }
        public string cTipoVisita { get; set; }
        public string cDescripcion { get; set; }
    }

    public class clsWCFTipoDocVisita
    {
        public int idTipoVisita { get; set; }
        public int idDescTipoDoc { get; set; }
        public string cDescTipoDoc { get; set; }
    }
}
