using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADGrupoSolidarioCiclo
    {
        public DataTable ListarCiclos()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarCiclosGrupoSol_sp");
        }
    }
}
