using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADPlazos
    {        
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarPlazos(int idModulo)
        {
            return objEjeSp.EjecSP("Gen_ListaPlazos_sp", idModulo);
        }
        public DataTable ListarPlazosTodos(int idModulo)
        {
            return objEjeSp.EjecSP("Gen_ListaPlazos_sp", idModulo);
        }

    }
}
