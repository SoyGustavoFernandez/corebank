using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;


namespace DEP.AccesoDatos
{
    public class clsADCliVinculDep
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaTipVincDep()
        {
            return objEjeSp.EjecSP("CRE_ListaCliVincDep_Sp");
        }

        public DataTable ValidaIntervinienteJur(int idCliJuridica,int idCliRepres)
        {
            return objEjeSp.EjecSP("DEP_ValidaCliRepresentante_sp", idCliJuridica, idCliRepres);
        }
    }
}
