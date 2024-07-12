using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADPersonalGen
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADListaPersonal(int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_ListaPersonalGen_sp", idAgencia);
        }
        public DataTable ADListaPersonalPerfil(int idAgencia, string cVarPerfil)
        {
            return objEjeSp.EjecSP("GEN_ListaPersonalPerfilGen_sp", idAgencia, cVarPerfil);
        }
    }
}
