using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsConfigTipoOperacion
    {
        public int idTipoOperacion { get; set; }
        public string cTipoOperacion { get; set; }
        public bool lVisible { get; set; }
        public bool lObligatorio { get; set; }
        public clsConfigTipoPersona padre { get; set; }

         public clsConfigTipoOperacion()
        {
        }
        public clsConfigTipoOperacion(int idTipoOperacion, string cTipoOperacion, clsConfigTipoPersona padre)
        {
            this.idTipoOperacion = idTipoOperacion;
            this.cTipoOperacion = cTipoOperacion;
            this.padre = padre;
        }

        public BindingList<clsConfigDestinoCredito> detalleDestinoCredito { get; set; }
        public void validarVisibilidadObligatoriedad()
        {
            this.lVisible = detalleDestinoCredito.Count(x => x.lVisible == true) > 0;
            this.lObligatorio = detalleDestinoCredito.Count(x => x.lObligatorio == true) > 0;
            this.padre.lVisible = this.lVisible;
            this.padre.lObligatorio = this.lObligatorio;
            this.padre.validarVisibilidadObligatoriedad();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            clsConfigTipoOperacion other = (clsConfigTipoOperacion)obj;
            return idTipoOperacion == other.idTipoOperacion && cTipoOperacion == other.cTipoOperacion
                && lVisible == other.lVisible && lObligatorio == other.lObligatorio &&
                detalleDestinoCredito.SequenceEqual(other.detalleDestinoCredito);

        }
    }
}
