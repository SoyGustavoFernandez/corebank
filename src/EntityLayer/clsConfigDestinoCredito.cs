using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsConfigDestinoCredito
    {
        public int idDestinoCredito { get; set; }
        public string cDestinoCredito { get; set; }
        public bool lVisible { get; set; }
        public bool lObligatorio { get; set; }

        public clsConfigTipoOperacion padre { get; set; }

        public clsConfigDestinoCredito()
        {
        }
        public clsConfigDestinoCredito(int idDestinoCredito, string cDestinoCredito, clsConfigTipoOperacion padre)
        {
            this.idDestinoCredito = idDestinoCredito;
            this.cDestinoCredito = cDestinoCredito;
            this.padre = padre;
        }
        public BindingList<clsConfigRangoMonto> detalleRangoMonto { get; set; }
        public void validarVisibilidadObligatoriedad()
        {
            this.lVisible = detalleRangoMonto.Count(x => x.lVisible == true) > 0;
            this.lObligatorio = detalleRangoMonto.Count(x => x.lObligatorio == true) > 0;
            padre.lVisible = this.lVisible;
            padre.lObligatorio = this.lObligatorio;
            padre.validarVisibilidadObligatoriedad();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            clsConfigDestinoCredito other = (clsConfigDestinoCredito)obj;
            return idDestinoCredito == other.idDestinoCredito && cDestinoCredito == other.cDestinoCredito
                && lVisible == other.lVisible && lObligatorio == other.lObligatorio &&
                detalleRangoMonto.SequenceEqual(other.detalleRangoMonto);

        }
    }
}
