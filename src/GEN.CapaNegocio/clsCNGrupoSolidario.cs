using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.CapaNegocio
{
    public class clsCNGrupoSolidario
    {
        public clsADGrupoSolidario objADGrupoSolidario = new clsADGrupoSolidario();

        public DataTable BuscarGrupoSolidario(string cDatoCriterio)
        {
            return objADGrupoSolidario.BuscarGrupoSolidario(cDatoCriterio);
        }
    }
}
