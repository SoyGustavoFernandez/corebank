using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPlantillaSMS : ICloneable
    {
        public int idPlantillaSMS { get; set; }
        public string cMensajeTexto { get; set; }
        public string cCodigoValidacion { get; set; }
        public int nExpiracion { get; set; }
        public int idTipoMensaje { get; set; }

        public clsPlantillaSMS()
        {
            idPlantillaSMS      = 0;
            cMensajeTexto       = String.Empty;
            cCodigoValidacion   = String.Empty;
            nExpiracion         = 0;
            idTipoMensaje       = 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
