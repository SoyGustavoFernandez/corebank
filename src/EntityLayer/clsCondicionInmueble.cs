using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer
{
    public class clsCondicionInmueble
    {
        public int idCondiInmueble { get; set; }
        public string cCondiInmueble { get; set; }
        public int idEstado { get; set; }

        public override string ToString()
        {
 	         return cCondiInmueble;
        }
    }


    public class clslisCondicionInmueble:List<clsCondicionInmueble>
    {
        
    }
}
