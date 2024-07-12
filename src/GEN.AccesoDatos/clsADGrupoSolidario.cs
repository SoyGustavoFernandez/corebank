using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADGrupoSolidario
    {
        private clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable BuscarGrupoSolidario(string cDatoCriterio)
        {
            return objEjeSp.EjecSP("GEN_BuscarGrupoSolidario_Sp", cDatoCriterio);
        }
    }
}
