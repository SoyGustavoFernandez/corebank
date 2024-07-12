using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTasador
    {
        public int idTasador { get; set; }
        public string cDocumento { get; set; }
        public string cPaterno { get; set; }
        public string cMaterno { get; set; }
        public string cNombres { get; set; }
        public string cTasador { get; set; }
        public string cResolSBS { get; set; }
        public DateTime dFecResolucion { get; set; }
        public DateTime dFinResolucion { get; set; }
        public string cDireccion { get; set; }
        public string cDirEstudio { get; set; }
        public int idUbigeo { get; set; }
        public string cTelefFijo { get; set; }
        public string cTelefCel { get; set; }
        public string cEspecialidad { get; set; }
        public DateTime dFechaReg { get; set; }
        
        public bool lVigente { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}",cPaterno,cMaterno,cNombres);
        }
    }
}
