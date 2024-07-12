using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADGrupoSolidarioCargo
    {
        public DataTable ListarCargos()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarCargosGrupoSol_sp");
        }
    }
}
