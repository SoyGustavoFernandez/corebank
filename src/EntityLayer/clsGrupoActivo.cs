using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsGrupoActivo
    {
       public int idGrupoActivo {get;set;}
       public string cNombreGrupo {get;set;}
       public int idPadre {get;set;}
       public int idTipoBien {get;set;}
       public bool lvigente {get;set;}
       public int nOrden { get; set; }
       public int nHijos { get; set; }
       public string cContable { get; set; }

       public clsGrupoActivo(){}
       public clsGrupoActivo(clsGrupoActivo objClas){
           this.idGrupoActivo=objClas.idGrupoActivo;
           this.cNombreGrupo=objClas.cNombreGrupo;
           this.idPadre=objClas.idPadre;
           this.idTipoBien=objClas.idTipoBien;
           this.lvigente=objClas.lvigente;
           this.nHijos = objClas.nHijos;
           this.nOrden = objClas.nOrden;
           this.cContable = objClas.cContable;
       }
   }
    public class clsLstGrupoActivo:List<clsGrupoActivo>
    {
    }
}
