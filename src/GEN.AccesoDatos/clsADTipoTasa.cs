using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipoTasa
    {
        clsGENEjeSP ObjEjeSp = new clsGENEjeSP();
        public DataTable LisTipoTasa()
        {
            return ObjEjeSp.EjecSP("GEN_LisTipoTasa_sp");
        }
       
    }
}
