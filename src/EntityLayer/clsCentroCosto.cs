using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsCentroCosto
    {
       public int IdCentroCosto { get; set; }
       public string cCentroCosto { get; set; }
       public int IdCentroCostoPadre { get; set; }
       public bool lVigente { get; set; }

       public int nOrden { get; set; }
       public int nHijos { get; set; }
       

       public clsCentroCosto(){}
       public clsCentroCosto(clsCentroCosto objClas)
       {
           this.IdCentroCosto = objClas.IdCentroCosto;
           this.cCentroCosto = objClas.cCentroCosto;
           this.IdCentroCostoPadre = objClas.IdCentroCostoPadre;
           this.lVigente = objClas.lVigente;
           this.nHijos = objClas.nHijos;
           this.nOrden = objClas.nOrden;
           
       }
   }
   public class clsLstCentroCosto : List<clsCentroCosto>
    {
    }
}
