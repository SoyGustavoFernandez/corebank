using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADMantConceptos
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarConceptos()
        {
            return objEjeSp.EjecSP("ADM_ListarConceptos_sp");
        }

        public DataTable ActualizarConceptos(int idConcepto, string Tipo, string Nombre, string NombreCorto,
                                        int idGrupo, int AplicaCont, int Vigente)
        {
            return objEjeSp.EjecSP("ADM_ActualizarConceptos_sp", idConcepto, Tipo,  Nombre,  NombreCorto, 
                                                            idGrupo,  AplicaCont,  Vigente);
        }
    }
}
