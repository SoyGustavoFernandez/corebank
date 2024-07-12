using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsConfigTipoPersona
    {
        public int idTipoPersona { get; set; }
        public string cTipoPersona { get; set; }
        public bool lVisible { get; set; }
        public bool lObligatorio { get; set; }
        public clsConfigSubProArcEscaneado padre { get; set; }
        public clsConfigTipoPersona()
        {
        }
        public clsConfigTipoPersona(int idTipoPersona, string cTipoPersona,  clsConfigSubProArcEscaneado padre)
        {
            this.idTipoPersona = idTipoPersona;
            this.cTipoPersona = cTipoPersona;
            this.padre = padre;

        }
        public BindingList<clsConfigTipoOperacion> detalleTipoOperacion { get; set; }
        public void validarVisibilidadObligatoriedad()
        {
            this.lVisible = detalleTipoOperacion.Count(x => x.lVisible == true) > 0;
            this.lObligatorio = detalleTipoOperacion.Count(x => x.lObligatorio == true) > 0;
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

            clsConfigTipoPersona other = (clsConfigTipoPersona)obj;
            return idTipoPersona == other.idTipoPersona && cTipoPersona == other.cTipoPersona
                && lVisible == other.lVisible && lObligatorio == other.lObligatorio &&
                detalleTipoOperacion.SequenceEqual(other.detalleTipoOperacion);

        }
    }
}
