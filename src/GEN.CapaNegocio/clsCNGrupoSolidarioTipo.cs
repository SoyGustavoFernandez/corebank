using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNGrupoSolidarioTipo
    {
        public DataTable ListarTipos()
        {
            return new clsADGrupoSolidarioTipo().ListarTipos();
        }

        public DataTable CNListarTipoGrupoSolidario()
        {
            return new clsADGrupoSolidarioTipo().ADListarTipoGrupoSolidario();
        }
    }
}
