using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;

namespace DEP.AccesoDatos
{ 
    
    public class clsADRechazoSolApe
    {
        clsGENEjeSP objEjesp = new clsGENEjeSP();
        //Lista las solicitudes de apertura pendientes de aproación
        public DataTable ADListSolApe(int nIdAgencia)
        {
            return objEjesp.EjecSP("DEP_ListaSolicitudesApe_sp", nIdAgencia);
        }
        //Graba el rechazo de las solicitudes de apertura
        public DataTable ADGrabaRechazoSolApe(string xmlCuentaDen, int idUsuario, DateTime dFechaAtencion)
        {
            return objEjesp.EjecSP("DEP_RechazaSolApe_sp", xmlCuentaDen, idUsuario, dFechaAtencion);
        }
    }
}
