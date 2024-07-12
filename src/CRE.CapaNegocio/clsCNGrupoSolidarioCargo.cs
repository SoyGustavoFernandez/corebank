using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNGrupoSolidarioCargo
    {
        public DataTable ListarCargos()
        {
            return new clsADGrupoSolidarioCargo().ListarCargos();
        }
    }
}
