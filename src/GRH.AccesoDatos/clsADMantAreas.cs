using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADMantAreas
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarAreas()
        {
            return objEjeSp.EjecSP("GRH_ListarAreas_SP");
        }
        public DataTable ActualizarAreas(int idArea, string cNomArea, int lVigente)
        {
            return objEjeSp.EjecSP("GRH_ActualizarAreas_SP", idArea, cNomArea, lVigente);
        }
        public DataTable GuardarAreas(string cNomArea,int lVigente)
        {
            return objEjeSp.EjecSP("GRH_GuardarAreas_SP", cNomArea, lVigente);
        }
    }
}
