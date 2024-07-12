using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsConfigRangoMonto
    {
        public int idRangoMonto { get; set; }
        public string cRangoMonto { get; set; }
        public bool lVisible { get; set; }
        public bool lObligatorio { get; set; }

        public clsConfigDestinoCredito padre { get; set; }

        public clsConfigRangoMonto()
        {
        }
        public clsConfigRangoMonto(int idRangoMonto, string cRangoMonto, clsConfigDestinoCredito padre)
        {
            this.idRangoMonto = idRangoMonto;
            this.cRangoMonto = cRangoMonto;
            this.padre = padre;
        }
        public void validarVisibilidadObligatoriedad()
        { 
            padre.validarVisibilidadObligatoriedad();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            clsConfigRangoMonto other = (clsConfigRangoMonto)obj;
            return idRangoMonto == other.idRangoMonto && cRangoMonto == other.cRangoMonto
                && lVisible == other.lVisible && lObligatorio == other.lObligatorio  ;

        }
    }
}
