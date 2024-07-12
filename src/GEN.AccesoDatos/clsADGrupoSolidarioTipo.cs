using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADGrupoSolidarioTipo
    {
        public DataTable ListarTipos()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarTiposGrupoSol_sp");
        }

        public DataTable ADListarTipoGrupoSolidario()
        {
            return new clsGENEjeSP().EjecSP("CRE_ListaTipoGrupoSolidario_SP");
        }
    }
}
