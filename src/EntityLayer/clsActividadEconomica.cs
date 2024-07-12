using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsActividadEconomica
    {
        public int idTipoActividad { get; set; }
        public int idActividadInterna { get; set; }
        public int nAnios { get; set; }
        public string cDireccion { get; set; }
        public string cReferencia { get; set; }
        public string cDescripcion { get; set; }

        public clsActividadEconomica()
        {
            idTipoActividad = 0;        // 1
            idActividadInterna = 0;   // 999
            nAnios = 0;
            cDireccion = String.Empty;
            cReferencia = String.Empty;
            cDescripcion = String.Empty;
        }
    }
}
