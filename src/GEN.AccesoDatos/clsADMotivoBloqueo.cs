using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADMotivoBloqueo
    {
        clsGENEjeSP objEjeSP = new clsGENEjeSP();        

        public DataTable ADListaMotivoBloqueo()
        {
            return objEjeSP.EjecSP("GEN_ListarMotivoBloqueo_SP");
        }        
    }
}
