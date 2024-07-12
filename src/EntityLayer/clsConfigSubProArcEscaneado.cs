using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{
   
    public class clsConfigSubProArcEscaneado
    {
          

        public int idSubProducto { get; set; }
      
            public int idTipoCredito { get; set; }
           
            public string cSubProducto { get; set; }
           

            public int idTipoArchivo { get; set; }
          
            public int idGrupoArchivo { get; set; }

         
            public bool lVisible { get; set; }
     
            public bool lObligatorio { get; set; }
  

        public BindingList<clsConfigTipoPersona> detalleTipoPersona { get; set; }

        public void validarVisibilidadObligatoriedad()
        {
            this.lVisible = detalleTipoPersona.Count(x => x.lVisible == true) > 0;
            this.lObligatorio = detalleTipoPersona.Count(x => x.lObligatorio == true) > 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            clsConfigSubProArcEscaneado other = (clsConfigSubProArcEscaneado)obj;
            return lVisible == other.lVisible &&
                   lObligatorio == other.lObligatorio &&
                   detalleTipoPersona.SequenceEqual(other.detalleTipoPersona);
        }

    }   

}
