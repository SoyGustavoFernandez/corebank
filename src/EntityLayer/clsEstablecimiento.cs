using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEstablecimiento
    {
        public int IdEstablecimiento { get; set; }
       public string cEstablecimiento { get; set; }
       public int IdEstablecimientoPadre { get; set; }
       public bool lVigente { get; set; }

       public int nOrden { get; set; }
       public int nHijos { get; set; }
       

       public clsEstablecimiento(){}
       public clsEstablecimiento(clsEstablecimiento objClas)
       {
           this.IdEstablecimiento = objClas.IdEstablecimiento;
           this.cEstablecimiento = objClas.cEstablecimiento;
           this.IdEstablecimientoPadre = objClas.IdEstablecimientoPadre;
           this.lVigente = objClas.lVigente;
           this.nHijos = objClas.nHijos;
           this.nOrden = objClas.nOrden;
           
       }
    }

    public class clsLstEstablecimiento : List<clsEstablecimiento>
    {
    }

}
