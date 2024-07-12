using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADMantConceptosRem
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarConceptos()
        {
            return objEjeSp.EjecSP("GRH_ListarConceptosRem_SP");
        }
        public DataTable ActualizarConcepto(int idConcepto, string NombConcepto, int idTipoConcepto, int lVigente)
        {
            return objEjeSp.EjecSP("GRH_ActualizarConceptosRem_SP", idConcepto, NombConcepto, idTipoConcepto, lVigente);
        }
        public DataTable GuardarConcepto(string NombConcepto, int idTipoConcepto, int lVigente)
        {
            return objEjeSp.EjecSP("GRH_GuardarConceptosRem_SP", NombConcepto, idTipoConcepto, lVigente);
        }
    }
}
