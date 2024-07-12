using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class clsPersonaSencible
    {
        public int idPerSen { get; set; }
        public string cCargo { get; set; }
        public string cNombres { get; set; }
        public string cApePaterno { get; set; }
        public string cApeMaterno { get; set; }
        public bool bEstadoAprob { get; set; }
    }

    public class clsListPersonaSencible : List<clsPersonaSencible>
    {
    }


}
